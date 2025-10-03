using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using System.Windows.Forms;

using LiraAPI;
using FEModel;
using FEModel.Interfaces;
using FEMaterial;
using FESection;
using System.Reflection;
//using static System.Net.Mime.MediaTypeNames;


namespace LiraNote
{
    public class GetLiraModel : ILiraPrimeAPI
    {
        public ReturnCodes ExecuteProgram_Prime(IModelAPI pModelAPI, Results_Key pCurentCase)
        {
            IModel imodel = pModelAPI as IModel;
            if (imodel == null) // модель не определена
                return ReturnCodes.RC_IGNOR;

            // иначе выполняем код
            List<IElement> listElementOrig = new List<IElement>();// массив элементов с оригинальной модели для синхронизации

            imodel = pModelAPI as IModel;
            List<string> description = new List<string>();
            int elementsCount = 0;
            if (0 < imodel.getAllElementNumber()) // проверяем наличие хотя бы одного элемента в модели
            {
                do // формируем список элементов
                {
                    IElement ielement = imodel.getAllElement(elementsCount);
                    //IElement.e_ElFlag ndFlag = ielement.getFlag(); // переменная отвечающая за флаги выбора и видимости.
                    listElementOrig.Add(ielement);
                    description.Add(ielement.description);
                    ++elementsCount;
                }
                while (elementsCount < imodel.getAllElementNumber());
            }
            // убираем дубликаты "описания"
            var distinctItems = description.Distinct().ToList();
            //Заполняем форму
            Notes formNotes = new Notes(distinctItems);
            formNotes.ShowDialog();

            if (formNotes.setClick) //была нажата кнопка назначить описание
            {
                elementsCount = 0;
                if (0 < imodel.getAllElementNumber()) // проверяем наличие хотя бы одного элемента в модели
                {
                    do // формируем список элементов
                    {
                        IElement element = imodel.getAllElement(elementsCount);
                        if (element.getFlag(IElement.e_ElFlag.EEF_Selected)) //элемент выбран
                        {
                            element.description = formNotes.sDescription;
                            imodel.setElement(elementsCount, element);
                        }

                        ++elementsCount;
                    }
                    while (elementsCount < imodel.getAllElementNumber());
                }
            }

            if(formNotes.selectDescription)
            {
                elementsCount = 0;
                if (0 < imodel.getAllElementNumber()) // проверяем наличие хотя бы одного элемента в модели
                {
                    do // формируем список элементов
                    {
                        IElement element = imodel.getAllElement(elementsCount);
                        if (formNotes.ListSelectDescription.IndexOf(element.description) != -1 || (element.description == null & formNotes.ListSelectDescription.IndexOf("Не определено") != -1)) //элемент имеет описание, совпадающее с выбранным в списке
                        {
                            if (!formNotes.checkBox1.Checked)
                            {
                                if (element.getFlag(IElement.e_ElFlag.EEF_Visible)) //элемент видим на экране, мы его выделяем.
                                {
                                    element.setFlag(IElement.e_ElFlag.EEF_Selected);
                                }
                            }
                            else
                            {
                                element.setFlag(IElement.e_ElFlag.EEF_Selected);
                            }
                        }
                        //if (element.description == null & formNotes.ListSelectDescription.IndexOf("Не определено") != -1)
                        //{
                        //    if (element.getFlag(IElement.e_ElFlag.EEF_Visible)) //элемент видим на экране, мы его выделяем.
                        //    {
                        //        element.setFlag(IElement.e_ElFlag.EEF_Selected);
                        //    }
                        //}
                        else
                        {
                            element.delFlag(IElement.e_ElFlag.EEF_Selected);
                        }
                        

                        ++elementsCount;
                    }
                    while (elementsCount < imodel.getAllElementNumber());

                }
            }

            if(formNotes.getProfile)
            {
                elementsCount = 0;
                if (0 < imodel.getAllElementNumber()) // проверяем наличие хотя бы одного элемента в модели
                {
                    //List<IElement> listElement = new List<IElement>();
                    List<prof> profile = new List<prof>();
                    do // формируем список элементов
                    {
                        prof p = new prof();
                        IElement element = imodel.getAllElement(elementsCount);
                        if (element.getFlag(IElement.e_ElFlag.EEF_Selected)) //элемент выбран
                        {
                            //listElement.Add(element);
                            p.Mark = element.description;
                            IMaterial curMaterial = element.getMaterialPtr();
                            ISection curSection = element.getSectionPtr();
                            p.Material = curMaterial.getMaterialName();
                            p.Profile = curSection.getSectionName();
                            int indexProf = element.getSection();
                            p.image = imodel.getSectionContainer().getSection(indexProf).getSectionImage();//curSection.getSectionImage();


                            profile.Add(p);
                        }

                        ++elementsCount;
                    }
                    while (elementsCount < imodel.getAllElementNumber());


                    FormProfile formProfile = new FormProfile();
                    List<prof> p_sort1 = profile.OrderBy(x => x.Mark).ThenBy(x => x.Profile).ThenBy(x => x.Material).ToList();
                    List<prof> p_sort = p_sort1.Distinct().ToList();
                    for (int i=0;i< p_sort.Count();i++)
                    {
                        formProfile.dataGridViewProfile.Rows.Add(p_sort[i].Mark, p_sort[i].image, p_sort[i].Profile, p_sort[i].Material);
                    }
                    formProfile.Show();
                }
            }
            if(formNotes.getNumberEl)
            {
                string el = "";
                string nd = "";

                //элементы выбранные
                elementsCount = 0;
                if (0 < imodel.getAllElementNumber()) // проверяем наличие хотя бы одного элемента в модели
                {
                    List<int> numberEl = new List<int>();
                    do // формируем список элементов
                    {
                        IElement element = imodel.getAllElement(elementsCount);
                        if (element.getFlag(IElement.e_ElFlag.EEF_Selected)) //элемент выбран
                        {
                            numberEl.Add(elementsCount + 1);
                        }

                        ++elementsCount;
                    }
                    while (elementsCount < imodel.getAllElementNumber());
                    List<string> listing = new List<string>();
                    int bufEl_1 = 0;
                    int bufEl_2 = 0;
                    if (numberEl.Count() > 1)
                    {
                        bufEl_1 = numberEl[0];
                        listing.Add(bufEl_1.ToString());
                        int countflow = 0;
                        bool b = false;
                        for (int i = 1; i < numberEl.Count(); i++)
                        {
                            bufEl_2 = numberEl[i];
                            if (bufEl_1 - bufEl_2 == -1)
                            {
                                bufEl_1 = bufEl_2;
                                b = true;
                                countflow++;
                            }
                            else
                            {
                                if (countflow == 0) listing.Add(" " + bufEl_2.ToString());
                                if (countflow == 1)
                                {
                                    listing.Add(" " + bufEl_1.ToString());
                                    bufEl_1 = bufEl_2;
                                    countflow = 0;
                                    b = false;
                                }
                                if (countflow > 1)
                                {
                                    listing.Add("-" + bufEl_1.ToString() + " " + bufEl_2.ToString());
                                    bufEl_1 = bufEl_2;
                                    countflow = 0;
                                    b = false;
                                }
                            }

                        }
                        if (b)
                        {
                            listing.Add("-" + bufEl_1.ToString());
                        }

                    }
                    else if (numberEl.Count() == 1)
                    {
                        el = numberEl[0].ToString();
                    }
                    //список
                    for (int i = 0; i < listing.Count(); i++)
                    {
                        el = el + listing[i];
                    }

                }

                //узлы выбранные
                elementsCount = 0;
                if (0 < imodel.getAllNodeNumber()) // проверяем наличие хотя бы одного элемента в модели
                {
                    List<int> numberEl = new List<int>();
                    do // формируем список элементов
                    {
                        INode element = imodel.getAllNode(elementsCount);
                        if (element.getFlag(INode.e_NdFlag.ENF_Selected)) //элемент выбран
                        {
                            numberEl.Add(elementsCount + 1);
                        }

                        ++elementsCount;
                    }
                    while (elementsCount < imodel.getAllNodeNumber());
                    List<string> listing = new List<string>();
                    int bufEl_1 = 0;
                    int bufEl_2 = 0;
                    if (numberEl.Count() > 1)
                    {
                        bufEl_1 = numberEl[0];
                        listing.Add(bufEl_1.ToString());
                        int countflow = 0;
                        bool b = false;
                        for (int i = 1; i < numberEl.Count(); i++)
                        {
                            bufEl_2 = numberEl[i];
                            if (bufEl_1 - bufEl_2 == -1)
                            {
                                bufEl_1 = bufEl_2;
                                b = true;
                                countflow++;
                            }
                            else
                            {
                                if (countflow == 0) listing.Add(" " + bufEl_2.ToString());
                                if (countflow == 1)
                                {
                                    listing.Add(" " + bufEl_1.ToString());
                                    bufEl_1 = bufEl_2;
                                    countflow = 0;
                                    b = false;
                                }
                                if (countflow > 1)
                                {
                                    listing.Add("-" + bufEl_1.ToString() + " " + bufEl_2.ToString());
                                    bufEl_1 = bufEl_2;
                                    countflow = 0;
                                    b = false;
                                }
                            }

                        }
                        if (b)
                        {
                            listing.Add("-" + bufEl_1.ToString());
                        }

                    }
                    else if (numberEl.Count() == 1)
                    {
                        nd = numberEl[0].ToString();
                    }
                    //список
                    for (int i = 0; i < listing.Count(); i++)
                    {
                        nd = nd + listing[i];
                    }

                }



                //вывод окна выбранных элементов
                SelectNodesElements f=new SelectNodesElements();
                f.textBoxElement.Text=el;
                f.textBoxNode.Text=nd;
                f.Show();

            }

            return ReturnCodes.RC_OK;
        }

    }
    public class prof : IEquatable<prof>
    {
        public string Mark { get; set; }
        public string Profile { get; set; }
        public string Material { get; set; }
        public Image image { get; set; }

        public bool Equals(prof other)
        {
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return Mark.Equals(other.Mark) && Profile.Equals(other.Profile) && Material.Equals(other.Material);
        }

        // If Equals() returns true for a pair of objects
        // then GetHashCode() must return the same value for these objects.

        public override int GetHashCode()
        {

            //Get hash code 
            int hashProfile = Profile.GetHashCode();
            int hashMaterial = Material.GetHashCode();
            int hashMark = Mark.GetHashCode();

            //Calculate the hash code for the product.
            return hashProfile ^ hashMaterial ^ hashMark;
        }
    }
}
