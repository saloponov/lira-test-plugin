using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using LiraAPI;
using FEModel;
using FEModel.Interfaces;
using FEMaterial;
using FESection;

namespace LiraSectionToColor
{
    public class GetLiraModel : ILiraPrimeAPI
    {
        public ReturnCodes ExecuteProgram_Prime(IModelAPI pModelAPI, Results_Key pCurentCase)
        {
            IModel imodel = pModelAPI as IModel;
            if (imodel == null) // модель не определена
                return ReturnCodes.RC_IGNOR;

            // иначе выполняем код
            //List<IElement> listElementOrig = new List<IElement>();// массив элементов с оригинальной модели для синхронизации
            List<elemSec> listElemSec = new List<elemSec>();
            imodel = pModelAPI as IModel;
            int elementsCount = 0;
            if (0 < imodel.getAllElementNumber()) // проверяем наличие хотя бы одного элемента в модели
            {
                do // формируем список элементов
                {
                    IElement ielement = imodel.getAllElement(elementsCount);
                    IModelVisualAttributesTypeInfo.e_AttributeType visualAttributesTypeInfo=ielement.getVisualAttributes();
                    bool b_at_display = (visualAttributesTypeInfo & IModelVisualAttributesTypeInfo.e_AttributeType.AT_DISPLAY) == IModelVisualAttributesTypeInfo.e_AttributeType.AT_DISPLAY;
                    //IElement.e_ElFlag ndFlag = ielement.getFlag(); // переменная отвечающая за флаги выбора и видимости.
                    
                    if (b_at_display)
                    {
                        //listElementOrig.Add(ielement);
                        elemSec cur = new elemSec();
                        cur.name = ielement.getSectionPtr().getSectionName();
                        cur.numSec = ielement.getSectionPtr().getIndex()+1;
                        cur.note = ielement.getSectionPtr().getComents();
                        cur.RGB = ielement.getSectionPtr().getColor();
                        listElemSec.Add(cur);
                    }
                    elementsCount++;
                }
                while (elementsCount < imodel.getAllElementNumber());
            }

            elementsCount = 0;
            if (0 < imodel.getAllArchitectureElementNumber()) // проверяем наличие хотя бы одного архитектурного элемента в модели
            {
                do // формируем список элементов
                {
                    IArchitectureElement ielement = imodel.getArchitectureElement(elementsCount);
                    IModelVisualAttributesTypeInfo.e_AttributeType visualAttributesTypeInfo = ielement.getVisualAttributes();
                    bool b_at_display = (visualAttributesTypeInfo & IModelVisualAttributesTypeInfo.e_AttributeType.AT_DISPLAY) == IModelVisualAttributesTypeInfo.e_AttributeType.AT_DISPLAY;
                    //IElement.e_ElFlag ndFlag = ielement.getFlag(); // переменная отвечающая за флаги выбора и видимости.
                    if (b_at_display)
                    {
                        //listElementOrig.Add(ielement);
                        elemSec cur = new elemSec();
                        cur.name = ielement.getSectionPtr().getSectionName();
                        cur.numSec = ielement.getSectionPtr().getIndex() + 1;
                        cur.note = ielement.getSectionPtr().getComents();
                        cur.RGB = ielement.getSectionPtr().getColor();
                        listElemSec.Add(cur);
                    }
                    elementsCount++;
                }
                while (elementsCount < imodel.getAllArchitectureElementNumber());
            }

            

            if (listElemSec.Count > 0) // список не пустой
            {
                var distinctItems = listElemSec.Distinct().ToList(); // убираем дубликаты
                var sortItems = distinctItems.OrderBy(x => x.numSec).ToList(); // сортировка по номеру сечения

                Form1 f = new Form1();
                for (int i = 0; i < sortItems.Count; i++)
                {
                    f.dataGridView1.Rows.Add();
                    f.dataGridView1.Rows[i].Cells[0].Style.BackColor = sortItems[i].RGB;
                    f.dataGridView1.Rows[i].Cells[1].Value = sortItems[i].numSec;
                    f.dataGridView1.Rows[i].Cells[2].Value = sortItems[i].name;
                    f.dataGridView1.Rows[i].Cells[3].Value = sortItems[i].note;
                }
                int h = f.dataGridView1.Rows.Count * f.dataGridView1.Rows[0].Height + f.dataGridView1.ColumnHeadersHeight + 50;
                if (h > 800) h = 800;
                f.Height = h;



                FormCollection f1 = Application.OpenForms;

                foreach (Form frm in f1)
                {
                    if (frm.Text == "Сечения видимые")
                    {
                        frm.Close();
                        break;
                    }
                }

                f.Show();
            }



            return ReturnCodes.RC_OK;
        }
    }

    public class elemSec : IEquatable<elemSec>
    {
        public string name { get; set; }
        public int numSec { get; set; }
        public System.Drawing.Color RGB { get; set; }

        public string note { get; set; }
        

        public bool Equals(elemSec other)
        {
            //Check whether the compared object is null.
            if (Object.ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (Object.ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return numSec.Equals(other.numSec);
        }

        // If Equals() returns true for a pair of objects
        // then GetHashCode() must return the same value for these objects.

        public override int GetHashCode()
        {

            //Get hash code 
            int hashnumSec = numSec.GetHashCode();


            //Calculate the hash code for the product.
            return hashnumSec;
        }
    }
}
