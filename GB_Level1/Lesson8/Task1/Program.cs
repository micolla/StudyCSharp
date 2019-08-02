using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Task1
{
    class Program
    {
        //С помощью рефлексии выведите все свойства структуры DateTime
        //Донцов Николай
        static void Main(string[] args)
        {
            FieldInfo[] fi = typeof(DateTime).GetFields();
            PropertyInfo[] pi = typeof(DateTime).GetProperties();
            foreach (var item in pi)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
    }
}
