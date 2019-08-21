using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Level2_Lesson2.GameObjects.AbstractClasses
{
    abstract class ActiveObject:BaseObject
    {
        public ActiveObject(Point pos, Size size) : base(pos, size)
        {
        }
    }
}
