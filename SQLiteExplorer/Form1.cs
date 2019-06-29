using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace SQLiteExplorer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection("Data Source="+textBox1.Text);
            connection.Open();
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * from "+textBox2.Text;
            using (SQLiteDataReader dataReader = command.ExecuteReader())
            {
                DataTable dataTable = new DataTable();
                dataTable.Load(dataReader);
                dataReader.Close();
                connection.Close();

                dataGridView1.DataSource = dataTable;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine("Invalid data error; Suppressed.");
        }
    }
}
