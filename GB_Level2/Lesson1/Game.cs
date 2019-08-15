using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Level2.BackGround;

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
        private static Timer timer;

        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            _objs = new List<BaseObject>();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            MakeStarSky();
            MakeAsteroids();
            CreateShuttle();
            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        public static void MakeStarSky()
        {

            int defaultStarSize = 3;
            int cntX, cntY;
            cntX = Width / (defaultStarSize * 21);
            cntY = Height / (defaultStarSize * 25);
            int[] starSizeArray = new int[] {5,3,6,7,4 };
            Random rnd = new Random(cntX * cntY);
            int iter = 0;
            for (int i = 0; i < cntX; i++)
            {
                for (int j = 0; j < cntY; j++)
                {
                    iter = rnd.Next(0, starSizeArray.Length - 1);
                    _objs.Add(new Star(new Point(rnd.Next(0,Game.Width), rnd.Next(0, Game.Height)), new Point(j, 0), new Size(starSizeArray[iter], starSizeArray[iter])));
                }
            }
        }

        public static void MakeAsteroids()
        {
            int cnt=5;
            Random rnd = new Random(cnt);
            Asteroid tmpAsteroid;
            for (int i = 0; i < cnt; i++)
            {
                tmpAsteroid = new Asteroid(new Point(rnd.Next(0, Game.Width), rnd.Next(0, Game.Height)), new Point(6, 1), new Size(6, 25));
                //tmpAsteroid.AsteroidOutOfSpace += DropAsteroid;
                _objs.Add(tmpAsteroid);
            }
        }

        public static void CreateShuttle()
        {
            int cnt = 1;
            try
            {
                Image img = Image.FromFile("img\\space_shuttle.jpg");
                _objs.Add(new SpaceShuttle(new Point(5, Game.Height/2), new Point(0, 0), new Size(25, 25), img));
            }
            catch(System.IO.FileNotFoundException e)
            {

            }
        }
        private static void DropAsteroid(Asteroid obj)
        {
            _objs.Remove(obj);
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}
