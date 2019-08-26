using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using Level2_Lesson2.GameObjects.AbstractClasses;
using Level2_Lesson2.GameObjects.BackgroundClasses;
using Level2_Lesson2.GameObjects.ActiveObjects;
using Level2_Lesson2.GameObjects.Fabrics;

namespace Level2_Lesson2
{
    static class Game
    {
        #region VariablesDesctiption
        private const string logFilePath=@"log.txt";
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
        private static Stack<AidKit> aidStack;
        /// <summary>
        /// Таймер для управления игровым циклом
        /// </summary>
        private static Timer timer;
        private static int gameScore;
        private static GameClient gameClient;

        #endregion
        /// <summary>
        /// Инициализация игры Game
        /// </summary>
        /// <param name="form">Форма для связывания с игрой</param>
        public static void Init(Form form)
        {
            CreateLogFile();
            CheckWindowSize(form);
            Graphics g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            _context = BufferedGraphicsManager.Current;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            aidStack = new Stack<AidKit>();
            gameScore = 0;
            gameClient = new GameClient(new GameLevelOneFactory(),Game.Width,Game.Height);
            SubcribeEvent();
            form.KeyDown += ControlKeyDown;
            timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            form.ResizeEnd += Form_SizeChanged;
        }
        private static void SubcribeEvent()
        {
            gameClient.GameClientLog += WriteLogs;
            gameClient.GameClientLog += Console.WriteLine;
            gameClient.GameOverEvent += Finish;
            gameClient.GameScoreChange += s => gameScore += s;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Обновить состояние игры
        /// </summary>
        private static void Update()
        {
            gameClient.Update();
        }
        /// <summary>
        /// Прорисовка всех объектов в игре
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            gameClient.Draw(Buffer);
            Buffer.Graphics.DrawString($"GameScore {gameScore}", new Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline), Brushes.White, Game.Width - 100, 1);
            Buffer.Render();
        }

        /// <summary>
        /// Подготовка файла для лога
        /// </summary>
        private static void CreateLogFile()
        {
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath);
            }
        }
        /// <summary>
        /// Управление действиями шатла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">KeyEventArgs</param>
        private static void ControlKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Up:
                    gameClient.MoveShuttle(0, -15,Game.Width,Game.Height);
                    break;
                case System.Windows.Forms.Keys.Down:
                    gameClient.MoveShuttle(0, 15, Game.Width, Game.Height);
                    break;
                case System.Windows.Forms.Keys.Left:
                    gameClient.MoveShuttle(-15, 0, Game.Width, Game.Height);
                    break;
                case System.Windows.Forms.Keys.Right:
                    gameClient.MoveShuttle(15, 0, Game.Width, Game.Height);
                    break;
                case System.Windows.Forms.Keys.Space:
                    gameClient.ShuttleShoot();
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
            }

        }

        /// <summary>
        /// Окончание игры
        /// </summary>
        public static void Finish()
        {
            timer.Stop();
            Buffer.Graphics.DrawString($"The End \nfinalScore {gameScore}", new Font(FontFamily.GenericSansSerif, 40, FontStyle.Underline),
                Brushes.White, Game.Width/2-55, Game.Height/2);
            Buffer.Render();
        }
        /// <summary>
        /// Запись в файловый лог
        /// </summary>
        /// <param name="msg">Сообщение лога</param>
        public static void WriteLogs(string msg)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(logFilePath, true, Encoding.UTF8))
                {
                    sw.WriteLine(msg);
                }
            }
            catch (Exception e)
            {

                throw new GameObjects.Exceptions.GameObjectException(e.Message);
            }
        }
    }
}
