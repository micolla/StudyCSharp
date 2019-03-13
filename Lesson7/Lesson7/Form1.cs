using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

///Донцов Николай
/// <summary>
/// а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
//б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.Игрок должен получить это число за минимальное количество ходов.
///в) * Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте  библиотечный обобщенный класс System.Collections.Generic.Stack<int> Stack.
///Вся логика игры должна быть реализована в классе с удвоителем.
/// </summary>
namespace Lesson7
{
    public partial class Form1 : Form
    {
        Counter c;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string s1 = lbCommand.Text, s2 = lbNumber.Text;
            c.Add(ref s1,ref s2);
            lbCommand.Text = s1;
            lbNumber.Text = s2;
            if (c.CheckResult() == -1)
                Loose();
            else if (c.CheckResult() == 1)
                Win();
        }

        private void btnSqr_Click(object sender, EventArgs e)
        {
            string s1 = lbCommand.Text, s2 = lbNumber.Text;
            c.Multi(ref s1, ref s2);
            lbCommand.Text = s1;
            lbNumber.Text = s2;
            if (c.CheckResult() == -1)
                Loose();
            else if (c.CheckResult() == 1)
                Win();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string s1 = lbCommand.Text, s2 = lbNumber.Text,s3 = lbUnknown.Text;
            c.Reset(ref s1, ref s2,ref s3);
            lbCommand.Text = s1;
            lbNumber.Text = s2;
            lbUnknown.Text = s3;
        }

        private void GameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            c = new Counter();
            lbUnknown.Text = c.finalNumber;
            btnSqr.Enabled=btnReset.Enabled = btnAdd.Enabled=btnCancel.Enabled = true;
        }
        /// <summary>
        /// Действия при победе
        /// </summary>
        private void Win()
        {
            MessageBox.Show($"Вы выиграли за {c.commandCount} команд");
            FinishGame();
        }
        /// <summary>
        /// Действия при проигрыше
        /// </summary>
        private void Loose()
        {
            MessageBox.Show($"Вы перебрали на {c.difference} и использовали {c.commandCount} команд");
            FinishGame();
        }
        /// <summary>
        /// Отключение кнопок при окончании игры
        /// </summary>
        private void FinishGame()
        {
            btnSqr.Enabled = btnReset.Enabled = btnAdd.Enabled = btnCancel.Enabled = false;
        }
        /// <summary>
        /// Кнопка отмены
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            string s1 = lbCommand.Text, s2 = lbNumber.Text;
            c.Revert(ref s1, ref s2);
            lbCommand.Text = s1;
            lbNumber.Text = s2;
        }
    }
}
