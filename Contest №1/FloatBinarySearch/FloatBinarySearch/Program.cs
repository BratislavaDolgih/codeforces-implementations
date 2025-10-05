using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatBinarySearch
{
    internal class Program
    {
        static int[] Bisection(int[] incArr, int[] req)
        {
            int[] returnableArray = new int[req.Length];
            
            for (int i = 0; i < req.Length; i++)
            {
                returnableArray[i] = GetApproximate(incArr, req[i]);
            }

            return returnableArray;
        }

        private static int GetApproximate(int[] inc, int request)
        {
            int l = 0, r = inc.Length - 1;

            while (r >= l)
            {
                int middle = (l + r) / 2;
                if (inc[middle] == request) { return inc[middle]; }

                if (inc[middle] < request)
                {
                    l = middle + 1;
                }
                else
                {
                    r = middle - 1;
                }
            }

            if (r < 0) { return inc[0]; };
            if (l >= inc.Length) { return inc[inc.Length - 1]; } 

            int leftEl = inc[r], rightEl = inc[l];

            return Math.Abs(leftEl - request) <= Math.Abs(rightEl - request)
                ? leftEl
                : rightEl;
        }

        static void PrintResults(int[] results)
        {
            foreach (int res in results)
            {
                Console.WriteLine(res);
            }
        }

        static void Main(string[] args)
        {
            string[] firstTokens = Console.ReadLine().Split();
            int n = int.Parse(firstTokens[0]);
            int k = int.Parse(firstTokens[1]);

            int[] increaseArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] requests = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[] myResult = Bisection(increaseArray, requests);
            PrintResults(myResult);
        }
    }
}
