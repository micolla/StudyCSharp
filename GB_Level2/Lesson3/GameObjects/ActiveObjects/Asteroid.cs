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
        public event Action<Asteroid,int> AsteroidHit;
        public event Action<Asteroid, int> AsteroidExploded;
        private readonly int Firstpower;
        public Asteroid(Point pos, Point dir, Size size,int powerAsteroid) : base(pos, size)
        {
            spinSpeed = 4;
            iterSpin = 0;
            this.dir = dir;
            base.Power = powerAsteroid;
            Firstpower = powerAsteroid;
        }
        /// <summary>
        /// Вращение астероида
        /// </summary>
        private void Spin()
        {
            //base.SwapSize();
        }
        /// <summary>
        /// Отрисовка астероида
        /// </summary>
        public override void Draw(BufferedGraphics b)
        {
            b.Graphics.FillEllipse(Brushes.SaddleBrown, base.Rect.X, base.Rect.Y, base.Rect.Width, base.Rect.Height);
            b.Graphics.DrawString($"{Power}", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline)
                , Brushes.White, base.Rect.X, base.Rect.Y+1);
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
            base.ReturnOnScreen();
            /*if ((base._rect.X < 0 || base._rect.X > Game.Width || base._rect.Y < 0 || base._rect.Y > Game.Height) && AsteroidOutOfSpace != null)
                AsteroidOutOfSpace(this);*/
        }
        public override void Distruct(int power)
        {
            if (Power- power <= 0)
            {
                AsteroidExploded?.Invoke(this, Math.Min(power, Power));  
                base.WriteLog($"AsteroidExploded:{Rect.X},{Rect.Y}");
                Reset();
                Power = Firstpower;
            }
            else
                Power -= power;
            AsteroidHit?.Invoke(this, Math.Min(power, Power));
        }

        private void Reset()
        {
            base.Move(-base.Rect.X - 1, -base.Rect.Y - 1);
        }
    }
}
