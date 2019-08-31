using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2_Lesson2.GameObjects.AbstractClasses;
using Level2_Lesson2.GameObjects.ActiveObjects;

namespace Level2_Lesson2.GameObjects.ActiveObjects
{
    class AidKit : ActiveObject
    {
        public event Action<AidKit> AidGot;
        public AidKit(Point pos, Size size) : base(pos, size)
        {
            Power = -25;//Отрицательное для восстановления здоровья
        }
        public AidKit(Point pos, Size size,int aidHealth) : base(pos, size)
        {
            Power = -aidHealth;//Отрицательное для восстановления здоровья
        }

        public override void Distruct(int power)
        {
            AidGot?.Invoke(this);
        }
        /// <summary>
        /// Рисуем кружок с крестиком и мощностью аптечки
        /// </summary>
        /// <param name="b"></param>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.DrawEllipse(Pens.Red, base.Rect.X, base.Rect.Y, base.Rect.Width, base.Rect.Height);
            b.Graphics.DrawLine(Pens.Red, base.Rect.X + base.Rect.Width / 2, base.Rect.Y, base.Rect.X + base.Rect.Width / 2, base.Rect.Y + base.Rect.Height);
            b.Graphics.DrawLine(Pens.Red, base.Rect.X, base.Rect.Y + base.Rect.Height / 2, base.Rect.X + base.Rect.Width, base.Rect.Y + base.Rect.Height / 2);
            b.Graphics.DrawString($"+{-this.Power}", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline), Brushes.Red, base.Rect.X, base.Rect.Y-8);
        }
        /// <summary>
        /// Не реализовано
        /// </summary>
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
