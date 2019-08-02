using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Complex
    {
        // Поля приватные.
        private double im;
        // По умолчанию элементы приватные, поэтому private можно не писать.
        double re;

        // Конструктор без параметров.
        public Complex()
        {
            im = 0;
            re = 0;
        }

        // Конструктор, в котором задаем поля.    
        // Специально создадим параметр re, совпадающий с именем поля в классе.
        public Complex(double _im, double re)
        {
            // Здесь имена не совпадают, и компилятор легко понимает, что чем является.              
            im = _im;
            // Чтобы показать, что к полю нашего класса присваивается параметр,
            // используется ключевое слово this
            // Поле параметр
            this.re = re;
        }
        public Complex Plus(Complex x2)
        {
            return new Complex(x2.im + im, x2.re + re);
        }
        public Complex Sub(Complex x2)
        {
            return new Complex(im- x2.im, re- x2.re);
        }
        public Complex Multi(Complex x2)
        {
            return new Complex(re * x2.im + im * x2.re, re * x2.re - im * x2.im);
        }
        bool CheckAction(char answ)
        {
            answ = char.ToLower(answ);
            if (answ == 'a' || answ == 'b' || answ == 'c')
                return true;
            else
            {
                Console.WriteLine("Вы ввели значения не из диапазона, попробуйте ещё раз");
                return false;
            }
        }
        public string ActionComplex()
        {
            char answ;
            double newim, newre;
            Console.WriteLine($"Выберите действие с комплексным числом {this.ToString()}");
            Console.WriteLine("Для этого напишите нужную букву и нажмите Enter");
            Console.WriteLine("a - Сложение");
            Console.WriteLine("b - Вычитание");
            Console.WriteLine("c - Умножение");
            do
            {
                answ = Console.ReadKey().KeyChar;
                Console.WriteLine();
            } while (!CheckAction(answ));
            Console.WriteLine("Задайте второй операнд");
            do
                Console.WriteLine("Укажите действительную часть");
            while (!Double.TryParse(Console.ReadLine(), out newre)) ;
            do
                Console.WriteLine("Укажите мнимую часть");
            while (!Double.TryParse(Console.ReadLine(), out newim));
            switch (answ)
            {
                case 'a':
                    return this.Plus(new Complex(newim, newre)).ToString();
                case 'b':
                    return this.Sub(new Complex(newim, newre)).ToString();
                case 'c':
                    return this.Multi(new Complex(newim, newre)).ToString();
                default:
                    return "Сюда я никогда не попаду";
            }
        }

        // Свойства - это механизм доступа к данным класса.
        public double Im
        {
            get { return im; }
            set
            {
                // Для примера ограничимся только положительными числами.
                if (value >= 0) im = value;
            }
        }
        public double Re
        {
            get { return re; }
            set
            {
                // Для примера ограничимся только положительными числами.
                if (value >= 0) re = value;
            }
        }
        // Специальный метод, который возвращает строковое представление данных.
        public override string ToString()
        {
            return re + "+" + im + "i";
        }
    }
}
