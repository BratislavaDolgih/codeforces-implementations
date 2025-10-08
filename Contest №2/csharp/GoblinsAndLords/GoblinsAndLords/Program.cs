using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinsAndLords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            // начало-середина
            LinkedList<int> left = new LinkedList<int>();
            // середина-конец
            LinkedList<int> right = new LinkedList<int>();
            List<int> goblins = new List<int>();

            for (int line = 0; line < n; ++line)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                int i;
                if (tokens[0].Equals("+"))
                {
                    i = int.Parse(tokens[1]);
                    right.AddLast(i);
                    if (left.Count < right.Count)
                    {
                        left.AddLast(right.First.Value);
                        right.RemoveFirst();
                    }
                } 
                else if (tokens[0].Equals("*"))
                {
                    i = int.Parse(tokens[1]);
                    if (left.Count > right.Count)
                    {
                        right.AddFirst(i);
                    }
                    else
                    {
                        left.AddLast(i);
                    }
                }
                else
                {
                    var goblinI = left.First.Value;
                    left.RemoveFirst();
                    goblins.Add(goblinI);
                    if (left.Count < right.Count)
                    {
                        left.AddLast(right.First.Value);
                        right.RemoveFirst();
                    }
                }
            }

            foreach (int gbl in goblins)
            {
                Console.WriteLine(gbl);
            }
        }
    }
}
