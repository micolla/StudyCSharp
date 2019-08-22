using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2_Lesson2.GameObjects.Exceptions;

namespace Level2_Lesson2.GameObjects.AbstractClasses
{
    abstract class BaseObject
    {
        private Rectangle _rect;
        public Rectangle Rect { internal set { _rect = value; } get { return _rect; } }
        public BaseObject(Point pos,Size size)
        {
            if (pos.X < 0 || pos.Y < 0 || size.Width <= 0 || size.Height <= 0)
                throw new GameObjectException($"{this.GetType().Name} генерируется с отрицательными параметрами");
            _rect = new Rectangle(pos, size);
        }
        /// <summary>
        /// Отрисовка объекта
        /// </summary>
        public abstract void Draw(BufferedGraphics b);
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

        protected void SwapSize()
        {
            _rect.Width ^= _rect.Height;
            _rect.Height ^= _rect.Width;
            _rect.Width ^= _rect.Height;
        }

        protected void Move(int delatX,int deltaY)
        {
            _rect.X += delatX;
            _rect.Y += deltaY;
        }
        protected void ChangeSize(int deltaWidth, int deltaHeight)
        {
            _rect.Width += deltaWidth;
            _rect.Y += deltaHeight;
        }
        protected void ChangeSize(int deltaSize)
        {
            _rect.Width += deltaSize;
            _rect.Y += deltaSize;
        }

        /// <summary>
        /// Определение столкновения объектов
        /// </summary>
        /// <param name="obj">Объект для анализа</param>
        /// <returns></returns>
        //public bool Collision(ICollision obj) => obj.Rect.IntersectsWith(this.Rect);
    }

}
