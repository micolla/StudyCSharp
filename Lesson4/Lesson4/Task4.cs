using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    class MyArray
    {
        int[] a;
        //  Создание массива и заполнение его одним значением el  
        public MyArray(int n, int el)
        {
            a = new int[n];
            for (int i = 0; i < n; i++)
                a[i] = el;
        }
        //  Создание массива и заполнение его случайными числами от min до max
        public MyArray(int n, int min, int max)
        {
            a = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
                a[i] = rnd.Next(min, max);
        }
        /// <summary>
        /// Конструктор конструктор, создающий массив определенного размера и заполняющий массив 
        /// числами от начального значения с заданным шагом
        /// </summary>
        /// <param name="n">Число элементов</param>
        /// <param name="min">Значение 0 элемента</param>
        /// <param name="step">Шаг между элементами</param>
        public MyArray(int n, int min, sbyte step)
        {
            a = new int[n];
            a[0] = min;
            for (int i = 1; i < n; i++)
                a[i] = a[i-1]+step;
        }

        public int Sum { get {return a.Sum(); } }

        public void Multi(int multip)
        {
            Multi(ref a, multip);
        }

        void Multi(ref int[] ar,int multip)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                ar[i] = ar[i] * multip;
            }
        }

        /// <summary>
        /// Инверсия
        /// </summary>
        /// <returns></returns>
        public int[] Inverse()
        {
            int[] b = new int[a.Length];
            Multi(ref b, (-1));
            return b;
        }

        public int MaxCount { get { return GetNumberValues(a.Max()); }  }

        private int GetNumberValues(int val)
        {
            int cnt=0;
            foreach (var c in a)
            {
                if (c == val)
                    cnt++;
            }
            return cnt;
        }
        ///// <summary>
        ///// Возвращает распределение элементов массива
        ///// </summary>
        ///// <returns>массив</returns>
        //public int[] GetNumberValues()
        //{
        //    int[] b;
        //    b=a.Distinct().Count();
        //    return new int[] { 1 };
        //} 

        public int Max
        {
            get
            {
                int max = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] > max) max = a[i];
                return max;
            }
        }
        public int Min
        {
            get
            {
                int min = a[0];
                for (int i = 1; i < a.Length; i++)
                    if (a[i] < min) min = a[i];
                return min;
            }
        }
        public int CountPositive
        {
            get
            {
                int count = 0;
                for (int i = 0; i < a.Length; i++)
                    if (a[i] > 0) count++;
                return count;
            }
        }
        public override string ToString()
        {
            string s = "";
            foreach (int v in a)
                s = s + v + " ";
            return s;
        }
    }
}
