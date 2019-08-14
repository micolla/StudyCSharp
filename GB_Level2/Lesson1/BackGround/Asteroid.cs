using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level2.BackGround
{
    class Asteroid : BaseObject
    {
        event Action<Asteroid> AsteroidOutOfSpace;
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X -= Dir.X;
            if ((Pos.X < 0 || Pos.X > Game.Width || Pos.Y < 0 || Pos.Y > Game.Height) && AsteroidOutOfSpace != null)
                AsteroidOutOfSpace(this);
            Pos.X = Game.Width + Size.Width;
            
        }
    }
}
