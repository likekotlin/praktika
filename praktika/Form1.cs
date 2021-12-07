using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika
{
    public partial class Form1 : Form
    {

        private delegate int AsyncSumm(int a, int b);
        private int Summ(int a, int b)
        {
            System.Threading.Thread.Sleep(9000);
            return a + b;
        }
        private void CallBackMethod(IAsyncResult ar)
        {
            string str;
            AsyncSumm summdelegate = (AsyncSumm)ar.AsyncState;
            str = string.Format("Сумма введенных чисел равна {0}", summdelegate.EndInvoke(ar));
            MessageBox.Show(str, "Результат операции");

        bool Cancel;
        private void TimeConsumingMethod(int seconds)
        {
            for (int j = 1; j <= seconds; j++)
            {
                SetProgress((int)(j * 100) / seconds);
                System.Threading.Thread.Sleep(1000);
                if (Cancel)
                    break;
            }
            if (Cancel)
            {
                System.Windows.Forms.MessageBox.Show("Cancelled");
                Cancel = false;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Complete");
            }
        }
        private delegate void TimeConsumingMethodDelegate(int seconds);
        public delegate void SetProgressDelegate(int val);
        public void SetProgress(int val)
        {
            if (progressBar1.InvokeRequired)
            {
                SetProgressDelegate del = new SetProgressDelegate(SetProgress);
                this.Invoke(del, new object[] { val });
            }
            else
            {
                progressBar1.Value = val;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void btnRun_Click_1(object sender, EventArgs e)
        {
            int a, b;
            try
            {
                //Преобрахование типов данных
                a = Int32.Parse(txtA.Text);
                b = Int32.Parse(txbB.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("При выполнентт преобразования типов возникла ошибка");
                txtA.Text = txbB.Text = " ";
                return;
            }
            AsyncSumm summdelegate = new AsyncSumm(Summ);
            AsyncCallback cd = new AsyncCallback(CallBackMethod);
            summdelegate.BeginInvoke(a, b, cd, summdelegate);
        }

        private void btnWork_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Работа идет полным ходом");
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Поле должно содержать цифры");
            }
        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            
                TimeConsumingMethodDelegate del = new
                    TimeConsumingMethodDelegate(TimeConsumingMethod);
                del.BeginInvoke(int.Parse(textBox1.Text), null, null);
          
            if (!char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
                MessageBox.Show("Поле должно содержать цифры");

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int i;
            i = int.Parse(e.Argument.ToString());
            for (int j = 1; j <= i; j++)
            {
                if (backgroundWorker1.CancellationPending)

                {
                    e.Cancel = true;
                    return;
                }
                System.Threading.Thread.Sleep(1000);
                backgroundWorker1.ReportProgress((int)(j * 100 / i));
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!(e.Cancelled))
                System.Windows.Forms.MessageBox.Show("Run Completed!");
            else
                System.Windows.Forms.MessageBox.Show("Run Cancelled");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == ""))
            {
                int i = int.Parse(textBox1.Text);
                backgroundWorker1.RunWorkerAsync(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Cancel = true;
            backgroundWorker1.CancelAsync();
=======


        private void btnCenter_AW_SLIDE_Click(object sender, EventArgs e)
        {
            this.Hide();
            WinAPIClass.AnimateWindow(this, 3000, WinAPIClass.AnimateWindowFlags.AW_CENTER | WinAPIClass.AnimateWindowFlags.AW_SLIDE);
            this.btnAW_BLEND.Invalidate();
            this.btnHOR_AW_SLIDE.Invalidate();
            this.btnCenter_AW_SLIDE.Invalidate();
        }

        private void btnAW_BLEND_Click(object sender, EventArgs e)
        {

            // Скрываем окно
            this.Hide();
            // Запускаем анимацию. Второй параметр в скобках - время анимации в миллисекундах.
            WinAPIClass.AnimateWindow(this, 3000, WinAPIClass.AnimateWindowFlags.AW_ACTIVATE | WinAPIClass.AnimateWindowFlags.AW_BLEND);
            // Отображаем кнопки после анимации
            this.btnAW_BLEND.Invalidate();
            this.btnHOR_AW_SLIDE.Invalidate();
            this.btnCenter_AW_SLIDE.Invalidate();
        }

        private void btnHOR_AW_SLIDE_Click(object sender, EventArgs e)
        {
            this.Hide();
            WinAPIClass.AnimateWindow(this, 3000, WinAPIClass.AnimateWindowFlags.AW_HOR_POSITIVE | WinAPIClass.AnimateWindowFlags.AW_SLIDE);
            this.btnAW_BLEND.Invalidate();
            this.btnHOR_AW_SLIDE.Invalidate();
            this.btnCenter_AW_SLIDE.Invalidate();

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
             openFileDialog1.Filter = "dañnLI pdf | * .pdf";
            openFileDialog1.ShowDialog(); 
            axAcroPDF1.LoadFile(openFileDialog1.FileName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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


        private delegate int AsyncSumm(int a, int b);
        private int Summ(int a, int b)
        {

            System.Threading.Thread.Sleep(3000);
            System.Threading.Thread.Sleep(9000);
            return a + b;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            int a, b;

            try
            {
                a = Int32.Parse(txbA.Text);
                b = Int32.Parse(txbB.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("При выполнении преобразования типов возникла ошибка");
                txbA.Text = txbB.Text = "";
                return;
            }

            AsyncSumm summdelegate = new AsyncSumm(Summ);
            AsyncCallback cb = new AsyncCallback(CallBackMethod);
            summdelegate.BeginInvoke(a, b, cb, summdelegate);
        }

        private void CallBackMethod(IAsyncResult ar)
        {
            string str;
            AsyncSumm summdelegate = (AsyncSumm)ar.AsyncState;
            str = String.Format("Сумма введенных чисел равна {0}", summdelegate.EndInvoke(ar));
            MessageBox.Show(str, "Результат операции");
        }

        private void btnWork_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работа кипит!!!");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);

        }
    }
}

