using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2.AbstractClasses;

namespace Level2.ActiveObjects
{
    class SpaceShuttle:BaseObject
    {
        Image img_src;
        public SpaceShuttle(Point pos, Point dir, Size size,Image img) : base(pos, dir, size)
        {
            img_src = img;
        }
        /// <summary>
        /// Отрисовка шатла с помощью изображения
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(this.img_src, base._rect.X, base._rect.Y, base._rect.Width, base._rect.Height);
        }
        /// <summary>
        /// Перемещения Шатала по заданному направлению
        /// </summary>
        public override void Update()
        {
            Move(base.Dir.X, base.Dir.Y);   
            base.ReturnOnScreen();
        }
        /// <summary>
        /// Метод для управление движением шатла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MoveShuttle(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Up:
                    this.Move(0, -1);
                    break;
                case System.Windows.Forms.Keys.Down:
                    this.Move(0, 1);
                    break;
                case System.Windows.Forms.Keys.Left:
                    this.Move(-1, 0);
                    break;
                case System.Windows.Forms.Keys.Right:
                    this.Move(1, 0);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Перемещение шатла на заданное растояние
        /// </summary>
        /// <param name="moveX">отклонение по оси Х</param>
        /// <param name="moveY">отклонение по оси Y</param>
        private void Move(int moveX,int moveY)
        {
            base._rect.X += moveX;
            base._rect.Y += moveY;
        }
        /// <summary>
        /// Заглушка для стрельбы шатлом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Shoot(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
