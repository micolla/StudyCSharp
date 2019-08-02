using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Task1()
        {
            Console.WriteLine("Введите ваш логин. Может содержать только буквы и цифры, от 2 до 10 символов");
            string login = Console.ReadLine();
            if (!CheckLogin.IsValidLogin(login) && CheckLogin.IsValidLoginRegex(login))
                Console.WriteLine("Вы ввели логин не соответствующий правилам");
            else
                Console.WriteLine("Корректный логин");
        }
        static void Task2()
        {
            string msg;
            int n;
            char c;
            char[] splitSymb = { ' ' };
            Console.WriteLine("Введите сообщения, разделяя слова пробелом");
            msg = Console.ReadLine();
            Console.WriteLine("Введите количество символов, для ограничения вывода слов");
            int.TryParse(Console.ReadLine(), out n);
            Message.PrintWords(msg, n, splitSymb);
            Console.WriteLine("Введите символ для исключения слов, которые заканчиваются на него");
            c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Message.PrintWords(Message.DeleteWords(msg, c, splitSymb), splitSymb);
            Console.WriteLine($"Самое длинное слово {Message.GetLongWord(msg, splitSymb)}");
            string testmsg = "dfsdfsd gfd 123 wolf wolf wolf";
            Console.WriteLine($"Проверка частоты появления слов в строке \"{testmsg}\"");
            Message.FreqAnalysis(new string[] { "123", "wolf" }, testmsg, splitSymb);
        }
        static void Task33()
        {
            string s1 = "abcd", s2 = "bacdc";
            Console.WriteLine($"Являются ли строки\"{s1}\" и \"{s2}\" одинаковыми ");
            Console.WriteLine(Task3.CheckConsist(s1,s2));
        }
        static void Task4()
        {
            EGE e1 = new EGE(@"pupils.txt");
            e1.PrintArray(e1.GetWorsPupils());
        }

        //Донцов Николай
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task33();
            Task4();
            Console.ReadLine();
        }

    }
}
