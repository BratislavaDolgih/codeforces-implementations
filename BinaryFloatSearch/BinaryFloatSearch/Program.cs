using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryFloatSearch
{
    internal class Program
    {
        private const double EPSILON = 1e-7;
        static double BinarySolve(double C)
        {
            // Так как наша функция имеет вид x^2 + sqrt(x) = C, то
            // Начало промежутка = 0. 
            // Конец будет именно в С!

            double l = 0.0;  // Подсчёт значения под левую границу.
            double r = Math.Max(1.0, C); // Подсчёт значения под правую границу.

            /*
             По теореме Больцано-Вейерштрасса, если на концах будет разный знак,
            то имеется по крайней мере одно решение.

            Примем за то, что в задаче это выполняется.
             */

            // Приближаемся, пока не подгоним x под эпсилон.
            while (r - l > EPSILON)
            {
                double mid = (l + r) / 2.0;
                double fMid = mid*mid + Math.Sqrt(mid) - C;

                // Согласно теореме, там, где ноль = решение.
                if (Math.Abs(fMid) < EPSILON) { return mid; }

                if (fMid > 0)
                {
                    r = mid;
                }
                else
                {
                    l = mid;
                }
            }

            return (l + r) / 2.0;
        }
        
        static void Main(string[] args)
        {
            double C = double.Parse(Console.ReadLine());

            double x = BinarySolve(C);
            Console.WriteLine($"{x:F6}");
        }
    }
}
