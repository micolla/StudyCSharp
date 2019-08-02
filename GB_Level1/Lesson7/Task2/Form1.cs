using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Донцов Николай
/// <summary>
/// Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток. Компьютер говорит, больше или меньше загаданное число введенного.  
///a) Для ввода данных от человека используется элемент TextBox;
/// </summary>
namespace Task2
{
    public partial class Form1 : Form
    {
        int numb;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Visible = false;
            Random r = new Random();
            numb = r.Next(1, 100);
            textBox1.Visible = btnCheck.Visible = true;
            label1.Text = "Угадайте число от 1 до 100";
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int userNumber;
            if(int.TryParse(textBox1.Text,out userNumber))
            {
                if (numb == userNumber)
                {
                    label1.Text = "Вы угадали";
                }
                else if (numb < userNumber)
                {
                    label1.Text = "Необходимо ввести меньшее число";
                }
                else if (numb > userNumber)
                {
                    label1.Text = "Необходимо ввести большее число";
                }
            }
            else
                MessageBox.Show("Введите целое число");
            
        }
    }
}
