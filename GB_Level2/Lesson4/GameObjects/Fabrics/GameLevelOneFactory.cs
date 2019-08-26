using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Level2_Lesson2.GameObjects.ActiveObjects;
using Level2_Lesson2.GameObjects.BackgroundClasses;
using Level2_Lesson2.GameObjects.AbstractClasses;
using System.Drawing;

namespace Level2_Lesson2.GameObjects.Fabrics
{
    class GameLevelOneFactory : AbstractGameFactory
    {
        /// <summary>
        /// Установка шатла
        /// </summary>
        public override SpaceShuttle CreateShuttle(int height)
        {
            try
            {
                Image img = Image.FromFile(@"img\space_shuttle.jpg");
                SpaceShuttle tmplShuttle = new SpaceShuttle(new Point(5, height / 2), new Size(25, 25), img);
                return tmplShuttle;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new GameObjects.Exceptions.GameObjectException(@"Проверьте наличие файла с картинкой шатла " + e.Message);
            }
        }

        public override Stack<AidKit> MakeAidKit()
        {
            Stack<AidKit> said = new Stack<AidKit>();
            said.Push(new AidKit(new Point(250, 400), new Size(20, 20)));
            return said;
        }

        public override List<ActiveObject> MakeActiveObjects(int width, int height)
        {
            Size asteroidSize = new Size(12, 28);
            int cnt = width * height / (asteroidSize.Width * asteroidSize.Height * 60);
            Random rnd = new Random(cnt);
            List<ActiveObject> tmpAsteroids = new List<ActiveObject>(cnt);
            for (int i = 0; i < cnt; i++)
            {
                tmpAsteroids.Add(new Asteroid(new Point(rnd.Next(0, width), rnd.Next(0, height)), new Point(6, 1), asteroidSize, rnd.Next(1, 14)));
            }
            return tmpAsteroids;
        }

        public override List<BackGroundObject> MakeStarSky(int width,int height)
        {
            int defaultStarSize = 3;
            int cntX, cntY;
            cntX = width / (defaultStarSize * 21);
            cntY = height / (defaultStarSize * 25);
            int[] starSizeArray = new int[] { 5, 3, 6, 7, 4 };
            List<BackGroundObject> bo = new List<BackGroundObject>(cntX * cntY);
            Random rnd = new Random(cntX * cntY);
            int iter;
            for (int i = 0; i < cntX; i++)
            {
                for (int j = 0; j < cntY; j++)
                {
                    iter = rnd.Next(0, starSizeArray.Length - 1);
                    bo.Add(new Star(new Point(rnd.Next(0, width), rnd.Next(0, height))
                        , new Point(j, 0), new Size(starSizeArray[iter], starSizeArray[iter])));
                }
            }
            return bo;
        }

    }
}
