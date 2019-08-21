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
            base._rect.Width += brightness;
            base._rect.Height += brightness;
        }
        /// <summary>
        /// Отрисовка звезды в виде текстовой звездочки
        /// </summary>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.DrawLine(Pens.White, base._rect.X, base._rect.Y, base._rect.X + base._rect.Width, base._rect.Y + base._rect.Height);
            b.Graphics.DrawLine(Pens.White, base._rect.X + base._rect.Width, base._rect.Y, base._rect.X, base._rect.Y + base._rect.Height);
            b.Graphics.DrawLine(Pens.White, base._rect.X, base._rect.Y + base._rect.Height / 2, base._rect.X + base._rect.Width, base._rect.Y + base._rect.Height / 2);
            b.Graphics.DrawLine(Pens.White, base._rect.X + base._rect.Width / 2, base._rect.Y, base._rect.X + base._rect.Width / 2, base._rect.Y + base._rect.Height);
        }
        /// <summary>
        /// Изменение положение и мерцание
        /// </summary>
        public override void Update()
        {
            base._rect.X -= dir.X;
            base._rect.Y -= dir.Y;
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