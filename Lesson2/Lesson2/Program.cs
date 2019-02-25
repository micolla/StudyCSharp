using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    class Program
    {
        //Донцов Николай
        static void Main(string[] args)
        {
            Console.WriteLine("минимальное числов {0}",Helper.MinVal(3, 5, 4));// 1 Задание
            Console.WriteLine("количество цифр в числе {0}",Helper.NumberDigits(456478796)); // 2 Задание
            Console.WriteLine("сумма положительных нечетных чисел {0}", Helper.SumPosNotOddVal());// 3 Задание
            Helper.Login(); //4 Задание
            Helper.IMTInfo(); // 5 Задание
            Helper.CalcGoodNumbers(0, 1_000_000); // 6 Задание
            Helper.ShowRange(1, 10); //7a Задание
            Console.WriteLine("Сумма чисел диапазона {0}", Helper.SumRange(1, 10));//7б Задание
            Console.ReadKey();
        }
    }
}
