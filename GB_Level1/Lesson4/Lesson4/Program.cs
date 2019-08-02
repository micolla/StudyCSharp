using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    class Program
    {
        #region Task1
        /// <summary>
        /// Дан  целочисленный  массив  из 20 элементов.  Элементы  массива  могут принимать  целые  значения  от –10 000 до 10 000 включительно. 
        /// Заполнить случайными числами.  Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
        /// В данной задаче под парой подразумевается два подряд идущих элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
        /// </summary>
        static void Task11()
        {
            Task1 t1 = new Task1(-10_000, 10_000, 20);
            Console.WriteLine($"groups {t1.GetNumberGroups()}");
        }
        #endregion
        #region Task2
        /// <summary>
        /// Реализуйте задачу 1 в виде статического класса StaticClass;
        //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        //б) *Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
        //в)**Добавьте обработку ситуации отсутствия файла на диске
        /// </summary>
        static void Task22()
        {
            int[] myFileArray = Task2.LoadToArray("array2.txt");
            int i = Task2.GetNumberGroups(myFileArray);
        }
        #endregion
        #region Task3
        /// <summary>
        /// а) Дописать класс для работы с одномерным массивом. Реализовать конструктор, создающий массив определенного размера и 
        /// заполняющий массив числами от начального значения с заданным шагом. Создать свойство Sum, которое возвращает сумму элементов массива
        /// , метод Inverse, возвращающий новый массив с измененными знаками у всех элементов массива (старый массив, остается без изменений),  
        /// метод Multi, умножающий каждый элемент массива на определённое число, свойство MaxCount, возвращающее количество максимальных элементов. 
        /// </summary>
        static void Task33()
        {
            int n, min;
            sbyte s;
            n = 5; min = 0; s = 1;
            MyArray t4 = new MyArray(n, min, s);
            Console.WriteLine(t4.ToString());
            Console.WriteLine(t4.Sum);
            Console.WriteLine(t4.Inverse());
            Console.WriteLine(t4.MaxCount);
            t4 = new MyArray(100,50,85);
            Console.WriteLine(t4.ToString());
            int[,] display = t4.GetNumberValues();
            Console.WriteLine("Частота распределения");
            for (int i = 0; i < display.GetLength(0); i++)
            {
                if (display[i, 1] > 0)
                    Console.WriteLine($"Array[{display[i, 0]},{display[i, 1]}]");
            }
        }
        #endregion
        #region Task5
        /// <summary>
        /// *а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами. 
        /// Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, 
        /// свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, 
        /// метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
        ///**б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
        ///** в) Обработать возможные исключительные ситуации при работе с файлами.
        /// </summary>
        static void Task55()
        {
            Task5 t5 = new Task5("arr1.txt");
            Console.WriteLine(t5.MaxElement());
            Console.WriteLine(t5.SumElements(5));
        }
        #endregion
        //Донцов
        static void Main(string[] args)
        {
            Task11();
            Task22();
            Task33();
            Task55();
            Console.ReadLine();
        }
    }
}
