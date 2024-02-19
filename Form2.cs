using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1qweasdyxc
{
    public partial class Form2 : Form
    {
        Form1 f1;

        public Form2(Form f)
        {
            InitializeComponent();
            f1 = (Form1)f;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double zům = (5*(double)trackBar1.Value/101);
            if (zům == 0)
                zům = 0.01;
            f1.Kresleni(zům, !Hatadendler.cernobile);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
