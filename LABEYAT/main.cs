using LABEYAT.src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABEYAT
{
    public partial class main : Form
    {
        private document1 uc1;
        private document2 uc2;
        private document3 uc3;
        private document4 uc4;
        private document5 uc5;
        private document6 uc6;
        private document7 uc7;
        private document8 uc8;

        public main()
        {
            InitializeComponent();
            uc1 = new document1();
            uc2 = new document2();
            uc3 = new document3();
            uc4 = new document4();
            uc5 = new document5();
            uc6 = new document6();
            uc7 = new document7();
            uc8 = new document8();

        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            // TO SHOW PANNELS
            panel1.Controls.Clear ();
            panel1.Controls.Add (uc1);
            uc1.Dock = DockStyle.Fill;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uc2);
            uc2.Dock = DockStyle.Fill;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uc3);
            uc3.Dock = DockStyle.Fill;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uc4);
            uc4.Dock = DockStyle.Fill;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uc5);
            uc5.Dock = DockStyle.Fill;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uc6);
            uc6.Dock = DockStyle.Fill;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uc7);
            uc7.Dock = DockStyle.Fill;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uc8);
            uc8.Dock = DockStyle.Fill;
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
    }
}
