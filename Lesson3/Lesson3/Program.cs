using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Program
    {
        #region Task1a
        /// <summary>
        /// а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.
        /// </summary>
        static void Task1a()
        {
            ComplexStruct complex1;
            complex1.re = 1;
            complex1.im = 6;

            ComplexStruct complex2;
            complex2.re = 4;
            complex2.im = 2;

            ComplexStruct result = complex1.Div(complex2);
            Console.WriteLine(result.ToString());
            result = complex1.Sub(complex2);
            Console.WriteLine(result.ToString());
        }
        #endregion

        #region Task1v
        /// <summary>
        /// б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
        /// в) Добавить диалог с использованием switch демонстрирующий работу класса.
        /// </summary>
        static void Task1v()
        {
            Complex complex1 = new Complex(2, 5);
            Console.WriteLine($"Результат {complex1.ActionComplex()}");
        }
        #endregion
        #region Task 2
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
        public static int RequestToUser(string msg)
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
            int inputNumber = RequestToUser("Введите число");
            while (CanContinue(inputNumber))
            {
                if (!IsOdd(inputNumber) && IsPositiv(inputNumber))
                {
                    result += inputNumber;
                }
                inputNumber = RequestToUser("Введите число");
            }
            return result;
        }
        #endregion
        #region Task 3
        /// <summary>
        /// *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
        ///* Добавить свойства типа int для доступа к числителю и знаменателю;
        ///* Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
        ///** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
        ///*** Добавить упрощение дробей.
        /// </summary>
        static void Task3()
        {
            Fraction f1 = new Fraction(3, 7);
            Fraction f2 = new Fraction(3, 4);
            Console.WriteLine($"Первая дробь {f1.ToString()}");
            Console.WriteLine($"Вторая дробь {f2.ToString()}");
            Fraction f3 = f1.Add(f2);
            Console.WriteLine($"Результат сложения {f3.ToString()}");
            f3 = f1.Multi(f2);
            Console.WriteLine($"Результат уможения в виде десятичной дроби {f3.DecimalFraction:F2}");
            f3 = f1.Sub(f2);
            Console.WriteLine($"Результат вычитания {f3.ToString()}");
            f3 = f1.Div(f2);
            Console.WriteLine($"Результат деления {f3.ToString()}");
            f3 = new Fraction(21, 12);
            Fraction.MakeFractionSimple(f3);
            Console.WriteLine($"Результат после упрощения {f3.ToString()}");
            ///f3 = new Fraction(1, 0); Генерация ошибки про 0
        }
        #endregion
        //Донцов Николай
        static void Main(string[] args)
        {
            Task1a();//Задание 1 а
            Task1v();//Задание 1 в
            Console.WriteLine("сумма положительных нечетных чисел {0}", SumPosNotOddVal());// Задание 2
            Task3();
            Console.ReadLine();
        }
    }
}
