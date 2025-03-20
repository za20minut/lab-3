using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_3
{
    public partial class Form2 : Form
    {
        Form1 trociny;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            trociny = form1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalVars.tester1 = textBox1.Text;
            GlobalVars.tester2 = textBox2.Text;
            GlobalVars.tester3 = textBox3.Text;
            GlobalVars.tester4 = textBox4.Text;
            trociny.LoadDataToGrid();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            GlobalVars.tester1 = "";
            GlobalVars.tester2 = "";
            GlobalVars.tester3 = "";
            GlobalVars.tester4 = "";
        }
    }
}
