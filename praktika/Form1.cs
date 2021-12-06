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
        }
    }
}
