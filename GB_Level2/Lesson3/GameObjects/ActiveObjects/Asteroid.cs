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
        private readonly int spinSpeed;
        private int iterSpin;
        Point dir;
        public event Action<Asteroid> AsteroidOutOfSpace;
        public event EventHandler AsteroidExploded;

        public Asteroid(Point pos, Point dir, Size size,int powerAsteroid) : base(pos, size)
        {
            spinSpeed = 4;
            iterSpin = 0;
            this.dir = dir;
            base.Power = powerAsteroid;
        }
        /// <summary>
        /// Вращение астероида
        /// </summary>
        private void Spin()
        {
            base.SwapSize();
        }
        /// <summary>
        /// Отрисовка астероида
        /// </summary>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.FillEllipse(Brushes.SaddleBrown, base.Rect.X, base.Rect.Y, base.Rect.Width, base.Rect.Height);
        }
        /// <summary>
        /// Изменение положения астероида и вращение
        /// </summary>
        public override void Update()
        {
            base.Move(-this.dir.X, -this.dir.Y);
            if (++iterSpin == spinSpeed)
            {
                Spin();
                iterSpin = 0;
            }
            /*if ((base._rect.X < 0 || base._rect.X > Game.Width || base._rect.Y < 0 || base._rect.Y > Game.Height) && AsteroidOutOfSpace != null)
                AsteroidOutOfSpace(this);*/
        }
        public override void Distruct(int power)
        {
            Power-=power;
            if (Power <= 0)
            {
                AsteroidExploded?.Invoke(this, new EventArgs());
                base.WriteLog($"AsteroidExploded:{Rect.X},{Rect.Y}");
                base.ReturnOnScreen();
            }
        }

    }
}
