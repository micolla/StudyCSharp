using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Level2_Lesson2.GameObjects.AbstractClasses;
using Level2_Lesson2.GameObjects.BackgroundClasses;
using Level2_Lesson2.GameObjects.ActiveObjects;

namespace Level2_Lesson2
{
    static class Game
    {
        #region VariablesDesctiption
        private static BufferedGraphicsContext _context;
        private static BufferedGraphics Buffer;
        /// <summary>
        /// высота игрового поля
        /// </summary>
        public static int Width { get; set; }
        /// <summary>
        /// Ширина игрового поля
        /// </summary>
        public static int Height { get; set; }
        /// <summary>
        /// Cписок объектов фона
        /// </summary>
        private static List<BackGroundObject> _backGroundObjects;
        /// <summary>
        /// Список пуль
        /// </summary>
        private static List<Bullet> _bullets;
        /// <summary>
        /// Список объектов с возможностью взаимодействия
        /// </summary>
        private static List<ActiveObject> _activeObjects;
        /// <summary>
        /// Корабль игрока
        /// </summary>
        private static SpaceShuttle _shuttle;
        /// <summary>
        /// Таймер для управления игровым циклом
        /// </summary>
        private static Timer timer;
        private static int gameScore;

        #endregion
        /// <summary>
        /// Инициализация игры Game
        /// </summary>
        /// <param name="form">Форма для связывания с игрой</param>
        public static void Init(Form form)
        {
            CheckWindowSize(form);
            Graphics g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            _context = BufferedGraphicsManager.Current;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            _backGroundObjects = new List<BackGroundObject>();
            _bullets = new List<Bullet>();
            _activeObjects = new List<ActiveObject>();
            gameScore = 0;
            MakeStarSky(_backGroundObjects);
            MakeAsteroids(_activeObjects);
            _shuttle = CreateShuttle();
            form.KeyDown += ControlKeyDown;
            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            form.ResizeEnd += Form_SizeChanged;
        }

        private static void ControlKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Up:
                    _shuttle.MoveShuttle(0, -15);
                    break;
                case System.Windows.Forms.Keys.Down:
                    _shuttle.MoveShuttle(0, 15);
                    break;
                case System.Windows.Forms.Keys.Left:
                    _shuttle.MoveShuttle(-15, 0);
                    break;
                case System.Windows.Forms.Keys.Right:
                    _shuttle.MoveShuttle(15, 0);
                    break;
                case System.Windows.Forms.Keys.Space:
                    Bullet tmp = _shuttle.Shoot();
                    if (tmp != null)
                    {
                        tmp.BulletIsOut += HideBullet;
                        _bullets.Add(tmp);
                    }
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Убрать пулю из списка обновления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void HideBullet(object sender, EventArgs e)
        {
            _bullets[_bullets.IndexOf(sender as Bullet)] = null;
            (sender as Bullet).BulletIsOut -= HideBullet;
        }

        /// <summary>
        /// Проверка размеров формы
        /// </summary>
        /// <param name="form"></param>
        private static void CheckWindowSize(Form form)
        {
            if (form.ClientSize.Width > 1000 || form.ClientSize.Height > 1000 || form.ClientSize.Width < 0 || form.ClientSize.Height < 0)
                throw new ArgumentOutOfRangeException("form.ClientSize"
                    , $"Переданы неверные размеры окна {form.ClientSize.Width} и {form.ClientSize.Height}");
        }

        /// <summary>
        /// Перерисовка игрового поля при изменении размера игрового поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Form_SizeChanged(object sender, EventArgs e)
        {
            if (sender is Form)
            {
                CheckWindowSize(sender as Form);
                Width = (sender as Form).ClientSize.Width;
                Height = (sender as Form).ClientSize.Height;
                //_objs.RemoveRange(0, _objs.Count);
                //MakeStarSky();
                //MakeAsteroids();
                //CreateShuttle(sender as Form);
            }

        }

        /// <summary>
        /// Создание звездного движущегося неба
        /// </summary>
        public static void MakeStarSky(List<BackGroundObject> bo)
        {

            int defaultStarSize = 3;
            int cntX, cntY;
            cntX = Width / (defaultStarSize * 21);
            cntY = Height / (defaultStarSize * 25);
            int[] starSizeArray = new int[] { 5, 3, 6, 7, 4 };
            Random rnd = new Random(cntX * cntY);
            int iter;
            for (int i = 0; i < cntX; i++)
            {
                for (int j = 0; j < cntY; j++)
                {
                    iter = rnd.Next(0, starSizeArray.Length - 1);
                    bo.Add(new Star(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height))
                        , new Point(j, 0), new Size(starSizeArray[iter], starSizeArray[iter])));
                }
            }
        }
        /// <summary>
        /// Создание метеоритного дождя
        /// </summary>
        private static void MakeAsteroids(List<ActiveObject> ao)
        {
            Size asteroidSize = new Size(12, 28);
            int cnt = Game.Width * Game.Height / (asteroidSize.Width * asteroidSize.Height * 60);
            Random rnd = new Random(cnt);
            Asteroid tmpAsteroid;
            for (int i = 0; i < cnt; i++)
            {
                tmpAsteroid = new Asteroid(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(6, 1), asteroidSize,rnd.Next(1,14));
                tmpAsteroid.LogAction += ShowLogs;
                tmpAsteroid.AsteroidHit += AsteroidHit;
                ao.Add(tmpAsteroid);
            }
        }

        private static void AsteroidHit(Asteroid ast, int score)
        {
            gameScore += score;
            ShowLogs($"GameScore: {gameScore}");
        }

        /// <summary>
        /// Установка шатла
        /// </summary>
        /// <param name="form">Форма для связи с событием KeyDown</param>
        private static SpaceShuttle CreateShuttle()
        {
            try
            {
                Image img = Image.FromFile(@"img\space_shuttle.jpg");
                SpaceShuttle tmplShuttle = new SpaceShuttle(new Point(5, Game.Height / 2), new Size(25, 25), img);
                tmplShuttle.LogAction += ShowLogs;
                tmplShuttle.ShuttleDieEvent += Finish;
                return tmplShuttle;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new GameObjects.Exceptions.GameObjectException(@"Проверьте наличие файла с картинкой шатла "+e.Message);
            }
        }
        /// <summary>
        /// Прорисовка всех объектов в игре
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            _shuttle?.Draw(Game.Buffer);
            foreach (BaseObject obj in _bullets)
                obj?.Draw(Game.Buffer);
            foreach (BaseObject obj in _backGroundObjects)
                obj?.Draw(Game.Buffer);
            foreach (BaseObject obj in _activeObjects)
                obj?.Draw(Game.Buffer);
            Buffer.Graphics.DrawString($"ShuttleHealth {_shuttle.Health}", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline), Brushes.White, 1, 1);
            Buffer.Graphics.DrawString($"ShuttleEnergy {_shuttle.Energy}", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline), Brushes.White, 1, 15);
            Buffer.Graphics.DrawString($"GameScore {gameScore}", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline), Brushes.White, Game.Width-100, 1);
            Buffer.Render();
        }
        /// <summary>
        /// Вызов методов для изменения состояния игорвых объектов
        /// </summary>
        public static void Update()
        {
            _shuttle.Update();
            for (int i = 0; i < _bullets.Count; i++)
            {
                _bullets[i]?.Update();
            }
            foreach (BaseObject obj in _backGroundObjects)
                obj.Update();
            for (int a = 0; a < _activeObjects.Count; a++)
            {
                if (_activeObjects[a] != null)
                {
                    _activeObjects[a].Update();
                    _shuttle.Collision(_activeObjects[a]);
                    for (int i = 0; i < _bullets.Count; i++)
                    {
                        if (_bullets[i] != null)
                            _bullets[i].Collision(_activeObjects[a]);
                    }
                }
            }
            _bullets.Remove(null);
            _activeObjects.Remove(null);
        }
        /// <summary>
        /// Метод для работы с событиями таймера
        /// </summary>
        /// <param name="sender">Вызывающий объект</param>
        /// <param name="e">Аргументы события</param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Окончание игры
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString("The End", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
        /// <summary>
        /// Вывод логов на экран
        /// </summary>
        /// <param name="msg">Сообщение лога</param>
        public static void ShowLogs(string msg)
        {
            Console.WriteLine(msg);
        }
        
    }
}
