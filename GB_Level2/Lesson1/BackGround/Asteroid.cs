using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace Level2.BackGround
{
    class Asteroid : BaseObject
    {
        int spinSpeed;
        int iterSpin;
        public event Action<Asteroid> AsteroidOutOfSpace;
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size){ spinSpeed = 4; iterSpin = 0; }

        private void Spin()
        {
            Size.Width = Size.Height ^ Size.Width;
            Size.Height = Size.Width ^ Size.Height;
            Size.Width = Size.Width ^ Size.Height;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(new Pen(Color.Brown,5), Pos.X, Pos.Y, Size.Width, Size.Height);            
        }
        public override void Update()
        {
            base.Pos.X -= base.Dir.X;
            base.Pos.Y -= base.Dir.Y;
            if (++iterSpin == spinSpeed)
            {
                Spin();
                iterSpin = 0;
            }
            base.ReturnOnScreen();
            if ((Pos.X < 0 || Pos.X > Game.Width || Pos.Y < 0 || Pos.Y > Game.Height) && AsteroidOutOfSpace != null)
                AsteroidOutOfSpace(this);    
        }
    }
}
