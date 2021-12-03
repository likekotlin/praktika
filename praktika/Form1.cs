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
        }
    }
}
