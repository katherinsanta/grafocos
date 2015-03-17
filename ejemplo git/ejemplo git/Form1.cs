using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (button1.Text == "inicio")
            {
                button1.Text = "ocupado";

            }
            else
            {
                button1.Text = "inicio";
            }
            MessageBox.Show("hayq queda la actualizacion ");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
