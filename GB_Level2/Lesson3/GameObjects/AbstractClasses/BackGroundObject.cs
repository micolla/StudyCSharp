using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2_Lesson2;

namespace Level2_Lesson2.GameObjects.AbstractClasses
{
    abstract class BackGroundObject : BaseObject
    {
        public event Action<Rectangle> BackgroundMoved;
        protected Point dir;
        public BackGroundObject(Point pos,Point dir, Size size):base(pos,size)
        {
            this.dir = dir;
        }
        protected void Move()
        {
            BackgroundMoved?.Invoke(base.Rect);
        }
    }
}
