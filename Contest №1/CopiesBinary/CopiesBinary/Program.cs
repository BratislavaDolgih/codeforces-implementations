using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopiesBinary
{
    internal class Program
    {
        static void BinarySearchOfCopies(int amount, byte firstXerox, byte secondXerox)
        {
            long n = amount - 1;

            long left = 0;
            long right = (long) n * Math.Max(firstXerox, secondXerox);

            while (left < right)
            {
                long middle = (left + right) / 2;
                long copies = middle / firstXerox + middle / secondXerox;

                if (copies >= n)
                {
                    right = middle;
                }
                else
                {
                    left = middle + 1;
                }
            }
            Console.WriteLine(left + Math.Min(firstXerox, secondXerox));
        }
        static void Main(string[] args)
        {
            string[] tokens = Console.ReadLine().Split();
            int n = int.Parse(tokens[0]);
            byte x = byte.Parse(tokens[1]);
            byte y = byte.Parse(tokens[2]);

            BinarySearchOfCopies(n, x, y);
        }
    }
}
