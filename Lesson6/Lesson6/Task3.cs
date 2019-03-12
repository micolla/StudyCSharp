using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson6
{
    ///Переделать программу Пример использования коллекций для решения следующих задач:
    ///а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    ///б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
    ///в) отсортировать список по возрасту студента;
    class Task3
    {
        public static void Test()
        {
            StudentSpace.Students st = new StudentSpace.Students();
            // Запомним время в начале обработки данных
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("..\\..\\students_1.csv",Encoding.UTF8);
            while (!sr.EndOfStream)
            {
                try
                {
                    st.AddStudent(sr.ReadLine().Split(';'));
                }
                catch
                {
                }
            }
            sr.Close();
            //Сортировка по возрасту
            st.Sort();
            Console.WriteLine("Всего студентов:{0}", st.StudentsCount);//Всего студентов
            Console.WriteLine("Магистров:{0}", st.MagistrCount);
            Console.WriteLine("Бакалавров:{0}", st.BacalavrCount);
            Console.WriteLine("Студентов 5 курса:{0}", st.Students5Cnt);
            Console.WriteLine("Студентов 6 курса:{0}", st.Students6Cnt);
            Console.WriteLine("Студентов от 18 до 20 лет:{0}", st.GetStudentsCnt(18, 20));
            for (int i = 0; i < st.StudentsCount; i++)
            {
                Console.WriteLine(st[i]);///Выводим имя и фамилии
            } 
            // Вычислим время обработки данных
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }
}
