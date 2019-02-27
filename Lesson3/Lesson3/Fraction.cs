using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    class Fraction
    {
        int _numerator;
        int _denominator;
        public int Numerator { get { return _numerator; } }
        public int Denominator { get { return _denominator; } }
        public double DecimalFraction { get { return (double)Numerator / Denominator; } }

        public Fraction() {
            _numerator = 1;
            _denominator = 1;
        }
        public Fraction(int numerator,int denominator)
        {
            if (denominator != 0)
            {
                _numerator = numerator;
                _denominator = denominator;
            }
            else
                throw new ArgumentException("Знаменатель не может быть равен 0");
        }

        static int LCD(int a,int b)
        {
            return a*b/GCD(a,b);
        }

        public Fraction Multi(Fraction f2)
        {
            return new Fraction(this.Numerator*f2.Numerator,this.Denominator*f2.Denominator);

        }
        public Fraction Div(Fraction f2)
        {
            return new Fraction(this.Numerator * f2.Denominator, this.Denominator * f2.Numerator);
        }
        public Fraction Add(Fraction f2)
        {
            //int lcdValue=LCD(this.Denominator, f2.Denominator);
            return new Fraction((this.Numerator * f2.Denominator + f2.Numerator * this.Denominator), this.Denominator * f2.Denominator);
        }
        public Fraction Sub(Fraction f2)
        {
            //int lcdvalue = lcd(this.denominator, f2.denominator);
            return new Fraction((this.Numerator*f2.Denominator - f2.Numerator*this.Denominator), this.Denominator*f2.Denominator);
        }

        static int GCD(int a,int b)
        {
            if (a == 0)
                return b;
            return GCD(b % a, a);
        }
        public static void MakeFractionSimple(Fraction f)
        {
            int nod = GCD(f._denominator, f._numerator);
            f._denominator /= nod;
            f._numerator /= nod;
        }
        public override string ToString()
        {
            return this.Numerator.ToString() +"/"+ this.Denominator.ToString();
        }
    }
}
