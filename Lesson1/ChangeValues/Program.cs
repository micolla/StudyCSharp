using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeValues
{
    class Program
    {
        static void changeValuesSimple(ref float x1, ref float x2)
        {
            float x3;
            x3 = x1;
            x1 = x2;
            x2 = x3;
        }
        static void changeValues(ref float x1, ref float x2)
        {
            x1 = x2*x1;
            x2=x1/x2;
            x1 = x1 / x2;            
        }
        static void Main(string[] args)
        {
            float var1, var2;
            var1 = 5;
            var2 = 6;
            Console.WriteLine("x1 = {0}, x2 = {1}", var1, var2);
            changeValues(ref var1, ref var2);
            Console.WriteLine("x1 = {0}, x2 = {1}", var1, var2);
            var1 = 53.2f;
            var2 = 63.54f;
            Console.WriteLine("x1 = {0}, x2 = {1}", var1, var2);
            changeValues(ref var1, ref var2);
            Console.WriteLine("x1 = {0}, x2 = {1}", var1, var2);
            Console.Read();
        }
    }
}
