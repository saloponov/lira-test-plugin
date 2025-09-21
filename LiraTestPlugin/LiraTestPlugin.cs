using FEModel;
using LiraAPI;
using System.Windows.Forms;
using System.Collections.Generic;

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
            // nodesCount и elemCount – количество узлов и элементов в расчетной схеме
            // loadCase - информация о текущем загружении
            // allLoadCases - информация обо всех доступных в задаче загружениях
            // result - объект, позволяющий получить таблицы результатов расчета

            List<int> elementArray = new List<int>(); //массив индексов узлов или элементов (начиная от 0)

            for (int i = 0; i < ElementsNumber; i++) { elementArray.Add(i); }

            List<FEModel.Results_Key> pKeyArr = new List<Results_Key>(); //объект, описывающий загружение

            pKeyArr.Add(pCurrentCase);

            FEModel.e_Results_ColumnType[] pColumnArr = null; //имена столбцов таблицы результатов

            string[] pNameColumns = null; //названия столбцов таблицы результатов

            //получение таблицы результатов allElements, в данном случае RTT_ELEMENTS, которая содержит информацию об элементах, номер, тип, сечение и т.д. Подробную информацию о доступных типах таблиц вы можете найти в файле LiraAPIHelp.pdf, который копируется на жесткий диск в папку [INSTALLDIR] + "\\LiraAPI" в момент установки ПК ЛИРА 10.12

            System.Data.DataTable allElements = pResultLiraAPI.get_TableResult(e_Results_TableType.RTT_ELEMENTS, elementArray, pKeyArr, ref pColumnArr, ref pNameColumns);

            int count = 0; //счетчик отмеченных элементов

            //перебираем элементы в полученной таблице результатов allElements

            foreach (System.Data.DataRow currentElement in allElements.Rows)
            {
                //проверка – является ли текущий элемент отмеченным. Информацию по названию столбцов в текущей таблице результатов вы можете просмотреть в режиме отладки, например, для таблицы элементов на иллюстрации:
                if ((bool)currentElement[16] == true)
                {
                    count++; //если текущий элемент является выбранным, то увеличиваем значение счетчика
                }
            }

            MessageBox.Show("Отмечено элементов: " + count.ToString()); //выводим сообщение

            return ReturnCodes.RC_OK;
        }
    }
}
