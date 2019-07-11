using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func
{
    class Program
    {
        static double a;
        static double b;
        static double e;
        static double x0;

        static double f(double x) //Math.Sqrt(x + 1) - 1 / x
        {
            return (5*x-8*Math.Log(x)-8);
        }

        static double Proizv(double x) //1 / (2 * Math.Sqrt(x + 1)) + 1 / (x * x)
        {
            return 8/5*x;
        }

        static double Fi(double x) //1 / Math.Sqrt(x + 1)
        {
            return 8+8*Math.Log(x)/5;
            //return (Math.Sqrt(Math.Sin(x)));
        }

        static void Dih()
        { 
            double c;
            int s = 0;
            while (true)
            {
                s++;
                c = (a + b) / 2;
                Console.WriteLine("x" + s + ": " + c);
                if (Math.Abs(f(c)) < e) break;
                if (f(a) * f(c) < 0) b = c;
                else a = c;
            }
            Console.WriteLine("Итог : " + c);
            Console.WriteLine("Кол-во итераций: " + s);
        }

        static void Nuton()
        {
            double xn = x0;
            double xn1;
            int s = 0;                           
            while (true)
            {
                s++;
                xn1 = xn - f(xn) / Proizv(xn);
                Console.WriteLine("x" + s + ": " + xn1);
                if (Math.Abs((xn1 - xn)) < e) break;
                xn = xn1;
            }
            Console.WriteLine("Итог : " + xn1);
            Console.WriteLine("Кол-во итераций: " + s);
        }

        static void Simple()
        {
            int s = 0;
            double xn = x0;
            double xn1;
            while (true)
            {
                s++;
                xn1 = Fi(xn);
                Console.WriteLine("x" + s + ": " + xn1);
                if (Math.Abs(xn - xn1) < e)
                    break;
                xn = xn1;
            }
            Console.WriteLine("Итог: " + xn1);
            Console.WriteLine("Кол-во итераций: " + s);
        }

        static void Main(string[] args)
        {
            a = 3.5;
            b = 4;
            e = 0.001;
            x0 = (a + b) / 2;
            //Console.WriteLine("Метод дихотомии:");
            //Dih();
            Console.WriteLine("");
            Console.WriteLine("Метод простых итераций:");
            Simple();
            //Console.WriteLine("");
            //Console.WriteLine("Метод Ньютона:");
            //Nuton();
        }
    }
}
