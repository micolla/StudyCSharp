using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2_Lesson2.GameObjects.AbstractClasses;

namespace Level2_Lesson2.GameObjects.ActiveObjects
{
    class Asteroid : ActiveObject
    {
        int spinSpeed;
        int iterSpin;
        Point dir;
        public int Power { get; private set; }
        public event Action<Asteroid> AsteroidOutOfSpace;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, size)
        {
            spinSpeed = 4;
            iterSpin = 0;
            this.Power = 1;
            this.dir = dir;
        }
        /// <summary>
        /// Вращение астероида
        /// </summary>
        private void Spin()
        {
            base._rect.Width ^= base._rect.Height;
            base._rect.Height ^= base._rect.Width;
            base._rect.Width ^= base._rect.Height;
        }
        /// <summary>
        /// Отрисовка астероида
        /// </summary>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.FillEllipse(Brushes.SaddleBrown, base._rect.X, base._rect.Y, base._rect.Width, base._rect.Height);
        }
        /// <summary>
        /// Изменение положения астероида и вращение
        /// </summary>
        public override void Update()
        {
            base._rect.X -= this.dir.X;
            base._rect.Y -= this.dir.Y;
            if (++iterSpin == spinSpeed)
            {
                Spin();
                iterSpin = 0;
            }
            base.ReturnOnScreen();
            if ((base._rect.X < 0 || base._rect.X > Game.Width || base._rect.Y < 0 || base._rect.Y > Game.Height) && AsteroidOutOfSpace != null)
                AsteroidOutOfSpace(this);
        }
        /// <summary>
        /// Метод для возобновления в базовом месте
        /// </summary>
        public void Reset()
        {
            base._rect.X = Game.Width - base._rect.Width;
            base._rect.Y = Game.Height / 2;
        }
    }
}
