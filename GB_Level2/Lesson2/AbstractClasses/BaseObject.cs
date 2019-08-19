using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2.Interface;
using Level2.exceptions;

namespace Level2.AbstractClasses
{
    abstract class BaseObject : ICollision
    {
        protected Point Dir;
        protected Rectangle _rect;
        public Rectangle Rect { get { return _rect; } }
        protected BaseObject(Point pos, Point dir, Size size)
        {
            if (pos.X < 0 || pos.Y < 0 || size.Width <= 0 || size.Height <= 0)
                throw new GameObjectException($"{this.GetType().Name} генерируется с отрицательными параметрами");
            Dir = dir;
            _rect = new Rectangle(pos, size);
        }
        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Изменения состояния объекта согласно логике
        /// </summary>
        public abstract void Update();
        /// <summary>
        /// В случае выхода вне игрового поля возврат в базовую позицю
        /// </summary>
        protected void ReturnOnScreen()
        {
            if (_rect.X < 0) _rect.X = Game.Width - _rect.Width;
            else if (_rect.X > Game.Width) _rect.X = _rect.Width;
            if (_rect.Y < 0) _rect.Y = Game.Height - _rect.Height;
            else if (_rect.Y > Game.Height) _rect.Y = _rect.Height;
        }
        /// <summary>
        /// Определение столкновения объектов
        /// </summary>
        /// <param name="obj">Объект для анализа</param>
        /// <returns></returns>
        public bool Collision(ICollision obj)
        {
            return obj.Rect.IntersectsWith(this.Rect);
        }
    }

}
