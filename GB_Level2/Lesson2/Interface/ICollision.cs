
using System.Drawing;

namespace Level2.Interface
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }

    }
}
