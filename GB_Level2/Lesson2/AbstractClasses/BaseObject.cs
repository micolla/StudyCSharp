using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2.Interface;

namespace Level2.AbstractClasses
{
    abstract class BaseObject: ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public Rectangle Rect { get; set; }
        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
            Rect = new Rectangle(pos, size);
        }
        public abstract void Draw();
        public abstract void Update();
        protected void ReturnOnScreen()
        {
            if (Pos.X < 0) Pos.X = Game.Width - Size.Width;
            else if (Pos.X > Game.Width) Pos.X = Size.Width;
            if (Pos.Y < 0) Pos.Y = Game.Height - Size.Height;
            else if (Pos.Y > Game.Height) Pos.Y = Size.Height;
        }
        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
    }

}
