using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPDSU
{
    internal class Program
    {
        static void Main()
        {
            string[] tokens = Console.ReadLine().Split();
            DSUxp dsu = new DSUxp(int.Parse(tokens[0]));

            List<int> res = new List<int>();
            int m = int.Parse(tokens[1]);

            for (int i = 0; i < m; i++)
            {
                string[] line = Console.ReadLine().Trim().Split();

                if (line[0] == "join")
                {
                    dsu.Union(int.Parse(line[1]), int.Parse(line[2]));
                }
                else if (line[0] == "add")
                {
                    dsu.AddXp(int.Parse(line[1]), int.Parse(line[2]));
                }
                else
                {
                    res.Add(dsu.GetXp(int.Parse(line[1])));
                }
            }

            foreach (var r in res)
            {
                Console.WriteLine(r);
            }
        }
    }

    class DSUxp
    {
        private readonly int[] parent;
        private readonly int[] rank;
        private readonly int[] deltaXp;
        private readonly int[] clanXp;
        private readonly int n;

        public DSUxp(int n)
        {
            this.n = n;
            parent = new int[n + 1];
            rank = new int[n + 1];
            deltaXp = new int[n + 1];
            clanXp = new int[n + 1];
            for (int i = 1; i <= n; i++) parent[i] = i;
        }

        public int Find(int x)
        {
            if (parent[x] != x)
            {
                int root = Find(parent[x]);
                deltaXp[x] += deltaXp[parent[x]];
                parent[x] = root;
            }
            return parent[x];
        }

        public void Union(int x, int y)
        {
            x = Find(x);
            y = Find(y);
            if (x == y) return;

            if (rank[x] < rank[y])
            {
                int temp = x;
                x = y;
                y = temp;
            }

            parent[y] = x;
            deltaXp[y] = clanXp[y] - clanXp[x];

            if (rank[x] == rank[y]) rank[x]++;
        }

        public void AddXp(int x, int v)
        {
            int root = Find(x);
            clanXp[root] += v;
        }

        public int GetXp(int x)
        {
            Find(x);
            return clanXp[parent[x]] + deltaXp[x];
        }
    }
}
