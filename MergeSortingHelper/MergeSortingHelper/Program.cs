using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortingHelper
{
    class MergeSorting
    {
        private MergeSorting() { }
        
        public static void MergeSort(int[] arr)
        {
            if (arr.Length < 2) return;

            int mid = arr.Length / 2;

            int[] left = new int[mid];
            Array.Copy(arr, 0, left, 0, mid);

            int remainingLength = arr.Length - mid;
            int[] right = new int[remainingLength];
            Array.Copy(arr, mid, right, 0, remainingLength);

            MergeSort(left);
            MergeSort(right);

            Merge(arr, left, right);
        }

        private static void Merge(int[] arr, int[] left,  int[] right)
        {
            int currentSize = arr.Length;
            int[] result = new int[currentSize];

            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                {
                    result[k++] = left[i++];
                } else
                {
                    result[k++] = right[j++];
                }
            }

            while (i < left.Length) { result[k++] = left[i++]; }
            while (j < right.Length) { result[k++] = right[j++]; }

            Array.Copy(result, arr, currentSize);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            MergeSorting.MergeSort(arr);
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
