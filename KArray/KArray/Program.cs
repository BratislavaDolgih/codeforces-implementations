using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KArray
{
    class Program
    {
        static void Main()
        {
            var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = nk[0];
            int k = nk[1];
            var arr = Console.ReadLine().Split().Select(long.Parse).ToArray();

            long left = arr.Max();
            long right = arr.Sum();
            long answer = right;

            while (left <= right)
            {
                long mid = (left + right) / 2;
                if (CanSplit(arr, k, mid))
                {
                    answer = mid;
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            Console.WriteLine(answer);
        }

        static bool CanSplit(long[] arr, int k, long maxSum)
        {
            int count = 1;
            long current = 0;
            foreach (var x in arr)
            {
                if (current + x > maxSum)
                {
                    count++;
                    current = x;
                    if (count > k) return false;
                }
                else
                {
                    current += x;
                }
            }
            return true;
        }
    }
}