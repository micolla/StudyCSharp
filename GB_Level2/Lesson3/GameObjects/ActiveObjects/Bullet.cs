using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2_Lesson2.GameObjects.AbstractClasses;

namespace Level2_Lesson2.GameObjects.ActiveObjects
{
    class Bullet:ActiveObject
    {
        private readonly int speed;
        public Bullet(Point pos, int bulletSpeed,Size size) : base(pos, size)
        {
            this.speed = bulletSpeed;
        }
        /// <summary>
        /// Отрисовка пули в виде прямоугольника
        /// </summary>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.DrawRectangle(Pens.OrangeRed, base._rect.X, base._rect.Y, base._rect.Width, base._rect.Height);
        }
        /// <summary>
        /// движение пули 
        /// </summary>
        public override void Update()
        {
            base._rect.X += this.speed;
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
