using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Helper
    {
        #region Task 1
        /// <summary>
        /// 1. Написать метод, возвращающий минимальное из трёх чисел.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static int MinVal(int a, int b, int c)
        {
            return MinVal(MinVal(a, b), c);
        }
        public static int MinVal(int a, int b)
        {
            return a < b ? a : b;
        }
        #endregion
        #region Task 2
        /// <summary>
        /// Написать метод подсчета количества цифр числа.
        /// </summary>
        /// <param name="x">Число</param>
        /// <returns></returns>
        public static int NumberDigits(int x)
        {
            return Convert.ToString(x).Length;
        }
        #endregion
        #region Task 3
        /// <summary>
        /// Проверка на четность числа
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsOdd(int x)
        {
            return x % 2 == 0;
        }

        public static bool IsPositiv(int x)
        {
            return x > 0;
        }

        public static bool CanContinue(int x)
        {
            return x != 0;
        }
        /// <summary>
        ///  Функция для запроса у пользователя
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int requestToUser(string msg)
        {
            int number;
            bool success;
            Console.WriteLine(msg);
            success = int.TryParse(Console.ReadLine(), out number);
            while (!success)
            {
                Console.WriteLine("Вы не верно ввели, нужно ввести целое число");
                success = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }


        /// <summary>
        /// С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
        /// </summary>
        public static int SumPosNotOddVal()
        {
            int result = 0;
            int inputNumber = requestToUser("Введите число");
            while (CanContinue(inputNumber))
            {
                if (!IsOdd(inputNumber) && IsPositiv(inputNumber))
                {
                    result += inputNumber;
                }
                inputNumber = requestToUser("Введите число");
            }
            return result;
        }
        #endregion
        #region Task 4
        /// <summary>
        /// Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль
        /// , программа пропускает его дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками.
        /// </summary>
        public static void Login()
        {
            int numAttempts = 0;
            string login, pwd;
            bool success;
            do
            {
                Console.WriteLine("Введите логин");
                login = Console.ReadLine();
                Console.WriteLine("Введите пароль");
                pwd = Console.ReadLine();
                success = CheckCredentials(login, pwd);
            } while (++numAttempts < 3 && !(success));
            if (success)
                Console.WriteLine("Доступ разрешен");
            else
                Console.WriteLine("Доступ не разрешен");
        }
        /// <summary>
        /// Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль. 
        /// На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public static bool CheckCredentials(string login, string pwd)
        {
            return login == "root" && pwd == "GeekBrains" ? true : false;
        }
        #endregion
        #region Task 5
        /// <summary>
        /// Расчет ИМТ
        /// </summary>
        /// <param name="height">Рост в см</param>
        /// <param name="weight">Вес в кг</param>
        /// <returns></returns>
        public static float getIMT(float height, float weight)
        {
            return weight / ((float)Math.Pow(height, 2) / 10000);
        }
        /// <summary>
        /// а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает
        /// , нужно ли человеку похудеть, набрать вес или всё в норме.
        ///б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        /// </summary>
        public static void IMTInfo()
        {
            float weight, height = 0;
            float imt;
            Console.WriteLine("Введите ваш вес в кг");
            weight = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите ваш рост в см");
            height = float.Parse(Console.ReadLine());
            imt = getIMT(height, weight);
            Console.WriteLine("Ваш ИМТ {0:F2}", imt);
            Console.WriteLine("Для нормализации веса необходимо изменить вес на {0:F2} кг", GetNormalWeight(imt, height) - weight);
        }
        /// <summary>
        /// Вес в пределах нормального ИМТ
        /// </summary>
        /// <param name="imt"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static float GetNormalWeight(float imt, float height)
        {
            float minNormIMT = 18.5f;
            float maxNormIMT = 24.99f;
            float NormalWeight;
            if (imt > maxNormIMT)
            {
                NormalWeight = GetWeight(maxNormIMT, height);
            }
            else if (imt < minNormIMT)
            {
                NormalWeight = GetWeight(minNormIMT, height);
            }
            else
            {
                NormalWeight = GetWeight(imt, height);
            }
            return NormalWeight;
        }
        /// <summary>
        /// Расчет веса по ИМТ и росту
        /// </summary>
        /// <param name="imt"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static float GetWeight(float imt, float height)
        {
            return imt * (height * height) / 10000;
        }
        #endregion
        #region Task 6
        /// <summary>
        /// *Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000. 
        /// «Хорошим» называется число, которое делится на сумму своих цифр. 
        /// Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static void CalcGoodNumbers(int a, int b)
        {
            DateTime starttime, endtime;
            int cur = 0;
            starttime = DateTime.Now;
            for (int i = 1; i <= b; i++)
            {
                if (IsGoodNumber(i))
                {
                    cur++;
                }
            }
            Console.WriteLine($"Всего хороших чисел {cur}");
            endtime = DateTime.Now;
            Console.WriteLine($"Затраченное время на выполнение{starttime - endtime}");
        }
        /// <summary>
        /// Проверка, что число делится на сумму своих цифр без остатка
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool IsGoodNumber(int x)
        {
            string s = x.ToString();
            int sumDigits = 0;
            for (int i = 0; i < s.Length; i++)
            {
                sumDigits += int.Parse(s[i].ToString());
            }
            return x % sumDigits == 0;
        }
        #endregion
        #region Task 7
        /// <summary>
        ///  Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b)
        /// </summary>
        public static void ShowRange(int a, int b)
        {
            if (a <= b)
            {
                Console.WriteLine(a);
                ShowRange(a + 1, b);
            }
        }
        /// <summary>
        /// *Разработать рекурсивный метод, который считает сумму чисел от a до b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int SumRange(int a, int b)
        {
            return a + (a < b ? SumRange(a + 1, b) : 0);
        }

        #endregion
    }
}
