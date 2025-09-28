using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TernarySearchTask
{
    internal class Program
    {
        static double T(double x, double a, int Vp, int Vf)
        {
            return Math.Sqrt(x * x + (1 - a) * (1 - a)) / Vp +
                Math.Sqrt((1 - x) * (1 - x) + a * a) / Vf;
        }

        static double TernarySearch(double left, double right, double eps,
            double a, int Vp, int Vf)
        {
            while (right - left > eps)
            {
                double mid1 = left + (right - left) / 3;
                double mid2 = right - (right - left) / 3;

                if (T(mid1, a, Vp, Vf) < T(mid2, a, Vp, Vf))
                {
                    right = mid2;
                }
                else
                {
                    left = mid1;
                }
            }

            return (left + right) / 2;
        }
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int velocityP = int.Parse(tokens[0]);
            int velocityF = int.Parse(tokens[1]);
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine($"{TernarySearch(0, 1, 1e-7, a, velocityP, velocityF):F6}");
        }
    }
}
