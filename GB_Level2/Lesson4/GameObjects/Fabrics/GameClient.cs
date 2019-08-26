using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Level2_Lesson2.GameObjects.ActiveObjects;
using Level2_Lesson2.GameObjects.AbstractClasses;

namespace Level2_Lesson2.GameObjects.Fabrics
{
    class GameClient
    {
        /// <summary>
        /// Cписок объектов фона
        /// </summary>
        private List<BackGroundObject> _backGroundObjects;
        /// <summary>
        /// Список объектов с возможностью взаимодействия
        /// </summary>
        private List<ActiveObject> _activeObjects;
        /// <summary>
        /// Корабль игрока
        /// </summary>
        private SpaceShuttle _shuttle;
        /// <summary>
        /// Аптечка
        /// </summary>
        private Stack<AidKit> _aidsClip;
        private AidKit _aid;

        public event Action<int> GameScoreChange;
        public event Action<string> GameClientLog;
        public event Action GameOverEvent;
        public GameClient(AbstractGameFactory factory,int fieldWidth,int fieldHeight)
        {
            _shuttle= factory.CreateShuttle(fieldHeight);
            _activeObjects = factory.MakeActiveObjects(fieldWidth, fieldHeight);
            _aidsClip = factory.MakeAidKit();
            _backGroundObjects = factory.MakeStarSky(fieldWidth,fieldHeight);
            _aid = null;
            SubcribeAllEvents();
        }
        /// <summary>
        /// В случае взятия аптечки прячим её до следующего раза
        /// </summary>
        /// <param name="obj">Аптечка, которую поймали</param>
        private void AidCatched(AidKit obj)
        {
            _aidsClip.Push(obj);
            _aid = null;
        }

        public void MoveShuttle(int moveX, int moveY,int fieldWidth,int fieldHeight)
        {
            if (_shuttle.Rect.Y + moveY + _shuttle.Rect.Height > fieldHeight)
                moveY = fieldHeight - _shuttle.Rect.Height - _shuttle.Rect.Y;
            else if (_shuttle.Rect.Y + moveY < 0)
                moveY = 0;
            if (_shuttle.Rect.X + moveX + _shuttle.Rect.Width > fieldWidth)
                moveX = fieldWidth - _shuttle.Rect.Width - _shuttle.Rect.X;
            else if (_shuttle.Rect.X + moveX < 0)
                moveX = 0;
            _shuttle.MoveShuttle(moveX, moveY);
        }
        public void ShuttleShoot()
        {
            _shuttle.Shoot();
        }
        /// <summary>
        /// Вызов методов для изменения состояния игорвых объектов
        /// </summary>
        public void Update()
        {
            _shuttle.Update();
            if (_aid != null)
                _shuttle.Collision(_aid);
            foreach (BackGroundObject obj in _backGroundObjects)
                obj.Update();
            for (int a = 0; a < _activeObjects.Count; a++)
            {
                if (_activeObjects[a] != null)
                {
                    _activeObjects[a].Update();
                    _shuttle.Collision(_activeObjects[a]);
                }
            }
            _activeObjects.Remove(null);
            if (_shuttle.Health < 50 && _aidsClip.Count > 0 && _aid == null)
                _aid = _aidsClip.Pop();
        }

        /// <summary>
        /// Прорисовка всех объектов в игре
        /// </summary>
        public void Draw(BufferedGraphics b)
        {
            _shuttle?.Draw(b);
            foreach (BaseObject obj in _backGroundObjects)
                obj?.Draw(b);
            foreach (BaseObject obj in _activeObjects)
                obj?.Draw(b);
            _aid?.Draw(b);
            b.Graphics.DrawString($"ShuttleHealth {_shuttle.Health}", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline), Brushes.White, 1, 1);
            b.Graphics.DrawString($"ShuttleEnergy {_shuttle.Energy}", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline), Brushes.White, 1, 15);
        }
        /// <summary>
        /// Подписаться на игровые логи
        /// </summary>
        /// <param name="logmethod">делигат с типов Action<string></param>
        private void SubcribeAllEvents()
        {
            foreach (var item in this._activeObjects)
            {
                item.LogAction += GetLog;
                if (item is Asteroid)
                {
                    (item as Asteroid).AsteroidHit += this.AsteroidHit;
                    (item as Asteroid).AsteroidExploded += this.AsteroidHit;
                }
            }
            _shuttle.LogAction += GetLog;
            _shuttle.ShuttleDieEvent += GameOver;
            foreach (AidKit aid in _aidsClip)
            {
                aid.AidGot += AidCatched;
            }
        }
        /// <summary>
        /// Подсчет очков при сбитии астероида
        /// </summary>
        /// <param name="ast">Астероид</param>
        /// <param name="score">количество очков за негоы</param>
        private void AsteroidHit(Asteroid ast, int score)
        {
            GetLog($"GameScore: +{score}");
            this.GameScoreChange?.Invoke(score);
        }
        private void GetLog(string msg)
        {
            this.GameClientLog?.Invoke(msg);
        }
        private void GameOver()
        {
            this.GameOverEvent?.Invoke();
        }
    }
}
