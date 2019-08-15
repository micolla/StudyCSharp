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

        public void MoveShuttle(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Up)
                this.Move(0,-1);
            else if (e.KeyCode == System.Windows.Forms.Keys.Down)
                this.Move(0, 1);
            else if (e.KeyCode == System.Windows.Forms.Keys.Left)
                this.Move(-1, 0);
            else if (e.KeyCode == System.Windows.Forms.Keys.Right)
                this.Move(1, 0);
        }
        
        private void Move(int moveX,int moveY)
        {
            base.Pos.X += moveX;
            base.Pos.Y += moveY;
        }

    }


}
