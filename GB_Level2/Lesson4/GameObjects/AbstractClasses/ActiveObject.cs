using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2_Lesson2.GameObjects.Interfaces;

namespace Level2_Lesson2.GameObjects.AbstractClasses
{
    abstract class ActiveObject: BaseObject, ICollision
    {
        public event Action<String> LogAction;
        private int power;
        public ActiveObject(Point pos, Size size) : base(pos, size)
        {
            power = 1;
        }
        public int Power { get =>power; protected set=> power=value; }
        /// <summary>
        /// Return true if two objects are intersected
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public virtual void Collision(ICollision obj)
        {
            bool value = this.Rect.IntersectsWith(obj.Rect);
            if (value)
            {
                this.Distruct(obj.Power);
                obj.Distruct(this.Power);
                WriteLog($"Столкновение:{this.GetType().Name} и {obj.GetType().Name}");
            }
        }
        public abstract void Distruct(int power);
        protected void WriteLog(string msg)
        {
            LogAction?.Invoke(msg);
        }

    }
}
