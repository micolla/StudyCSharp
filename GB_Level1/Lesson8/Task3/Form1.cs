using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BelieveOrNotBelieve;

namespace Task3
{
    //Донцов Николай
    //а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок (не создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
    //б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение.
    //в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
    //г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).

    public partial class Form1 : Form
    {
        TrueFalse database;
        public Form1()
        {
            InitializeComponent();
        }
        // Обработчик пункта меню Exit
        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Обработчик пункта меню New
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                DatabaseSettings(sfd.FileName);
                btnAdd.Enabled = true;
            };
        }
        //Активация пунктов меню
        void TurnOnBtns()
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                panel1.Controls[i].Enabled = true;
            }
            tboxQuestion.Enabled = true;
        }
        void TurnOffBtns()
        {
            for (int i = 0; i < panel1.Controls.Count; i++)
            {
                panel1.Controls[i].Enabled = false;
            }
            tboxQuestion.Enabled = false;
            btnAdd.Enabled = true;
        }
        // Обработчик события изменения значения numericUpDown
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            if((int)nudNumber.Value - 1 >= 0)
            {
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            }
        }
        // Обработчик кнопки Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count).ToString(), cboxTrue.Checked);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }
        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database == null) return;
            database.Remove((int)nudNumber.Value-1);
            nudNumber.Maximum--;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
        }
        // Обработчик пункта меню Save
        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("База данных не создана");
        }
        // Обработчик пункта меню Open
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DatabaseSettings(ofd.FileName);
                database.Load();
                nudNumber.Value = 1;
                nudNumber.Maximum = database.Count;
            }
        }

        private void DatabaseSettings(string filePath)
        {
            database = new TrueFalse(filePath);
            database.onEmptyQuestion += TurnOffBtns;
            database.onFirstAddQuestion += TurnOnBtns;
        }

        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            if (database.Count==0|| database.Count < (int)nudNumber.Value)
            {
                MessageBox.Show("Сначала нужно нажать Добавить");
                return;
            }
            database[(int)nudNumber.Value-1].text = tboxQuestion.Text;
            database[(int)nudNumber.Value-1].trueFalse = cboxTrue.Checked;
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            fAbout fA = new fAbout();
            fA.ShowDialog();
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (database != null) database.Save(sfd.FileName);
                else MessageBox.Show("База данных не создана");
            }
        }
    }
//private void 
}