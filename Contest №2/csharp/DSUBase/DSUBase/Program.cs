using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSUBase
{
    internal class Program
    {
        static int[] parent, size, min, max;

        static int Find(int x)
        {
            if (x == parent[x]) return x;
            return parent[x] = Find(parent[x]); // path compression
        }

        static void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return;

            // union by size (чтобы дерево не росло слишком высоко)
            if (size[x] < size[y])
            {
                int tmp = x;
                x = y;
                y = tmp;
            }

            parent[y] = x;
            size[x] += size[y];
            min[x] = Math.Min(min[x], min[y]);
            max[x] = Math.Max(max[x], max[y]);
        }

        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            parent = new int[n + 1];
            size = new int[n + 1];
            min = new int[n + 1];
            max = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                parent[i] = i;
                size[i] = 1;
                min[i] = i;
                max[i] = i;
            }

            List<string> result = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                var parts = line.Split();

                if (parts[0] == "union")
                {
                    int x = int.Parse(parts[1]);
                    int y = int.Parse(parts[2]);
                    Union(x, y);
                }
                else if (parts[0] == "get")
                {
                    int x = int.Parse(parts[1]);
                    int root = Find(x);
                    result.Add($"{min[root]} {max[root]} {size[root]}");
                }
            }

            foreach (var res in result)
            {
                Console.WriteLine(res.ToString());
            }
        }
    }
}
