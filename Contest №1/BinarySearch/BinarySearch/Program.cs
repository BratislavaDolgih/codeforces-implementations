using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    internal class Program
    {
        static int BinarySearchInRange(int[] arr, int l, int r)
        {
            int leftIndex = 0, rightIndex = arr.Length - 1;

            int left = 0, right = arr.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid] < l)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            int start = left;

            left = 0; right = arr.Length;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (arr[mid] <= r)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }
            int end = left;

            return end - start;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(arr);
            
            int k = int.Parse(Console.ReadLine());
            List<int[]> list = new List<int[]>(k);
            List<int> resultValues = new List<int>(k);

            for (int i = 0; i < k; ++i)
            {
                string[] tokens = Console.ReadLine().Split();
                list.Add(new int[] { int.Parse(tokens[0]), int.Parse(tokens[1]) });
                resultValues.Add(BinarySearchInRange(arr, list[i][0], list[i][1]));
            }
            
            foreach (int res in resultValues)
            {
                Console.Write($"{res} ");
            }
            Console.WriteLine();
        }
    }
}
