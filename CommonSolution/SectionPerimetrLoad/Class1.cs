using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LiraAPI;
using FEModel;
using FEModel.Interfaces;
using FELoads;
using FESection;

namespace LiraSectionPerimetrLoad
{
    public class GetLiraModel : ILiraPrimeAPI
    {
        public ReturnCodes ExecuteProgram_Prime(IModelAPI pModelAPI, Results_Key pCurentCase)
        {
            IModel imodel = pModelAPI as IModel;
            if (imodel == null) // модель не определена
                return ReturnCodes.RC_IGNOR;

            // иначе выполняем код
            MFormData formData = new MFormData();
            ILoadingCasesContainer loadContainer = imodel.getLoadingCasesContainer(); // получаем контейнер загружений из модели
            List<ILoadingCase> pLoadCase = loadContainer.get_LoadingsContainer(); // получаем список загружений из модели
            LoadingCaseIndexes keyValues = loadContainer.get_AllIndexes(); //контейнер, содержащий индексы загружений и подзагружений
            var keyValuePairs = keyValues.GetEnumerator();
            while (keyValuePairs.MoveNext()) // создаем список номеров загружений
            {
                var key = keyValuePairs.Current;
                string curLoadNumber = (key.Value.iCase + 1).ToString();
                if (key.Value.iCaseComponent != -1) curLoadNumber = curLoadNumber + "." + (key.Value.iCaseComponent + 1).ToString();
                formData.comboBoxCaseLoads.Items.Add(curLoadNumber);
            }

            formData.comboBoxCaseLoads.SelectedIndex = 0;
            formData.ShowDialog();

            if (formData.bAccept) //назначаем нагрузку
            {
                double load = formData.load;
                int curCase = -1;
                int curSubCase = -1;
                string[] strCaseLoads = formData.caseLoads.Split('.');
                if (strCaseLoads.Length == 1)
                {
                    curCase = Convert.ToInt32(strCaseLoads[0])-1;
                }
                if (strCaseLoads.Length == 2)
                {
                    curCase = Convert.ToInt32(strCaseLoads[0])-1;
                    curSubCase = Convert.ToInt32(strCaseLoads[1])-1;
                }

                List<IElement> listElementOrig = new List<IElement>();// массив элементов с оригинальной модели для синхронизации
                List<int> indexSelElement = new List<int>();
                imodel = pModelAPI as IModel;
                //List<string> description = new List<string>();
                int elementsCount = 0;
                if (0 < imodel.getAllElementNumber()) // проверяем наличие хотя бы одного элемента в модели
                {
                    int i = 0;
                    do // формируем список элементов
                    {
                        IElement ielement = imodel.getAllElement(elementsCount);
                        if (ielement.getFlag(IElement.e_ElFlag.EEF_Selected)) //элемент выделен.
                        {
                            listElementOrig.Add(ielement);
                            indexSelElement.Add(i);
                        }
                        ++elementsCount;
                        i++;
                    }
                    while (elementsCount < imodel.getAllElementNumber());
                }

                List<IArchitectureElement> listElementArh = new List<IArchitectureElement>();// массив элементов с оригинальной модели для синхронизации
                List<int> indexSelElementArh = new List<int>();
                int ArchitectureElementCount = 0;
                if (0 < imodel.getAllArchitectureElementNumber()) // проверяем наличие хотя бы одного элемента в модели
                {
                    int i = 0;
                    do
                    {
                        IArchitectureElement ielement = imodel.getArchitectureElement(ArchitectureElementCount);
                        if (ielement.getFlag(IElement.e_ElFlag.EEF_Selected)) //элемент выделен.
                        {
                            listElementArh.Add(ielement);
                            indexSelElementArh.Add(i);
                        }
                        ++ArchitectureElementCount;
                        i++;
                    }
                    while (ArchitectureElementCount < imodel.getAllArchitectureElementNumber());
                }



                for (int i = 0; i < listElementOrig.Count; i++)
                {
                    IElement curElement = listElementOrig[i];
                    if (curElement.getNodeNumber() == 2) // стержневой элемент
                    {
                        ISection cSection = curElement.getSectionPtr();
                        if (cSection != null)
                        {
                            IBarSection barSection = cSection.Manager.GetBarSection();                            
                            double perimetr=barSection.getPerimeter(); // получили периметр сечения
                            ILoadContainer pLoadContainer = curElement.addLoadContainer(curCase, curSubCase);
                            ILoadBar_RegularForse loadBar_RegularForse=CLoadTypeInfo.get_TypeInfo().CreateLoad(e_Load_type.LT_BAR_REGULAR_FORSE) as ILoadBar_RegularForse;
                            loadBar_RegularForse.setAcxisType(e_Load_Acxis_Type.LAT_GLOBAL);
                            loadBar_RegularForse.setLocation(e_Load_Acxis_Location.LAL_Z);
                            loadBar_RegularForse.setRegularForse(perimetr * load * 1000);
                            pLoadContainer.AddLoad(loadBar_RegularForse);
                            curElement.setLoadContainer(curCase, curSubCase, pLoadContainer);


                        }
                    }
                }

                for (int i = 0; i < listElementArh.Count; i++)
                {
                    IArchitectureElement curElement = listElementArh[i];
                    if (curElement.get_type() == IArchitectureElement.e_ElArchitectureType.EAT_ROD) // стержневой элемент
                    {
                        ISection cSection = curElement.getSectionPtr();
                        if (cSection != null)
                        {
                            IBarSection barSection = cSection.Manager.GetBarSection();
                            double perimetr = barSection.getPerimeter(); // получили периметр сечения
                            ILoadContainer pLoadContainer = curElement.addLoadContainer(curCase, curSubCase);
                            ILoadBar_RegularForse loadBar_RegularForse = CLoadTypeInfo.get_TypeInfo().CreateLoad(e_Load_type.LT_ARCHITECTUR_BAR_REGULAR_FORSE) as ILoadBar_RegularForse;
                            loadBar_RegularForse.setAcxisType(e_Load_Acxis_Type.LAT_GLOBAL);
                            loadBar_RegularForse.setLocation(e_Load_Acxis_Location.LAL_Z);
                            loadBar_RegularForse.setRegularForse(perimetr * load * 1000);
                            pLoadContainer.AddLoad(loadBar_RegularForse);
                            curElement.setLoadContainer(curCase, curSubCase, pLoadContainer);


                        }
                    }
                }
            }

            return ReturnCodes.RC_OK;
        }
    }
}
