using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Level2.AbstractClasses;
using System.Drawing;

namespace Level2.ActiveObjects
{
    class Bullet:BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X += Dir.X;
            base.ReturnOnScreen();
        }
        public void Reset()
        {
            this.Pos.X = 25;
            this.Pos.Y = Game.Height / 2;
        }
    }
}
