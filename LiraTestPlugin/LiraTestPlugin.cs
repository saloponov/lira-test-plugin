using FEModel;
using LiraAPI;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System;

namespace LiraTestPlugin
{
    public class LiraTestPlugin : ILiraAPI
    {
        /// <summary>
        /// Called to test a C# DiagnosticAnalyzer when applied on the single inputted string as a source Note: input a DiagnosticResult for each Diagnostic expected.
        /// </summary>
        /// <param name="pResultLiraAPI">Базовый объект проекта лиры</param>
        /// <param name="NodesNumber">Количество узлов</param>
        /// <param name="ElementsNumber">Количество элементов в расчетной схеме</param>
        /// <param name="pAllCases">Информация обо всех доступных в задаче загружениях (список всех используемых в расчете нагрузок на расчитываемые элементы) </param>
        /// <param name="pCurrentCase">Объект, позволяющий получить таблицы результатов расчета</param>
        public ReturnCodes ExecuteProgram_Result(IResultLiraAPI pResultLiraAPI, int NodesNumber, int ElementsNumber, List<List<Results_Key>> pAllCases, Results_Key pCurrentCase)
        {
            List<int> elementArray = Enumerable.Range(0, NodesNumber).ToList();
            
            List<FEModel.Results_Key> pKeyArr = new List<Results_Key>(); //объект, описывающий загружение

            pKeyArr.Add(pCurrentCase);

            FEModel.e_Results_ColumnType[] pColumnArr = null; //имена столбцов таблицы результатов

            string[] pNameColumns = null; //названия столбцов таблицы результатов

            //получение таблицы результатов allElements, в данном случае RTT_ELEMENTS, которая содержит информацию об элементах, номер, тип, сечение и т.д. Подробную информацию о доступных типах таблиц вы можете найти в файле LiraAPIHelp.pdf, который копируется на жесткий диск в папку [INSTALLDIR] + "\\LiraAPI" в момент установки ПК ЛИРА 10.12

            System.Data.DataTable allElements = pResultLiraAPI.get_TableResult(e_Results_TableType.RTT_ELEMENTS, elementArray, new List<FEModel.Results_Key> { pCurrentCase }, ref pColumnArr, ref pNameColumns);

            int count = 0; //счетчик отмеченных элементов
            List<int> selectedElements = new List<int>();

            //перебираем элементы в полученной таблице результатов allElements

            foreach (System.Data.DataRow currentElement in allElements.Rows)
            {
                //проверка – является ли текущий элемент отмеченным. Информацию по названию столбцов в текущей таблице результатов вы можете просмотреть в режиме отладки, например, для таблицы элементов на иллюстрации:
                if ((bool)currentElement["RCT_IS_SELECT)"])
                {

                    count++;
                    selectedElements.Add(Convert.ToInt32(currentElement["RCT_NUMBER"]) - 1);
                }
            }

            MessageBox.Show("Отмечено элементов: " + count.ToString()); //выводим сообщение
            System.Data.DataTable armTable = pResultLiraAPI.get_TableResult(e_Results_TableType.RTT_PLATE_REINFORCED_CONCRETE_RSU, elementArray, new List<FEModel.Results_Key> { pCurrentCase }, ref pColumnArr, ref pNameColumns);

            double sumAs1X = 0;
            double sumAs2X = 0;
            double sumAs3Y = 0;
            double sumAs4Y = 0;

            foreach (int item in selectedElements) 
            {
                double area = Convert.ToDouble(allElements.Rows[item]["RCT_PLATE_AREA"]);
                sumAs1X += Convert.ToDouble(armTable.Rows[item][Array.IndexOf(pNameColumns, "As1X")]) * area;
                sumAs2X += Convert.ToDouble(armTable.Rows[item][Array.IndexOf(pNameColumns, "As2X")]) * area;
                sumAs3Y += Convert.ToDouble(armTable.Rows[item][Array.IndexOf(pNameColumns, "As3Y")]) * area;
                sumAs4Y += Convert.ToDouble(armTable.Rows[item][Array.IndexOf(pNameColumns, "As4Y")]) * area;
            }

            double sumWeight = Math.Round((sumAs1X + sumAs2X + sumAs3Y + sumAs4Y) * 7850, 3);

            MessageBox.Show("Расчетная масса арматуры: " + sumWeight.ToString() + "кг"); 

            return ReturnCodes.RC_OK;
        }
    }
}
