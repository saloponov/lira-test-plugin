using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiraSectionPerimetrLoad
{
    public partial class MFormData : Form
    {
        public bool bAccept = false;
        public double load = 0;
        public string caseLoads = "";
        public MFormData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bAccept = true;
            try
            {
                load = Convert.ToDouble(textBoxLoads.Text.Replace(',', '.'));
            }
            catch { load = 0; }
            caseLoads=comboBoxCaseLoads.Text;
            this.Close();
        }
    }
}
