using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Level2.BackGround;
using Level2.AbstractClasses;
using Level2.ActiveObjects;

namespace Level2
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static List<BaseObject> _objs;
        public static Bullet _bullet;
        private static Timer timer;
        /// <summary>
        /// Инициализация игры Game
        /// </summary>
        /// <param name="form">Форма для связывания с игрой</param>
        public static void Init(Form form)
        {
            if (form.ClientSize.Width > 1000 || form.ClientSize.Height > 1000 || form.ClientSize.Width < 0 || form.ClientSize.Height < 0)
                throw new ArgumentOutOfRangeException("form.ClientSize"
                    , $"Переданы неверные размеры окна {form.ClientSize.Width} и {form.ClientSize.Height}");
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            _objs = new List<BaseObject>();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            MakeStarSky();
            MakeAsteroids();
            CreateShuttle(form);
            _bullet = new Bullet(new Point(0, Game.Height / 2), new Point(5, 0), new Size(4, 1));
            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        /// <summary>
        /// Создание звездного движущегося неба
        /// </summary>
        public static void MakeStarSky()
        {

            int defaultStarSize = 3;
            int cntX, cntY;
            cntX = Width / (defaultStarSize * 21);
            cntY = Height / (defaultStarSize * 25);
            int[] starSizeArray = new int[] {5,3,6,7,4 };
            Random rnd = new Random(cntX * cntY);
            int iter;
            for (int i = 0; i < cntX; i++)
            {
                for (int j = 0; j < cntY; j++)
                {
                    iter = rnd.Next(0, starSizeArray.Length - 1);
                    _objs.Add(new Star(new Point(rnd.Next(0,Game.Width), rnd.Next(0, Game.Height))
                        , new Point(j, 0), new Size(starSizeArray[iter], starSizeArray[iter])));
                }
            }
        }
        /// <summary>
        /// Создание метеоритного дождя
        /// </summary>
        public static void MakeAsteroids()
        {
            int cnt=25;
            Random rnd = new Random(cnt);
            Asteroid tmpAsteroid;
            for (int i = 0; i < cnt; i++)
            {
                tmpAsteroid = new Asteroid(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(6, 1), new Size(12, 28));
                _objs.Add(tmpAsteroid);
            }
        }
        /// <summary>
        /// Установка шатла
        /// </summary>
        /// <param name="form">Форма для связи с событием KeyDown</param>
        public static void CreateShuttle(Form form)
        {
            try
            {
                Image img = Image.FromFile("img\\space_shuttle.jpg");
                SpaceShuttle tmplShuttle = new SpaceShuttle(new Point(5, Game.Height / 2), new Point(0, 0), new Size(25, 25), img);
                form.KeyDown += tmplShuttle.MoveShuttle;
                _objs.Add(tmplShuttle);                
            }
            catch(System.IO.FileNotFoundException e)
            {
                ///игнорирование ошибок
            }
        }
        /// <summary>
        /// Прорисовка всех объектов в игре
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            _bullet.Draw();
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// Вызов методов для изменения состояния игорвых объектов
        /// </summary>
        public static void Update()
        {
            _bullet.Update();
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
                if (obj is Asteroid)
                {
                    if (obj.Collision(_bullet))
                    {
                        _bullet.Reset();
                        (obj as Asteroid).Reset();
                        Game.Buffer.Graphics.DrawString("Intersect", new Font(FontFamily.GenericSerif,14), Brushes.White, new Point(5, 6));
                    }
                }
            }
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
