using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson6
{
    //Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата. 
    //а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.
    //Использовать массив(или список) делегатов, в котором хранятся различные функции.
    //б) * Переделать функцию Load, чтобы она возвращала массив считанных значений.
    //Пусть она возвращает минимум через параметр(с использованием модификатора out). 

    public delegate double Min(List<double> ar,double x1,double x2);
    /// <summary>
    /// Структура для реалиазации пользовательского меню
    /// </summary>
    struct UserChoise
    {
        public Min fun;
        public double x1;
        public double x2;
    }
    class Task2
    {
        /// <summary>
        /// Перечисление допустимых функций
        /// </summary>
        public enum MenuList
        {
            Min,
            Max,
            AVG,
            Sum
        };

        public static double F(double x)
        {
            return x * x - 50 * x + 10;
        }
        public static void SaveFunc(string fileName, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double[] Load(string fileName,out double min, UserChoise m)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            List<double> doubleList = new List<double>();
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                doubleList.Add(bw.ReadDouble());
            }
            bw.Close();
            fs.Close();
            min = m.fun(doubleList,m.x1,m.x2);
            return doubleList.ToArray();
        }
        private static void MaxVal(ref double x1,ref double x2)
        {
            if (x1 > x2)
            {
                x2 = x1 + x2;
                x1 = x2 - x1;
                x2 = x2 - x1;
            }
        }
        #region Функции для делегатов
        private static double MinVal(List<double> dList,double x1,double x2)
        {
            MaxVal(ref x1,ref x2);
            double min = x2;
            foreach (var item in dList)
            {
                if (item>x1&&item<x2&&item < min) min = item;
            }
            return min;
        }

        private static double MaxVal(List<double> dList, double x1, double x2)
        {
            MaxVal(ref x1, ref x2);
            double max = x1;
            foreach (var item in dList)
            {
                if (item > x1 && item < x2 && item > max) max = item;
            }
            return max;
        }
        private static double AVGVal(List<double> dList, double x1, double x2)
        {
            MaxVal(ref x1, ref x2);
            double avg = 0;
            int i = 0;
            foreach (var item in dList)
            {
                if (item > x1 && item < x2)
                {
                    avg = (avg + item) / i == 0 ? 1 : 2;
                    i++;
                }
            }
            return avg;
        }
        private static double SumVal(List<double> dList, double x1, double x2)
        {
            MaxVal(ref x1, ref x2);
            double sum = 0;
            foreach (var item in dList)
            {
                if(item > x1 && item < x2)
                {
                    sum += item;
                }
            }
            return sum;
        }
        #endregion
        /// <summary>
        /// Запуск демонстрации
        /// </summary>
        public static void Test()
        {
            double min;
            SaveFunc("data.bin", -100, 100, 0.5);
            double[] dlist =Load("data.bin",out min,Menu());
            Console.WriteLine($"Минимальное значение {min}");
            Console.ReadKey();
        }
        /// <summary>
        /// Меню для выбора операции над числами
        /// </summary>
        /// <returns>Делегат для запуска</returns>
        static UserChoise Menu()
        {
            bool success = false; 
            int c;
            UserChoise Uchoice =new UserChoise();
            foreach (var item in Enum.GetValues(typeof(MenuList)))
            {
                Console.WriteLine("Для выбора функции {0} напишите {1}",item,(int)item);
            }
            while(!success){
                while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out c))
                {
                    Console.WriteLine("Вы ввели не цифру, попробуйте ещё раз");
                };
                Console.WriteLine();
                switch (c)
                {
                    case (int)MenuList.AVG: Uchoice.fun = AVGVal; success = true; break; 
                    case (int)MenuList.Max: Uchoice.fun = MaxVal; success = true; break; 
                    case (int)MenuList.Min: Uchoice.fun = MinVal; success = true; break;
                    case (int)MenuList.Sum: Uchoice.fun = SumVal; success = true; break;
                    default: Console.WriteLine("Введите ещё раз"); success = false; break;
                }
            }
            Console.WriteLine("Введите нижнюю границу поиска");
            while (!Double.TryParse(Console.ReadLine(), out Uchoice.x1))
            {
                Console.WriteLine("Вы ввели не цифру, попробуйте ещё раз");
            };
            Console.WriteLine("Введите верхнюю границу поиска");
            while (!Double.TryParse(Console.ReadLine(), out Uchoice.x2))
            {
                Console.WriteLine("Вы ввели не цифру, попробуйте ещё раз");
            };
            return Uchoice;
        }
    }
}