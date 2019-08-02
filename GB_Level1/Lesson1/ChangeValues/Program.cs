using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeValues
{
    class Program
    {
        #region Метод задание 4 с помощью 3 переменных
        static void ChangeValuesSimple(ref float x1, ref float x2)
        {
            float x3;
            x3 = x1;
            x1 = x2;
            x2 = x3;
        }
        #endregion
        #region Метод задание 4 с помощью 2 переменных
        static void ChangeValues(ref float x1, ref float x2)
        {
            x1 = x2*x1;
            x2=x1/x2;
            x1 = x1 / x2;            
        }
        #endregion
        static void Main(string[] args)
        {
            float var1, var2;
            #region Задание 4 а
            var1 = 5;
            var2 = 6;
            Console.WriteLine("x1 = {0}, x2 = {1}", var1, var2);
            ChangeValues(ref var1, ref var2);
            Console.WriteLine("x1 = {0}, x2 = {1}", var1, var2);
            #endregion
            #region Задание 4 б
            var1 = 53.2f;
            var2 = 63.54f;
            Console.WriteLine("x1 = {0}, x2 = {1}", var1, var2);
            ChangeValues(ref var1, ref var2);
            Console.WriteLine("x1 = {0}, x2 = {1}", var1, var2);
            #endregion
            Console.Read();
        }
    }
}
