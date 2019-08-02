using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    //Изменить программу вывода таблицы функциивывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
    //Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).



    // Описываем делегат. В делегате описывается сигнатура методов, на
    // которые он сможет ссылаться в дальнейшем (хранить в себе)
    public delegate double Fun(double x,double a);
    //public delegate double Fun(double x,double y);
    class Task1
    {
        // Создаем метод, который принимает делегат
        // На практике этот метод сможет принимать любой метод
        // с такой же сигнатурой, как у делегата
        public static void Table(Fun F, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x,b));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        // Создаем метод для передачи его в качестве параметра в Table
        public static double MyFunc(double x,double a)
        {
            return a * Math.Pow(x, 2);
        }

        public static double SinCalc(double x, double a)
        {
            return a * Math.Sin(x);
        }

        public static void Test()
        {
            // Создаем новый делегат и передаем ссылку на него в метод Table
            Console.WriteLine("Таблица функции a*x^2:");
            Table(MyFunc, -2, 2);
            Console.WriteLine("Таблица функции Sin:");
            Table(SinCalc, -2, 2);      // Можно передавать уже созданные методы
        }
    }

}
