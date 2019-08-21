using System;
using System.Drawing;

namespace Level2_Lesson2.GameObjects.Interfaces
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
}
