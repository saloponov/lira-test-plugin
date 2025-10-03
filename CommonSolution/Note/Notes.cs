using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LiraAPI;
using FEModel;
using FEModel.Interfaces;

namespace LiraNote
{
    public partial class Notes : Form
    {
        public bool close=true;
        public List<string> ListSelectDescription=new List<string>();
        public string sDescription = "";
        public bool setClick = false;
        public bool selectDescription = false;
        public bool getProfile = false;
        public bool getNumberEl = false;
        public Notes()
        {
            InitializeComponent();           
        }

        public Notes(List<string> descript)
        {
            InitializeComponent();
                dataGridViewDescription.Rows.Clear();
                for (int i = 0; i < descript.Count; i++)
                {
                    if (descript[i] != null)
                    {
                        dataGridViewDescription.Rows.Add(descript[i]);
                    }
                    else
                    {
                        dataGridViewDescription.Rows.Add("Не определено");
                    }
                }
            
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            setClick = true;
            sDescription =textBoxDescription.Text;
            this.Close();

        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            selectDescription = true;
            IEnumerator currentSelectRow = dataGridViewDescription.SelectedRows.GetEnumerator();
            while (currentSelectRow.MoveNext())
            {
                DataGridViewRow currentRow=currentSelectRow.Current as DataGridViewRow;
                string s= currentRow.Cells[0].Value.ToString();
                ListSelectDescription.Add(s);
            }
            this.Close();
        }

        private void buttonProfile_Click(object sender, EventArgs e)
        {
            getProfile = true;
            this.Close();
        }

        private void buttonCopyNumberEl_Click(object sender, EventArgs e)
        {
            getNumberEl = true;
            this.Close();
        }
    }
}
