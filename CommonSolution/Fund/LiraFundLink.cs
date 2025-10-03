using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiraAPI;
using FEModel;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;


namespace LiraFund
{
    public class LiraFundLink : ILiraAPI
    {
        LiraAPI.ReturnCodes LiraAPI.ILiraAPI.ExecuteProgram_Result(IResultLiraAPI result, int nodesCount, int elemCount, List<List<FEModel.Results_Key>> allLoadCases, FEModel.Results_Key loadCase)
        {

            // nodesCount и elemCount – количество узлов и элементов в расчетной схеме

            // loadCase - информация о текущем загружении

            // allLoadCases - информация обо всех доступных в задаче загружениях

            // result - объект, позволяющий получить таблицы результатов расчета

            if (result.Equals(false))

            {

                MessageBox.Show("IResultLiraAPI return False\n" + ReturnCodes.RC_FAILED.ToString());

                return ReturnCodes.RC_FAILED;

            }

            //читаем переменную типа таблицы
            string assemblyFolder = "";
            int RSU = 0;
            assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            StreamReader f = new StreamReader(assemblyFolder + "\\Property_LiraFund.ini"); // читаем данные из файла  "Property_LiraFund.ini";
            //string path=Path.
            try
            {


                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    string param = s.Split('=')[0];
                    string value = s.Split('=')[1];
                    if (param == "RSU") RSU = int.Parse(value);
                }
                f.Close();
            }
            catch (Exception ex)
            {

            }

            List<int> nodesArray = new List<int>(); //пустой массив с номерами узлов
            for (int i = 0; i < nodesCount; i++) { nodesArray.Add(i); }

            List<int> elementArray = new List<int>(); //пустой массив с номерами элементов

            for (int i = 0; i < elemCount; i++) { elementArray.Add(i); }

            List<FEModel.Results_Key> pKeyArr = new List<FEModel.Results_Key>(); //список активных РСН

            pKeyArr= allLoadCases[3]; //выбор текущего загружения/сочетания

            FEModel.e_Results_ColumnType[] pColumnArr = null; //массив с именами столбцов
            string[] pNameColumns = null; //массив с названием столбцов

            //получение таблицы результатов allElements, в данном случае RTT_ELEMENTS, которая содержит информацию об элементах, номер, тип, сечение и т.д. Подробную информацию о доступных типах таблиц вы можете найти
            //в файле LiraAPIHelp.pdf, который копируется на жесткий диск в папку [INSTALLDIR] + "\\LiraAPI" в момент установки ПК ЛИРА 10.12

            //System.Data.DataTable allElements = result.get_TableResult(e_Results_TableType.RTT_ELEMENTS, elementArray, pKeyArr, ref pColumnArr, ref pNameColumns);

            e_Results_TableType selectTable = e_Results_TableType.RTT_ELEMENTS_BAR_EXTREM_COMBINATION_C;

            switch (RSU)
            {
                case 0:
                    selectTable = e_Results_TableType.RTT_ELEMENTS_BAR_EXTREM_COMBINATION_C;
                    break;
                case 1:
                    selectTable = e_Results_TableType.RTT_ELEMENTS_BAR_EXTREM_COMBINATION_CD;
                    break;
                case 2:
                    selectTable = e_Results_TableType.RTT_ELEMENTS_BAR_EXTREM_COMBINATION_N;
                    break;
                case 3:
                    selectTable = e_Results_TableType.RTT_ELEMENTS_BAR_EXTREM_COMBINATION_ND;
                    break;
            }

            System.Data.DataTable allExtRSNBar = result.get_TableResult(selectTable, elementArray, pKeyArr, ref pColumnArr, ref pNameColumns);
            Form1 f1 = new Form1();
            for (int i = 0; i < pColumnArr.Count(); i++) //добавляем столбцы
            {
                //DataGridViewColumn col = new DataGridViewColumn();
                //col.Name = pNameColumns[i];
                f1.dataGridViewRSN.Columns.Add(pNameColumns[i], pNameColumns[i]);
            }
            //DataGridViewColumn col1 = new DataGridViewColumn();
            //col1.Name = "ColumnQsumQ";
            f1.dataGridViewRSN.Columns.Add("ColumnQsumQ", "ColumnQsumQ");
            //DataGridViewColumn col2 = new DataGridViewColumn();
            //col2.Name = "ColumnMsumM";
            f1.dataGridViewRSN.Columns.Add("ColumnMsumM", "ColumnMsumM");
            // Скрываем ненужные столбцы
            f1.dataGridViewRSN.Columns[2].Visible = false;
            f1.dataGridViewRSN.Columns[3].Visible = false;
            f1.dataGridViewRSN.Columns[4].Visible = false;
            f1.dataGridViewRSN.Columns[5].Visible = false;
            f1.dataGridViewRSN.Columns[6].Visible = false;
            f1.dataGridViewRSN.Columns[7].Visible = false;
            f1.dataGridViewRSN.Columns[8].Visible = false;
            f1.dataGridViewRSN.Columns[9].Visible = false;
            f1.dataGridViewRSN.Columns[23].Visible = false;
            f1.dataGridViewRSN.Columns[24].Visible = false;

            //int count = 0; //счетчик отмеченных элементов

            //перебираем элементы в полученной таблице результатов RTT_ELEMENTS
            List<int> selectNodes= new List<int>();
            System.Data.DataTable allNodes = result.get_TableResult(e_Results_TableType.RTT_NODES, nodesArray, pKeyArr, ref pColumnArr, ref pNameColumns);
            foreach (System.Data.DataRow currentNode in allNodes.Rows)
            {
                //проверка – является ли текущий узел отмеченным. Информацию по названию столбцов в текущей таблице результатов вы можете просмотреть в режиме отладки, например, для таблицы элементов на иллюстрации:
                if ((bool)currentNode[10] == true) //для Лира 10.12 использовать (bool)currentNode[8]

                {                  
                    selectNodes.Add(int.Parse(currentNode[0].ToString())); //если текущий элемент является выбранным, то увеличиваем значение счетчика

                }

            }




            //перебираем элементы в полученной таблице результатов RTT_ELEMENTS
            List<selElement> selectElements = new List<selElement>();
            System.Data.DataTable allElements = result.get_TableResult(e_Results_TableType.RTT_ELEMENTS, elementArray, pKeyArr, ref pColumnArr, ref pNameColumns);
            foreach (System.Data.DataRow currentElement in allElements.Rows)
            {
                //проверка – является ли текущий элемент отмеченным. Информацию по названию столбцов в текущей таблице результатов вы можете просмотреть в режиме отладки, например, для таблицы элементов на иллюстрации:
                if ((bool)currentElement[17] == true) //для Лира 10.12 (bool)currentElement[16]

                {
                    string[] nodes = currentElement[3].ToString().Split(',');
                    string section = "1";
                    selElement E=new selElement();
                    E.element = int.Parse(currentElement[0].ToString());
                    if (selectNodes.IndexOf(int.Parse(nodes[0].ToString()))!=-1)
                    {
                        section = "1";                        
                        E.node_1 = int.Parse(nodes[0].ToString());
                        E.NUMBER_CALC_SECTION_1 = section;
                    }
                    if (selectNodes.IndexOf(int.Parse(nodes[1].ToString())) != -1)
                    {
                        section = currentElement[2].ToString();
                        E.node_2 = int.Parse(nodes[1].ToString());
                        E.NUMBER_CALC_SECTION_2 = section;                        
                    }
                    selectElements.Add(E); //если текущий элемент является выбранным
                }

            }

            //for (int j = 0; j < pKeyArr.Count; j++)
            //{
            //System.Data.DataTable allElements = result.get_TableResult(e_Results_TableType.RTT_ELEMENTS_BAR_EXTREME_NORMAL_STRESSES_RSU_C, nodesArray, pKeyArr, ref pColumnArr, ref pNameColumns);


            int startIndex_1=-1;
            int endIndex_1=-1;
            int startIndex_2 = -1;
            int endIndex_2 = -1;

            //Массив номеров элементов
            List<int> colElements = new List<int>();
            for (int i=0;i < allExtRSNBar.Rows.Count; i++)
            {
                colElements.Add(int.Parse(allExtRSNBar.Rows[i][0].ToString()));
            }
            //Массив номеров сечений
            List<string> colSec = new List<string>();
            for (int i = 0; i < allExtRSNBar.Rows.Count; i++)
            {
                colSec.Add(allExtRSNBar.Rows[i][1].ToString());
            }

            for (int i=0; i<selectElements.Count; i++)
            {
                int curElement=selectElements[i].element;
                int startIndexElement = colElements.IndexOf(curElement);
                int endIndexElement = colElements.LastIndexOf(curElement);
                string curSection_1;
                string curSection_2;
                if(selectElements[i].NUMBER_CALC_SECTION_1!=null)
                {
                    curSection_1 = selectElements[i].NUMBER_CALC_SECTION_1;                    
                    startIndex_1=colSec.IndexOf(curSection_1, startIndexElement);
                    endIndex_1 = colSec.LastIndexOf(curSection_1, endIndexElement, endIndexElement- startIndexElement);
                    for(int j= startIndex_1;j<= endIndex_1;j++)
                    {
                        object[] r = allExtRSNBar.Rows[j].ItemArray;
                        object[] rr = new object[28];
                        for (int k = 0; k < r.Length; k++)
                        {
                            rr[k] = r[k];
                        }
                        rr[3] = Math.Abs(double.Parse(r[15].ToString())) * Math.Abs(double.Parse(r[15].ToString())) + Math.Abs(double.Parse(r[10].ToString()) / 2) * Math.Abs(double.Parse(r[10].ToString()) / 2);
                        rr[2] = Math.Abs(double.Parse(r[17].ToString())) * Math.Abs(double.Parse(r[17].ToString())) + Math.Abs(double.Parse(r[10].ToString()) / 2) * Math.Abs(double.Parse(r[10].ToString()) / 2);
                        rr[4] = Math.Abs(double.Parse(r[10].ToString())) + Math.Abs(double.Parse(r[14].ToString()) / 6) + Math.Abs(double.Parse(r[16].ToString()) / 6);// единичное напряжение
                        rr[6] = double.Parse(r[10].ToString()) + Math.Abs(double.Parse(r[14].ToString()) / 2);
                        rr[7] = double.Parse(r[10].ToString()) - Math.Abs(double.Parse(r[14].ToString()) / 2);
                        rr[23] = double.Parse(r[10].ToString()) + Math.Abs(double.Parse(r[16].ToString()) / 2);
                        rr[24] = double.Parse(r[10].ToString()) - Math.Abs(double.Parse(r[16].ToString()) / 2);
                        rr[26] = Math.Sqrt((double.Parse(r[15].ToString()) * double.Parse(r[15].ToString()) + double.Parse(r[17].ToString()) * double.Parse(r[17].ToString())));
                        rr[27] = Math.Sqrt((double.Parse(r[14].ToString()) * double.Parse(r[14].ToString()) + double.Parse(r[16].ToString()) * double.Parse(r[16].ToString())));
                        f1.dataGridViewRSN.Rows.Add(rr);
                    }
                }
                if (selectElements[i].NUMBER_CALC_SECTION_2 != null)
                {
                    curSection_2 = selectElements[i].NUMBER_CALC_SECTION_2;
                    startIndex_2 = colSec.IndexOf(curSection_2, startIndexElement);
                    endIndex_2 = colSec.LastIndexOf(curSection_2, endIndexElement, endIndexElement - startIndexElement);
                    for (int j = startIndex_2; j <= endIndex_2; j++)
                    {
                        object[] r = allExtRSNBar.Rows[j].ItemArray;
                        object[] rr=new object[28];
                        for(int k = 0; k < r.Length;k++)
                        {
                            rr[k] = r[k];
                        }
                        rr[3] = Math.Abs(double.Parse(r[15].ToString())) * Math.Abs(double.Parse(r[15].ToString())) + Math.Abs(double.Parse(r[10].ToString()) / 2) * Math.Abs(double.Parse(r[10].ToString()) / 2);
                        rr[2] = Math.Abs(double.Parse(r[17].ToString())) * Math.Abs(double.Parse(r[17].ToString())) + Math.Abs(double.Parse(r[10].ToString()) / 2) * Math.Abs(double.Parse(r[10].ToString()) / 2);
                        rr[4] = Math.Abs(double.Parse(r[10].ToString())) + Math.Abs(double.Parse(r[14].ToString()) / 6) + Math.Abs(double.Parse(r[16].ToString()) / 6);// единичное напряжение
                        rr[6] = double.Parse(r[10].ToString()) + Math.Abs(double.Parse(r[14].ToString()) / 2);
                        rr[7] = double.Parse(r[10].ToString()) - Math.Abs(double.Parse(r[14].ToString()) / 2);
                        rr[23] = double.Parse(r[10].ToString()) + Math.Abs(double.Parse(r[16].ToString()) / 2);
                        rr[24] = double.Parse(r[10].ToString()) - Math.Abs(double.Parse(r[16].ToString()) / 2);
                        rr[26] = Math.Sqrt((double.Parse(r[15].ToString()) * double.Parse(r[15].ToString()) + double.Parse(r[17].ToString()) * double.Parse(r[17].ToString())));
                        rr[27] = Math.Sqrt((double.Parse(r[14].ToString()) * double.Parse(r[14].ToString()) + double.Parse(r[16].ToString()) * double.Parse(r[16].ToString())));
                        f1.dataGridViewRSN.Rows.Add(rr);
                    }
                }
            }


            //for (int i = 0; i < allExtRSNBar.Rows.Count; i++) //Добавляем строки
            //{
            //    object[] r = allExtRSNBar.Rows[i].ItemArray;
            //    f1.dataGridViewRSN.Rows.Add(r);
            //}
            //}
            f1.Show();

            return ReturnCodes.RC_OK;
        }

    }
    public class selElement
    {
        public int element { get; set; }
        public int node_1 { get; set; }
        public int node_2 { get; set; }
        public string NUMBER_CALC_SECTION_1 { get; set; }
        public string NUMBER_CALC_SECTION_2 { get; set; }
    }
}
