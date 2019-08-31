using System;
using System.Drawing;

namespace Level2_Lesson2.GameObjects.Interfaces
{
    interface ICollision
    {
        void Collision(ICollision obj);
        int Power { get; }
        Rectangle Rect { get; }

        void Distruct(int power);
    }
}
