using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    struct ComplexStruct
    {
        public double im;
        public double re;
        //  в C# в структурах могут храниться также действия над данными
        public ComplexStruct Plus(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        //  Пример произведения двух комплексных чисел
        public ComplexStruct Multi(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public ComplexStruct Sub(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }
        public ComplexStruct Div(ComplexStruct x)
        {
            ComplexStruct y;
            y.im = (x.re * im - x.im * re) / (Math.Pow(x.re, 2) + Math.Pow(x.im, 2));
            y.re = (re * x.re + im * x.im) / (Math.Pow(x.re, 2) + Math.Pow(x.im, 2));
            return y;
        }
        public override string ToString()
        {
            return re + "+" + im + "i";
        }
    }

}
