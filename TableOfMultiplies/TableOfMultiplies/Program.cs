using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableOfMultiplies
{
    internal class Program
    {
        static long countLess(int n, long k)
        {
            long count = 0;
            for (int i = 1; i <= n; i++)
            {
                long val = Math.Min(n, k / i);
                count += val;
            //    Console.WriteLine($"i={i}, k/i={k / i}, min={val}");
            }
            return count;
        }

        static long TableBinarySearch(int n, long k)
        {
            long left = 0, right = (long)n * n;
            while (left < right)
            {
                long middle = (left + right) / 2;
                if (countLess(n , middle) < k)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle;
                }
            }

            return left;
        }

        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int n = int.Parse(tokens[0]);
            long k = long.Parse(tokens[1]);

            Console.WriteLine(TableBinarySearch(n, k));
        }
    }
}
