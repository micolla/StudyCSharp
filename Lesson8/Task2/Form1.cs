using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    //Создайте простую форму на котором свяжите свойство Text элемента TextBox со свойством Value элемента NumericUpDown
    //Донцов Николай
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void incremetnor_ValueChanged(object sender, EventArgs e)
        {
            tbLinked.Text = $"{incremetnor.Value:N0}";
        }
    }
}
