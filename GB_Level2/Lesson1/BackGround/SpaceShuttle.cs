using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level2.BackGround
{
    class SpaceShuttle:BaseObject
    {
        Image img_src;
        public SpaceShuttle(Point pos, Point dir, Size size,Image img) : base(pos, dir, size)
        {
            img_src = img;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(this.img_src, base.Pos.X, base.Pos.Y, base.Size.Width, base.Size.Height);
        }
        public override void Update()
        {
            base.Pos.X += base.Dir.X;
            base.Pos.Y += base.Dir.Y;   
            base.ReturnOnScreen();
        }
    }


}
