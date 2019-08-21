using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using Level2.AbstractClasses;

namespace Level2.ActiveObjects
{
    class Asteroid : BaseObject
    {
        int spinSpeed;
        int iterSpin;
        public int Power { get; private set; }
        public event Action<Asteroid> AsteroidOutOfSpace;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            spinSpeed = 4;
            iterSpin = 0;
            this.Power = 1;
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
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.SaddleBrown, base._rect.X, base._rect.Y, base._rect.Width, base._rect.Height);            
        }
        /// <summary>
        /// Изменение положения астероида и вращение
        /// </summary>
        public override void Update()
        {
            base._rect.X -= base.Dir.X;
            base._rect.Y -= base.Dir.Y;
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
