using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KSumm
{
    internal class Program
    {
        static long UpperBound(int[] b, long value)
        {
            int left = 0, right = b.Length;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (b[mid] <= value)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            return left;
        }

        static void BinarySummary(int n, 
            int[] firstArr, int[] secondArr, long selected)
        {
            long left = firstArr.Min() + secondArr.Min();
            long right = firstArr.Max() + secondArr.Max();
            long ans = 0;

            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                if (CountPairs(firstArr, secondArr, mid) >= selected)
                {
                    ans = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            Console.WriteLine(ans);
        }
        
        static long CountPairs(int[] a, int[] b, long x)
        {
            long result = 0;
            foreach (var valA in a)
            {
                long remaining = x - valA;
                result += UpperBound(b, remaining);
            }
            return result;
        }

        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int n = int.Parse(tokens[0]);
            long k = long.Parse(tokens[1]);

            int[] ai = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bi = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(bi);
            
            BinarySummary(n, ai, bi, k);
        }
    }
}
