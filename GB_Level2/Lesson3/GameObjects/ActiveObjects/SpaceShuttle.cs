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
    class SpaceShuttle : ActiveObject
    {
        Image img_src;
        private int power;

        public SpaceShuttle(Point pos, Size size, Image img) : base(pos, size)
        {
            img_src = img;
            power = 5;
        }
        /// <summary>
        /// Отрисовка шатла с помощью изображения
        /// </summary>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.DrawImage(this.img_src, base._rect.X, base._rect.Y, base._rect.Width, base._rect.Height);
        }
        /// <summary>
        /// Перемещения Шатала по заданному направлению
        /// </summary>
        public override void Update()
        {
            //Move(base.Dir.X, base.Dir.Y);
            //base.ReturnOnScreen();
        }
        /// <summary>
        /// Перемещение шатла на заданное растояние
        /// </summary>
        /// <param name="moveX">отклонение по оси Х</param>
        /// <param name="moveY">отклонение по оси Y</param>
        public void Move(int moveX, int moveY)
        {
            base._rect.X += moveX;
            base._rect.Y += moveY;
        }
        /// <summary>
        /// Заглушка для стрельбы шатлом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public Bullet Shoot()
        {
            return new Bullet(new Point(base.Rect.X+ base.Rect.Width, base.Rect.Y + base.Rect.Height/2),this.power,new Size(4,2));
        }
    }
}
