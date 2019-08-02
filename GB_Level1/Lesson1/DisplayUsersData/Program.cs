using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayUsersData
{
    class Program
    {
        static int centerFirstTopCoord,rowHeight;
        #region Задание 5 вариант а
        static void SimpleVarant()
        {
            Console.WriteLine("Донцов Николай");
            Console.WriteLine("Краснодар");
        }
        #endregion
        #region Задание 5 вариант в 
        static void GetCenterCoursor(int numberRows)
        {
            int rowTop,rowLeft;
            //Тестовый прогон для расчета высоты 1 строки
            rowTop = Console.CursorTop;
            rowLeft = Console.CursorLeft;
            Console.WriteLine();
            rowHeight = Console.CursorTop - rowTop;
            //Устанавливаем значение центра
            // Опытным путем установил, что высота одной строки 1, но все же метод дописал
            centerFirstTopCoord = Console.WindowHeight / 2 - rowHeight * numberRows;
            //Возвращаем каретку обратно
            Console.SetCursorPosition(rowLeft, rowTop);
        }
        static void PrintCenterRow(string msg,int topCoord)
        {
            int leftCoord = 0;
            if (msg.Length < Console.WindowWidth){
                leftCoord = (Console.WindowWidth - msg.Length) / 2;
            }
            Console.SetCursorPosition(leftCoord, topCoord);
            Console.WriteLine(msg);
        }
        #endregion
        static void Main(string[] args)
        {
            SimpleVarant(); //Вызов Задание 5 вариант а
            #region Задание 5 вариант в
            string[] texts = new string[] { "Донцов Николай", "г. Краснодар" };
            GetCenterCoursor(texts.Length+1);
            for (int i = 0; i < texts.Length; i++)
            {
                PrintCenterRow(texts[i], centerFirstTopCoord + rowHeight * i);
            }
            #endregion
            Console.ReadLine();
        }
    }
}
