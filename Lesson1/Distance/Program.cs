using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distance
{
    class Program
    {
        #region Вспомогательный метод
        static string requestToUser(string msg)
        {
            Console.WriteLine(msg);
            return Console.ReadLine();
        }
        #endregion
        #region Задание 3 с помощью метода
        // Метод для расчета расстояний
        static double getDitancePoint(float x1,float y1,float x2,float y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static void Main(string[] args)
        {
            float x1, x2, y1, y2;
            double r;
            bool success;
            Console.WriteLine("Введите координаты двух точек для расчета расстояния");
            success = float.TryParse(requestToUser("Введите x1"), out x1);
            while (!success)
            {
                Console.WriteLine("Вы не верно ввели координату, нужно ввести целое число или дробное с запятой");
                success = float.TryParse(requestToUser("Введите x1"), out x1);
            }
            success = float.TryParse(requestToUser("Введите y1"), out y1);
            while (!success)
            {
                Console.WriteLine("Вы не верно ввели координату, нужно ввести целое число или дробное с запятой");
                success = float.TryParse(requestToUser("Введите y1"), out y1);
            }
            success = float.TryParse(requestToUser("Введите x2"), out x2);
            while (!success)
            {
                Console.WriteLine("Вы не верно ввели координату, нужно ввести целое число или дробное с запятой");
                success = float.TryParse(requestToUser("Введите x2"), out x2);
            }
            success = float.TryParse(requestToUser("Введите y2"), out y2);
            while (!success)
            {
                Console.WriteLine("Вы не верно ввели координату, нужно ввести целое число или дробное с запятой");
                success = float.TryParse(requestToUser("Введите y1"), out y2);
            }
            r = getDitancePoint(x1, y1, x2, y2);
            Console.WriteLine("Расстояние между точками {0:F2}", r);
            Console.ReadLine();
        }
        #endregion
    }
}
