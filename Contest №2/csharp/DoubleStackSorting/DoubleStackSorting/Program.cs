using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleStackSorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());
            Stack<short> A = new Stack<short>(Console.ReadLine().Split().Select(short.Parse).Reverse());
            Stack<short> B = new Stack<short>();

            short currentSortedMinimum = -1;
            List<string> track = new List<string>();

            for (int i = 0; i < n; ++i)
            {
                var popA = A.Pop();

                while (B.Count > 0 && popA > B.Peek())
                {
                    currentSortedMinimum = B.Pop();
                    track.Add("pop");
                }

                if (currentSortedMinimum > popA)
                {
                    Console.WriteLine("impossible");
                    return;
                }

                track.Add("push");
                B.Push(popA);
            }

            while (B.Count > 0)
            {
                B.Pop();
                track.Add("pop");
            }

            foreach (string resp in track)
            {
                Console.WriteLine($"{resp}");
            }
        }
    }
}
