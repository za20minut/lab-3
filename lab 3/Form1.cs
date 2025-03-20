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
    public partial class Form1 : Form
    {
        string tym;
        int id=0;
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2(this);
            form2.Show();
            
        }
        public void LoadDataToGrid()
        {

            tym = id.ToString();
            dataGridView1.Columns[0].Name = tym;
            dataGridView1.Columns[1].Name = GlobalVars.tester1;
            dataGridView1.Columns[2].Name = GlobalVars.tester2;
            dataGridView1.Columns[3].Name = GlobalVars.tester3;
            dataGridView1.Columns[4].Name = GlobalVars.tester4;
            id++;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
