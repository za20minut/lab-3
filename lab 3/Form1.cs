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

        private void SaveToCSV(string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    
                    List<string> columnNames = new List<string>();
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        columnNames.Add(column.HeaderText);
                    }
                    writer.WriteLine(string.Join(";", columnNames));

                    
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow) 
                        {
                            List<string> rowData = new List<string>();
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                rowData.Add(cell.Value?.ToString() ?? "");
                            }
                            writer.WriteLine(string.Join(";", rowData));
                        }
                    }
                }

                MessageBox.Show("Dane zapisano!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd zapisu: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFromCSV(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("Plik nie istnieje!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    string firstLine = reader.ReadLine();
                    if (firstLine == null)
                    {
                        MessageBox.Show("Plik jest pusty!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    
                    string[] headers = firstLine.Split(';');
                    foreach (string header in headers)
                    {
                        dataGridView1.Columns.Add(header, header);
                    }

                   
                    while (!reader.EndOfStream)
                    {
                        string[] rowData = reader.ReadLine().Split(';');
                        dataGridView1.Rows.Add(rowData);
                    }
                }

                MessageBox.Show("Dane wczytano!", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd odczytu: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2(this);
            form2.Show();
            
        }

        public void LoadDataToGrid()
        {
            tym = id.ToString();

            if (dataGridView1.ColumnCount == 0) 
            {
                dataGridView1.Columns.Add("ID", "ID");
                dataGridView1.Columns.Add("Tester1", "Tester1");
                dataGridView1.Columns.Add("Tester2", "Tester2");
                dataGridView1.Columns.Add("Tester3", "Tester3");
                dataGridView1.Columns.Add("Tester4", "Tester4");
            }

            
            dataGridView1.Rows.Add(tym, GlobalVars.tester1, GlobalVars.tester2, GlobalVars.tester3, GlobalVars.tester4);
            id++;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow) 
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveToCSV("dane.csv");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadFromCSV("dane.csv");
        }
    }
}
