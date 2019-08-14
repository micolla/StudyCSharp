﻿using System;
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
            timer = new Timer { Interval = 350 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        public static void MakeStarSky()
        {
            int starSize = 15;
            int cntX, cntY;
            cntX = Width / (starSize*2);
            cntY = Height / (starSize*2);
            
            for (int i = 0; i < cntX; i++)
            {
                for (int j = 0; j < cntY; j++)
                {
                    _objs.Add(new Star(new Point(i*starSize*2, j * starSize * 2), new Point(0, 0), new Size(starSize, starSize)));
                }
            }
        }

        //public static void Load()
        //{
        //    _objs = new Star[15];
        //    for (int i = 0; i < _objs.Length; i++)
        //    {
        //        _objs[i] = new Star(new Point(600, i * 20), new Point(15 - i, 15 - i), new Size(20, 20));
        //    }
        //}

        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            Buffer.Render();

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
