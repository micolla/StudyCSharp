using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Level2.AbstractClasses;
using System.Drawing;

namespace Level2.ActiveObjects
{
    class Bullet:BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        /// <summary>
        /// Отрисовка пули в виде прямоугольника
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, base._rect.X, base._rect.Y, base._rect.Width, base._rect.Height);
        }
        /// <summary>
        /// движение пули 
        /// </summary>
        public override void Update()
        {
            base._rect.X += Dir.X;
            base.ReturnOnScreen();
        }
        /// <summary>
        /// Метод для возобновления в базовом месте
        /// </summary>
        public void Reset()
        {
            base._rect.X = 25;
            base._rect.Y = Game.Height / 2;
        }
    }
}
