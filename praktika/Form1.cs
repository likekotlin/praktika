using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktika
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private BindingSource sotrBindingSource;
        private void Form1_Load(object sender, EventArgs e)
        {
            сотрудникиTableAdapter1.Fill(konfetnaya_fabrikaDataSet1.Сотрудники);
            sotrBindingSource = new BindingSource(konfetnaya_fabrikaDataSet1, "Сотрудники");
            FamtextBox.DataBindings.Add("Text", sotrBindingSource, "Фамилия");
            NametextBox.DataBindings.Add("Text", sotrBindingSource, "Имя");
            SectiontextBox.DataBindings.Add("Text", sotrBindingSource, "Отдел");
        }

        private void Previousbutton_Click(object sender, EventArgs e)
        {
            sotrBindingSource.MovePrevious();
        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
            sotrBindingSource.MoveNext();

        private void сотрудникиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.сотрудникиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.konfetnaya_fabrikaDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "konfetnaya_fabrikaDataSet.Товары". При необходимости она может быть перемещена или удалена.
            this.товарыTableAdapter.Fill(this.konfetnaya_fabrikaDataSet.Товары);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "konfetnaya_fabrikaDataSet.Сотрудники". При необходимости она может быть перемещена или удалена.
            this.сотрудникиTableAdapter.Fill(this.konfetnaya_fabrikaDataSet.Сотрудники);

        private void button1_Click(object sender, EventArgs e)
        {
            System.Data.OleDb.OleDbDataReader myReader;
            string Customerstring;
            oleDbConnection1.Open();
            myReader = oleDbCommand1.ExecuteReader();
            while (myReader.Read())
            {
                Customerstring = myReader[1].ToString() + " " + myReader[2].ToString();
                listBox1.Items.Add(Customerstring);
            }
            myReader.Close();
            oleDbConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 Exercise2 = new Form2();
            Exercise2.Show();

        }
    }
}
