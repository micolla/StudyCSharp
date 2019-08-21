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
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static List<BackGroundObject> _backGroundObjects;
        public static List<Bullet> _bullets;
        public static List<ActiveObject> _activeObjects;
        public static SpaceShuttle _shuttle;
        private static Timer timer;

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
                    _shuttle.Move(0, -1);
                    break;
                case System.Windows.Forms.Keys.Down:
                    _shuttle.Move(0, 1);
                    break;
                case System.Windows.Forms.Keys.Left:
                    _shuttle.Move(-1, 0);
                    break;
                case System.Windows.Forms.Keys.Right:
                    _shuttle.Move(1, 0);
                    break;
                case System.Windows.Forms.Keys.Space:
                    _bullets.Add(_shuttle.Shoot());
                    break;
                default:
                    break;
            }
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
            int cnt = Game.Width * Game.Height / (asteroidSize.Width * asteroidSize.Height * 35);
            Random rnd = new Random(cnt);
            Asteroid tmpAsteroid;
            for (int i = 0; i < cnt; i++)
            {
                tmpAsteroid = new Asteroid(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(6, 1), asteroidSize);
                ao.Add(tmpAsteroid);
            }
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
                return new SpaceShuttle(new Point(5, Game.Height / 2), new Size(25, 25), img);
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
            _shuttle.Draw(Game.Buffer);
            foreach (BaseObject obj in _bullets)
                obj.Draw(Game.Buffer);
            foreach (BaseObject obj in _backGroundObjects)
                obj.Draw(Game.Buffer);
            foreach (BaseObject obj in _activeObjects)
                obj.Draw(Game.Buffer);
            Buffer.Render();
        }
        /// <summary>
        /// Вызов методов для изменения состояния игорвых объектов
        /// </summary>
        public static void Update()
        {
            _shuttle.Update();
            foreach (BaseObject obj in _bullets)
                obj.Update();
            foreach (BaseObject obj in _backGroundObjects)
                obj.Update();
            foreach (BaseObject obj in _activeObjects)
                obj.Update();
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
    }
}
