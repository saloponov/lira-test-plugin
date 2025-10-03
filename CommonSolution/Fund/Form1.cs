using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace LiraFund
{
    public partial class Form1 : Form
    {
        string assemblyFolder = "";
        public Form1()
        {
            InitializeComponent();
            assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            StreamReader f = new StreamReader(assemblyFolder+"\\Property_LiraFund.ini"); // читаем данные из файла  "Property_LiraFund.ini";
            //string path=Path.
            try
            {
               

                while (!f.EndOfStream)
                {
                    string s = f.ReadLine();
                    string param= s.Split('=')[0];
                    string value = s.Split('=')[1];
                    if (param == "Gamma_n") textBoxLamdaN.Text = value;
                    if (param == "Precision") numericUpDownPrecision.Value = decimal.Parse(value);
                    if (param == "RSU") comboBoxTypeRSU.SelectedIndex = int.Parse(value);
                }
                f.Close();
            }
            catch (Exception ex)
            {

            }
            this.Text = "Выборка из " + comboBoxTypeRSU.Text + " (стержни)";
        }

        private void buttonExtrRSU_Click(object sender, EventArgs e)
        {
            //N (8), Mk (9),My (10), Qz (11), Mz (12), Qz (13)
            if (dataGridViewRSN.Rows.Count > 1)
            {
                int indexMaxN = 0;
                int indexMinN = 0;
                double maxN = double.Parse(dataGridViewRSN[10, 0].Value.ToString());
                double minN = double.Parse(dataGridViewRSN[10, 0].Value.ToString());

                int indexMaxMk = 0;
                int indexMinMk = 0;
                double maxMk = double.Parse(dataGridViewRSN[11, 0].Value.ToString());
                double minMk = double.Parse(dataGridViewRSN[11, 0].Value.ToString());

                int indexMaxMy = 0;
                int indexMinMy = 0;
                double maxMy = double.Parse(dataGridViewRSN[14, 0].Value.ToString());
                double minMy = double.Parse(dataGridViewRSN[14, 0].Value.ToString());

                int indexMaxQz = 0;
                int indexMinQz = 0;
                double maxQz = double.Parse(dataGridViewRSN[15, 0].Value.ToString());
                double minQz = double.Parse(dataGridViewRSN[15, 0].Value.ToString());

                int indexMaxMz = 0;
                int indexMinMz = 0;
                double maxMz = double.Parse(dataGridViewRSN[16, 0].Value.ToString());
                double minMz = double.Parse(dataGridViewRSN[16, 0].Value.ToString());

                int indexMaxQy = 0;
                int indexMinQy = 0;
                double maxQy = double.Parse(dataGridViewRSN[17, 0].Value.ToString());
                double minQy = double.Parse(dataGridViewRSN[17, 0].Value.ToString());

                int indexMaxS = 0;
                double maxS = double.Parse(dataGridViewRSN[4, 0].Value.ToString());

                int indexMaxNQz = 0;
                double maxNQz = double.Parse(dataGridViewRSN[3, 0].Value.ToString());

                int indexMaxNQy = 0;
                double maxNQy = double.Parse(dataGridViewRSN[2, 0].Value.ToString());

                int indexMaxN2My = 0;
                double maxN2My = double.Parse(dataGridViewRSN[6, 0].Value.ToString());

                int indexMinN2My = 0;
                double minN2My = double.Parse(dataGridViewRSN[7, 0].Value.ToString());
                int indexMaxN2Mz = 0;
                double maxN2Mz = double.Parse(dataGridViewRSN[23, 0].Value.ToString());

                int indexMinN2Mz = 0;
                double minN2Mz = double.Parse(dataGridViewRSN[23, 0].Value.ToString());

                int indexMaxQzQy = 0;
                double maxQzQy = double.Parse(dataGridViewRSN[26, 0].Value.ToString());

                int indexMaxMzMy = 0;
                double maxMzMy = double.Parse(dataGridViewRSN[27, 0].Value.ToString());

                for (int i = 0; i < dataGridViewRSN.Rows.Count - 2; i++)
                {
                    // поиск максимума и минимума силы N
                    if (maxN < double.Parse(dataGridViewRSN[10, i].Value.ToString()))
                    {
                        maxN = double.Parse(dataGridViewRSN[10, i].Value.ToString());
                        indexMaxN = i;
                    }

                    if (minN > double.Parse(dataGridViewRSN[10, i].Value.ToString()))
                    {
                        minN = double.Parse(dataGridViewRSN[10, i].Value.ToString());
                        indexMinN = i;
                    }

                    // поиск максимума и минимума силы V2
                    if (maxMk < double.Parse(dataGridViewRSN[11, i].Value.ToString()))
                    {
                        maxMk = double.Parse(dataGridViewRSN[11, i].Value.ToString());
                        indexMaxMk = i;
                    }

                    if (minMk > double.Parse(dataGridViewRSN[11, i].Value.ToString()))
                    {
                        minMk = double.Parse(dataGridViewRSN[11, i].Value.ToString());
                        indexMinMk = i;
                    }

                    // поиск максимума и минимума силы V3
                    if (maxMy < double.Parse(dataGridViewRSN[14, i].Value.ToString()))
                    {
                        maxMy = double.Parse(dataGridViewRSN[14, i].Value.ToString());
                        indexMaxMy = i;
                    }

                    if (minMy > double.Parse(dataGridViewRSN[14, i].Value.ToString()))
                    {
                        minMy = double.Parse(dataGridViewRSN[14, i].Value.ToString());
                        indexMinMy = i;
                    }

                    // поиск максимума и минимума силы M1
                    if (maxQz < double.Parse(dataGridViewRSN[15, i].Value.ToString()))
                    {
                        maxQz = double.Parse(dataGridViewRSN[15, i].Value.ToString());
                        indexMaxQz = i;
                    }

                    if (minQz > double.Parse(dataGridViewRSN[15, i].Value.ToString()))
                    {
                        minQz = double.Parse(dataGridViewRSN[15, i].Value.ToString());
                        indexMinQz = i;
                    }

                    // поиск максимума и минимума силы M2
                    if (maxMz < double.Parse(dataGridViewRSN[16, i].Value.ToString()))
                    {
                        maxMz = double.Parse(dataGridViewRSN[16, i].Value.ToString());
                        indexMaxMz = i;
                    }

                    if (minMz > double.Parse(dataGridViewRSN[16, i].Value.ToString()))
                    {
                        minMz = double.Parse(dataGridViewRSN[16, i].Value.ToString());
                        indexMinMz = i;
                    }

                    // поиск максимума и минимума силы M3
                    if (maxQy < double.Parse(dataGridViewRSN[17, i].Value.ToString()))
                    {
                        maxQy = double.Parse(dataGridViewRSN[17, i].Value.ToString());
                        indexMaxQy = i;
                    }

                    if (minQy > double.Parse(dataGridViewRSN[17, i].Value.ToString()))
                    {
                        minQy = double.Parse(dataGridViewRSN[17, i].Value.ToString());
                        indexMinQy = i;
                    }
                    // поиск единичного напряжения
                    if (maxS < double.Parse(dataGridViewRSN[4, i].Value.ToString()))
                    {
                        maxS = double.Parse(dataGridViewRSN[4, i].Value.ToString());
                        indexMaxS = i;
                    }
                    if (maxNQz < double.Parse(dataGridViewRSN[3, i].Value.ToString()))
                    {
                        maxNQz = double.Parse(dataGridViewRSN[3, i].Value.ToString());
                        indexMaxNQz = i;
                    }
                    if (maxNQy < double.Parse(dataGridViewRSN[2, i].Value.ToString()))
                    {
                        maxNQy = double.Parse(dataGridViewRSN[2, i].Value.ToString());
                        indexMaxNQy = i;
                    }
                    if (maxN2My < double.Parse(dataGridViewRSN[6, i].Value.ToString()))
                    {
                        maxN2My = double.Parse(dataGridViewRSN[6, i].Value.ToString());
                        indexMaxN2My = i;
                    }
                    if (minN2My > double.Parse(dataGridViewRSN[7, i].Value.ToString()))
                    {
                        minN2My = double.Parse(dataGridViewRSN[7, i].Value.ToString());
                        indexMinN2My = i;
                    }
                    if (maxN2Mz < double.Parse(dataGridViewRSN[23, i].Value.ToString()))
                    {
                        maxN2Mz = double.Parse(dataGridViewRSN[23, i].Value.ToString());
                        indexMaxN2Mz = i;
                    }
                    if (minN2Mz > double.Parse(dataGridViewRSN[23, i].Value.ToString()))
                    {
                        minN2Mz = double.Parse(dataGridViewRSN[23, i].Value.ToString());
                        indexMinN2Mz = i;
                    }
                    if (maxQzQy < double.Parse(dataGridViewRSN[26, i].Value.ToString()))
                    {
                        maxQzQy = double.Parse(dataGridViewRSN[26, i].Value.ToString());
                        indexMaxQzQy = i;
                    }
                    if (maxMzMy < double.Parse(dataGridViewRSN[27, i].Value.ToString()))
                    {
                        maxMzMy = double.Parse(dataGridViewRSN[27, i].Value.ToString());
                        indexMaxMzMy = i;
                    }
                    // поиск максимума и минимума силы Rz/Mux
                    //if (maxRzMux < Convert.ToDouble(dataGridViewRSN[6, i].Value))
                    //{
                    //    maxRzMux = Convert.ToDouble(dataGridViewRSN[6, i].Value);
                    //    indexMaxRzMux = i;
                    //}

                    //if (minRzMux > Math.Abs(Convert.ToDouble(dataGridViewRSN[9, i].Value)) && Math.Abs(Convert.ToDouble(dataGridViewRSN[9, i].Value)) != 0)
                    //{
                    //    minRzMux = Math.Abs(Convert.ToDouble(dataGridViewRSN[9, i].Value));
                    //    indexMinRzMux = i;
                    //}

                    // поиск максимума и минимума силы Rz/Muy
                    //if (maxRzMuy < Convert.ToDouble(dataGridViewRSN[9, i].Value))
                    //{
                    //    maxRzMuy = Convert.ToDouble(dataGridViewRSN[9, i].Value);
                    //    indexMaxRzMuy = i;
                    //}

                    //if (minRzMuy > Math.Abs(Convert.ToDouble(dataGridViewRSN[10, i].Value)) && Math.Abs(Convert.ToDouble(dataGridViewRSN[10, i].Value)) != 0)
                    //{
                    //    minRzMuy = Math.Abs(Convert.ToDouble(dataGridViewRSN[10, i].Value));
                    //    indexMinRzMuy = i;
                    //}
                }

                //Вывод выбранных строк в датагрид огибающих
                //Rz=N (3), V2=Rx (1),V3=Ry (2), M1=Rux (4), M2=Ruy (5), M3=Ruz (6)
                dataGridViewResult.Rows.Clear();
                dataGridViewResult.Rows.Add(21);
                //Вывод огибающих по N
                double lamdaN = 1;
                String prec="F"+ numericUpDownPrecision.Value.ToString();
                string s = textBoxLamdaN.Text;
                lamdaN=double.Parse(s.Replace(',','.'));
                int count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 0].Value = "max N";
                    dataGridViewResult[j, 0].Value = (double.Parse(dataGridViewRSN[count, indexMaxN].Value.ToString())/ 1000* lamdaN).ToString(prec);

                    dataGridViewResult[0, 1].Value = "min N";
                    dataGridViewResult[j, 1].Value = (double.Parse(dataGridViewRSN[count, indexMinN].Value.ToString()) / 1000* lamdaN).ToString(prec);

                    dataGridViewResult[7, 0].Value = dataGridViewRSN[25, indexMaxN].Value ;
                    dataGridViewResult[7, 1].Value = dataGridViewRSN[25, indexMinN].Value ;
                    dataGridViewResult[8, 0].Value = dataGridViewRSN[0, indexMaxN].Value;
                    dataGridViewResult[8, 1].Value = dataGridViewRSN[0, indexMinN].Value ;
                    count++;
                }

                //Вывод огибающих по V2
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 2].Value = "max Mk";
                    dataGridViewResult[j, 2].Value = (double.Parse(dataGridViewRSN[count, indexMaxMk].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[0, 3].Value = "min Mk";
                    dataGridViewResult[j, 3].Value = (double.Parse(dataGridViewRSN[count, indexMinMk].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 2].Value = dataGridViewRSN[25, indexMaxMk].Value;
                    dataGridViewResult[7, 3].Value = dataGridViewRSN[25, indexMinMk].Value;
                    dataGridViewResult[8, 2].Value = dataGridViewRSN[0, indexMaxMk].Value;
                    dataGridViewResult[8, 3].Value = dataGridViewRSN[0, indexMinMk].Value;
                    count++;
                }

                //Вывод огибающих по V3
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 4].Value = "max My";
                    dataGridViewResult[j, 4].Value = (double.Parse(dataGridViewRSN[count, indexMaxMy].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[0, 5].Value = "min My";
                    dataGridViewResult[j, 5].Value = (double.Parse(dataGridViewRSN[count, indexMinMy].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 4].Value = dataGridViewRSN[25, indexMaxMy].Value;
                    dataGridViewResult[7, 5].Value = dataGridViewRSN[25, indexMinMy].Value;
                    dataGridViewResult[8, 4].Value = dataGridViewRSN[0, indexMaxMy].Value;
                    dataGridViewResult[8, 5].Value = dataGridViewRSN[0, indexMinMy].Value;
                    count++;
                }

                //Вывод огибающих по M1
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 6].Value = "max Qz";
                    dataGridViewResult[j, 6].Value = (double.Parse(dataGridViewRSN[count, indexMaxQz].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[0, 7].Value = "min Qz";
                    dataGridViewResult[j, 7].Value = (double.Parse(dataGridViewRSN[count, indexMinQz].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 6].Value = dataGridViewRSN[25, indexMaxQz].Value ;
                    dataGridViewResult[7, 7].Value = dataGridViewRSN[25, indexMinQz].Value ;
                    dataGridViewResult[8, 6].Value = dataGridViewRSN[0, indexMaxQz].Value ;
                    dataGridViewResult[8, 7].Value = dataGridViewRSN[0, indexMinQz].Value;
                    count++;
                }

                //Вывод огибающих по M2
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 8].Value = "max Mz";
                    dataGridViewResult[j, 8].Value = (double.Parse(dataGridViewRSN[count, indexMaxMz].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[0, 9].Value = "min Mz";
                    dataGridViewResult[j, 9].Value = (double.Parse(dataGridViewRSN[count, indexMinMz].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 8].Value = dataGridViewRSN[25, indexMaxMz].Value;
                    dataGridViewResult[7, 9].Value = dataGridViewRSN[25, indexMinMz].Value ;
                    dataGridViewResult[8, 8].Value = dataGridViewRSN[0, indexMaxMz].Value;
                    dataGridViewResult[8, 9].Value =dataGridViewRSN[0, indexMinMz].Value;
                    count++;
                }

                //Вывод огибающих по M3
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 10].Value = "max Qy";
                    dataGridViewResult[j, 10].Value = (double.Parse(dataGridViewRSN[count, indexMaxQy].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[0, 11].Value = "min Qy";
                    dataGridViewResult[j, 11].Value = (double.Parse(dataGridViewRSN[count, indexMinQy].Value.ToString()) / 1000 * lamdaN).ToString(prec) ;

                    dataGridViewResult[7, 10].Value = dataGridViewRSN[25, indexMaxQy].Value;
                    dataGridViewResult[7, 11].Value = dataGridViewRSN[25, indexMinQy].Value;
                    dataGridViewResult[8, 10].Value = dataGridViewRSN[0, indexMaxQy].Value;
                    dataGridViewResult[8, 11].Value = dataGridViewRSN[0, indexMinQy].Value;
                    count++;
                }
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 12].Value = "max |N|+|Mz|/6+|My|/6";
                    dataGridViewResult[j, 12].Value = (double.Parse(dataGridViewRSN[count, indexMaxS].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 12].Value = dataGridViewRSN[25, indexMaxS].Value;
                    dataGridViewResult[8, 12].Value = dataGridViewRSN[0, indexMaxS].Value;

                    count++;
                }
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 13].Value = "max ((N/2)^2+Qz^2)^0.5";
                    dataGridViewResult[j, 13].Value = (double.Parse(dataGridViewRSN[count, indexMaxNQz].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 13].Value = dataGridViewRSN[25, indexMaxNQz].Value;
                    dataGridViewResult[8, 13].Value = dataGridViewRSN[0, indexMaxNQz].Value;

                    count++;
                }
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 14].Value = "max ((N/2)^2+Qy^2)^0.5";
                    dataGridViewResult[j, 14].Value = (double.Parse(dataGridViewRSN[count, indexMaxNQy].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 14].Value = dataGridViewRSN[25, indexMaxNQy].Value;
                    dataGridViewResult[8, 14].Value = dataGridViewRSN[0, indexMaxNQy].Value;

                    count++;
                }
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 15].Value = "max N+|My/2|";
                    dataGridViewResult[j, 15].Value = (double.Parse(dataGridViewRSN[count, indexMaxN2My].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 15].Value = dataGridViewRSN[25, indexMaxN2My].Value;
                    dataGridViewResult[8, 15].Value = dataGridViewRSN[0, indexMaxN2My].Value;

                    count++;
                }
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 16].Value = "min N+|My/2|";
                    dataGridViewResult[j, 16].Value = (double.Parse(dataGridViewRSN[count, indexMinN2My].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 16].Value = dataGridViewRSN[25, indexMinN2My].Value;
                    dataGridViewResult[8, 16].Value = dataGridViewRSN[0, indexMinN2My].Value;

                    count++;
                }
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 17].Value = "max N+|Mz/2|";
                    dataGridViewResult[j, 17].Value = (double.Parse(dataGridViewRSN[count, indexMaxN2Mz].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 17].Value = dataGridViewRSN[25, indexMaxN2Mz].Value;
                    dataGridViewResult[8, 17].Value = dataGridViewRSN[0, indexMaxN2Mz].Value;

                    count++;
                }
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 18].Value = "min N+|Mz/2|";
                    dataGridViewResult[j, 18].Value = (double.Parse(dataGridViewRSN[count, indexMinN2Mz].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 18].Value = dataGridViewRSN[25, indexMinN2Mz].Value;
                    dataGridViewResult[8, 18].Value = dataGridViewRSN[0, indexMinN2Mz].Value;

                    count++;
                }
                //(Qz^2+Qy^2)^0.5
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 19].Value = "max (Qz^2+Qy^2)^0.5";
                    dataGridViewResult[j, 19].Value = (double.Parse(dataGridViewRSN[count, indexMaxQzQy].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 19].Value = dataGridViewRSN[25, indexMaxQzQy].Value;
                    dataGridViewResult[8, 19].Value = dataGridViewRSN[0, indexMaxQzQy].Value;
                    dataGridViewResult[9, 19].Value = (double.Parse(dataGridViewRSN[26, indexMaxQzQy].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    count++;
                }
                //(Mz^2+My^2)^0.5
                count = 10;
                for (int j = 1; j < 7; j++)
                {
                    if (count == 12) count = 14;
                    dataGridViewResult[0, 20].Value = "max (Mz^2+My^2)^0.5";
                    dataGridViewResult[j, 20].Value = (double.Parse(dataGridViewRSN[count, indexMaxMzMy].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    dataGridViewResult[7, 20].Value = dataGridViewRSN[25, indexMaxMzMy].Value;
                    dataGridViewResult[8, 20].Value = dataGridViewRSN[0, indexMaxMzMy].Value;
                    dataGridViewResult[9, 20].Value = (double.Parse(dataGridViewRSN[27, indexMaxMzMy].Value.ToString()) / 1000 * lamdaN).ToString(prec);

                    count++;
                }

                ////Вывод огибающих по Rz/Rux
                //for (int j = 1; j < 7; j++)
                //{
                //    //dataGridViewResult[0, 12].Value = "max Rz/Rux";
                //    //dataGridViewResult[j, 12].Value = dataGridViewRSN[j, indexMaxRzMux].Value;

                //    dataGridViewResult[0, 12].Value = "min Rz/Rux";
                //    dataGridViewResult[j, 12].Value = dataGridViewRSN[j, indexMinRzMux].Value;


                //    dataGridViewResult[7, 12].Value = dataGridViewRSN[8, indexMinRzMux].Value;
                //    //dataGridViewResult[7, 13].Value = dataGridViewRSN[8, indexMinRzMux].Value;
                //    dataGridViewResult[8, 12].Value = dataGridViewRSN[0, indexMinRzMux].Value;
                //    //dataGridViewResult[8, 13].Value = dataGridViewRSN[0, indexMinRzMux].Value;
                //}
                //dataGridViewResult[3, 12].Style.BackColor = Color.LightYellow;
                //dataGridViewResult[4, 12].Style.BackColor = Color.LightYellow;

                ////Вывод огибающих по Rz/Rux
                //for (int j = 1; j < 7; j++)
                //{
                //    //dataGridViewResult[0, 13].Value = "max Rz/Ruy";
                //    //dataGridViewResult[j, 13].Value = dataGridViewRSN[j, indexMaxRzMuy].Value;

                //    dataGridViewResult[0, 13].Value = "min Rz/Ruy";
                //    dataGridViewResult[j, 13].Value = dataGridViewRSN[j, indexMinRzMuy].Value;

                //    //dataGridViewResult[7, 14].Value = dataGridViewRSN[8, indexMaxRzMuy].Value;
                //    dataGridViewResult[7, 13].Value = dataGridViewRSN[8, indexMinRzMuy].Value;
                //    //dataGridViewResult[8, 14].Value = dataGridViewRSN[0, indexMaxRzMuy].Value;
                //    dataGridViewResult[8, 13].Value = dataGridViewRSN[0, indexMinRzMuy].Value;
                //}
                //dataGridViewResult[3, 13].Style.BackColor = Color.LightBlue;
                //dataGridViewResult[5, 13].Style.BackColor = Color.LightBlue;

                //подсветка диагонали огибающих
                int k = 0;
                for (int j = 1; j < 7; j++)
                {
                    dataGridViewResult[j, k].Style.BackColor = Color.YellowGreen;
                    dataGridViewResult[j, k + 1].Style.BackColor = Color.YellowGreen;
                    k = k + 2;
                }
                dataGridViewResult[1,12].Style.BackColor = Color.LightBlue;
                dataGridViewResult[3, 12].Style.BackColor = Color.LightBlue;
                dataGridViewResult[5, 12].Style.BackColor = Color.LightBlue;
                dataGridViewResult[1, 13].Style.BackColor = Color.LightSeaGreen;
                dataGridViewResult[4, 13].Style.BackColor = Color.LightSeaGreen;
                dataGridViewResult[1, 14].Style.BackColor = Color.LightYellow;
                dataGridViewResult[6, 14].Style.BackColor = Color.LightYellow;
                dataGridViewResult[1, 15].Style.BackColor = Color.LightCyan;
                dataGridViewResult[3, 15].Style.BackColor = Color.LightCyan;
                dataGridViewResult[1, 16].Style.BackColor = Color.LightCyan;
                dataGridViewResult[3, 16].Style.BackColor = Color.LightCyan;
                dataGridViewResult[1, 17].Style.BackColor = Color.Lime;
                dataGridViewResult[5, 17].Style.BackColor = Color.Lime;
                dataGridViewResult[1, 18].Style.BackColor = Color.Lime;
                dataGridViewResult[5, 18].Style.BackColor = Color.Lime;
            }
        }

        private void buttonSaveParameters_Click(object sender, EventArgs e)
        {
            string FileName = assemblyFolder + "\\Property_LiraFund.ini";
            //string path=Path.
            try
            {
                FileInfo fi = new FileInfo(FileName);

                if (FileName != "")
                {
                    // Create a file to write to.
                    using (StreamWriter sw = fi.CreateText())
                    {
                        sw.WriteLine("Gamma_n="+textBoxLamdaN.Text);
                        sw.WriteLine("Precision=" + numericUpDownPrecision.Value.ToString());
                        sw.WriteLine("RSU=" + comboBoxTypeRSU.SelectedIndex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonCopyClipBoard_Click(object sender, EventArgs e)
        {
            if (dataGridViewResult.SelectedCells.Count > 0)
            {
                //dataGridViewResult.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                DataObject dataObj = dataGridViewResult.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
                //dataGridViewResult.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithAutoHeaderText;
            }
        }
    }
}
