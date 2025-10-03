using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiraDisplacement
{
    public partial class CheckDisp : Form
    {
        public int intDir;
        enum intDirection : int
        {
            X = 1,
            Y = 2,
            Z = 4,
            uX = 8,
            uY = 16,
            uZ = 32,
        }
        public CheckDisp()
        {
            InitializeComponent();
        }

        private void buttonSetDisp_Click(object sender, EventArgs e)
        {
            intDir = e_Dir();
            this.Close();
        }
        private int e_Dir()
        {
            int e_dir = 0;
            if (checkBoxX.Checked) e_dir = e_dir + (int)intDirection.X;
            if (checkBoxY.Checked) e_dir = e_dir + (int)intDirection.Y;
            if (checkBoxZ.Checked) e_dir = e_dir + (int)intDirection.Z;
            if (checkBoxUX.Checked) e_dir = e_dir + (int)intDirection.uX;
            if (checkBoxUY.Checked) e_dir = e_dir + (int)intDirection.uY;
            if (checkBoxUZ.Checked) e_dir = e_dir + (int)intDirection.uZ;
            return e_dir;
        }
    }
}
