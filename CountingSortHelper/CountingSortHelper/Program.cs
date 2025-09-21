using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSortHelper
{
    class CountSort
    {
        private CountSort() { }

        public static void CountingSort(byte[] arr)
        {
            if (arr.Length == 0) { return; }

            byte min = arr[0], max = arr[0];
            foreach (byte b in arr)
            {
                if (min > b) { min = b; }
                if (max < b) { max = b; }
            }

            int rangeOfCountingArray = max - min + 1;

            int[] countArr = new int[rangeOfCountingArray];

            foreach (byte num in arr)
            {
                countArr[num - min]++;
            }

            int index = 0;
            for (int i = 0; i < rangeOfCountingArray; i++)
            {
                while (countArr[i] > 0)
                {
                    arr[index++] = (byte)(i + min);
                    countArr[i]--;
                }
            }
        }

        public static void Print(byte[] arr)
        {
            foreach (byte cur in arr)
            {
                Console.Write($"{cur} ");
            }
            Console.WriteLine();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            byte[] myArr = Console.ReadLine().Split().Select(byte.Parse).ToArray();
            CountSort.CountingSort(myArr);
            CountSort.Print(myArr);
        }
    }
}
