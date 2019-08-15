using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level2.BackGround
{
    class Star:BaseObject
    {
        int blinkedIter;
        bool hasBlinked;
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            this.blinkedIter = 0;
            this.hasBlinked = false;
        }

        public void Blink(int brightness)
        {
            base.Size.Width += brightness;
            base.Size.Height += brightness;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }
        public override void Update()
        {
            Pos.X -= Dir.X;
            Pos.Y -= Dir.Y;
            base.ReturnOnScreen();
            if (!hasBlinked)
            {
                Blink(1);
                blinkedIter++;
                hasBlinked = blinkedIter <= 2 ? false : true;
            }
            else if(hasBlinked)
            {
                Blink(-1);
                blinkedIter--;
                hasBlinked = blinkedIter > 0 ? true : false;
            }
        }
    }
}
