using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level2_Lesson2.GameObjects.BackgroundClasses
{
    class Star:AbstractClasses.BackGroundObject
    {
        private readonly int blinkfrequency;
        private int blinkedIter;
        private bool hasBlinked;

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            this.blinkedIter = 0;
            this.hasBlinked = size.Width % 2 == 0 ? false : true;
            this.blinkfrequency = new Random(size.Height).Next(3, 25);
        }
        /// <summary>
        /// Мерцание звезды
        /// </summary>
        /// <param name="brightness">Величина изменения размера(яркости)</param>
        public void Blink(int brightness)
        {
            base.ChangeSize(brightness);
        }
        /// <summary>
        /// Отрисовка звезды в виде текстовой звездочки
        /// </summary>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.DrawLine(Pens.White, base.Rect.X, base.Rect.Y, base.Rect.X + base.Rect.Width, base.Rect.Y + base.Rect.Height);
            b.Graphics.DrawLine(Pens.White, base.Rect.X + base.Rect.Width, base.Rect.Y, base.Rect.X, base.Rect.Y + base.Rect.Height);
            b.Graphics.DrawLine(Pens.White, base.Rect.X, base.Rect.Y + base.Rect.Height / 2, base.Rect.X + base.Rect.Width, base.Rect.Y + base.Rect.Height / 2);
            b.Graphics.DrawLine(Pens.White, base.Rect.X + base.Rect.Width / 2, base.Rect.Y, base.Rect.X + base.Rect.Width / 2, base.Rect.Y + base.Rect.Height);
        }
        /// <summary>
        /// Изменение положение и мерцание
        /// </summary>
        public override void Update()
        {
            base.Move(-this.dir.X, -this.dir.Y);
            base.ReturnOnScreen();
            if (blinkedIter == blinkfrequency)
            {
                hasBlinked = false;
                Blink(-1);
                blinkedIter--;
            }
            else if (blinkedIter == 0)
            {
                hasBlinked = true;
                Blink(1);
                blinkedIter++;
            }
            else if(blinkedIter < blinkfrequency&& !hasBlinked)
            {
                blinkedIter--;
            }
            else
            {
                blinkedIter++;
            }
        }
    }
}