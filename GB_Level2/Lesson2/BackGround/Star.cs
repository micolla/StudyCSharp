using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2.AbstractClasses;

namespace Level2.BackGround
{
    class Star:BaseObject
    {
        int blinkedIter;
        bool hasBlinked;
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            this.blinkedIter = 0;
            this.hasBlinked = size.Width % 2 == 0 ? false : true;
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
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, base._rect.X, base._rect.Y, base._rect.X + base._rect.Width, base._rect.Y + base._rect.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, base._rect.X + base._rect.Width, base._rect.Y, base._rect.X, base._rect.Y + base._rect.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, base._rect.X, base._rect.Y + base._rect.Height / 2, base._rect.X + base._rect.Width, base._rect.Y + base._rect.Height/2);
            Game.Buffer.Graphics.DrawLine(Pens.White, base._rect.X + base._rect.Width / 2, base._rect.Y, base._rect.X + base._rect.Width / 2, base._rect.Y + base._rect.Height);
        }
        /// <summary>
        /// Изменение положение и мерцание
        /// </summary>
        public override void Update()
        {
            base._rect.X -= Dir.X;
            base._rect.Y -= Dir.Y;
            base.ReturnOnScreen();
            if (!hasBlinked)
            {
                Blink(1);
                blinkedIter++;
                hasBlinked = blinkedIter <= 2 ? false : true;
            }
            else if(hasBlinked)
            {
                Blink(-1);
                blinkedIter--;
                hasBlinked = blinkedIter > 0 ? true : false;
            }
        }
    }
}
