using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2_Lesson2.GameObjects.AbstractClasses;
using Level2_Lesson2.GameObjects.Interfaces;

namespace Level2_Lesson2.GameObjects.ActiveObjects
{
    enum BulletPower
    {
        Simple=1,PowerFull=5
    };
    enum BulletSpeed
    {
        Simple=5, Fast=10
    };
    class Bullet:ActiveObject
    {
        public event EventHandler BulletIsOut;
        private int speed;
        public Bullet(Point pos, BulletSpeed bulletSpeed,Size size) : base(pos, size)
        {
            this.speed = (int)bulletSpeed;
            this.Power = (int)BulletPower.Simple;
        }
        public Bullet(Point pos, BulletSpeed bulletSpeed,BulletPower bulletPower, Size size) : base(pos, size)
        {
            this.speed = (int)bulletSpeed;
            this.Power = (int)bulletPower;
        }
        /// <summary>
        /// Отрисовка пули в виде прямоугольника
        /// </summary>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.DrawRectangle(Pens.OrangeRed, base.Rect.X, base.Rect.Y, base.Rect.Width, base.Rect.Height);
        }
        /// <summary>
        /// движение пули 
        /// </summary>
        public override void Update()
        {
            base.Move(this.speed, 0);
            if (Rect.X < 0 || Rect.X > Game.Width || Rect.Y < 0 || Rect.Y > Game.Height)
                Distruct();
        }
        internal void ChangeLocation(int x,int y)
        {
            base.Rect = new Rectangle(x,y,base.Rect.Width,base.Rect.Height);
        }
        internal void ChangePower(BulletPower bulletPower)
        {
            this.Power = (int)bulletPower;
        }
        internal void ChangeSpeed(BulletSpeed bulletSpeed)
        {
            this.speed = (int)bulletSpeed;
        }
        internal void ChangePowerSpeed(BulletSpeed bulletSpeed, BulletPower bulletPower)
        {
            ChangeSpeed(bulletSpeed);
            ChangePower(bulletPower);
        }
        /// <summary>
        /// Вызввать обработчик 
        /// </summary>
        /// <param name="power">Мощность вражеского объекта</param>
        public override void Distruct(int power)
        {
            BulletIsOut?.Invoke(this, new EventArgs());
        }
        public void Distruct()
        {
            BulletIsOut?.Invoke(this, new EventArgs());
        }
    }
}
