using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Level2_Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form
            {
                Width = 800,//Screen.PrimaryScreen.Bounds.Width,
                Height = 600//Screen.PrimaryScreen.Bounds.Height
            };
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}
