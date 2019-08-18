using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level2.BackGround
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public virtual void Update()
        {
            Pos.X += Dir.X;
            Pos.Y += Dir.Y;
            this.ReturnOnScreen();
        }
        protected void ReturnOnScreen()
        {
            if (Pos.X < 0) Pos.X = Game.Width - Size.Width;
            else if (Pos.X > Game.Width) Pos.X = Size.Width;
            if (Pos.Y < 0) Pos.Y = Game.Height - Size.Height;
            else if (Pos.Y > Game.Height) Pos.Y = Size.Height;
        }
    }

}
