using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Level2_Lesson2.GameObjects.ActiveObjects;
using Level2_Lesson2.GameObjects.AbstractClasses;

namespace Level2_Lesson2.GameObjects.Fabrics
{
    abstract class AbstractGameFactory
    {
        public abstract List<ActiveObject> MakeActiveObjects(int width, int height);
        public abstract Stack<AidKit> MakeAidKit();
        public abstract SpaceShuttle CreateShuttle(int height);
        public abstract List<BackGroundObject> MakeStarSky(int width, int height);
    }
}
