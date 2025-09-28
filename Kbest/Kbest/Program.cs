using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kbest
{
    public class Jewel
    {
        public int Index { get; private set; }
        public int V { get; private set; }
        public int W { get; private set; }
        public Jewel(int index, int v, int w)
        {
            Index = index;
            V = v;
            W = w;
        }
    }
    internal class Program
    {
        static List<int> Check(Jewel[] jws, int k, double x)
        {
            double[] diff = new double[jws.Length];
            for (int i = 0; i < jws.Length; ++i)
            {
                diff[i] = jws[i].V - x * jws[i].W;
            }

            int[] indeces = new int[jws.Length];
            for (int i = 0; i < jws.Length; ++i) { indeces[i] = i; }
            Array.Sort(indeces, (a, b) => diff[b].CompareTo(diff[a]));

            List<int> selected = new List<int>();
            for (int i = 0; i < k; ++i)
            {
                selected.Add(jws[indeces[i]].Index);
            }

            return selected; 
        }
        static void Main(string[] args)
        {
            string[] ts = Console.ReadLine().Split();
            int n = int.Parse(ts[0]);
            int k = int.Parse(ts[1]);

            Jewel[] jewels = new Jewel[n];
            for (int i = 0; i < n; i++)
            {
                ts = Console.ReadLine().Split();
                jewels[i] = new Jewel(i + 1, 
                    int.Parse(ts[0]),
                    int.Parse(ts[1]));
            }

            double left = 0, right = 1e6,
                eps = 1e-7;

            List<int> ans = null;

            while (right - left > eps)
            {
                double mid = (right + left) / 2.0;
                List<int> cand = Check(jewels, k, mid);

                double sumDiff = 0;
                foreach (var idx in cand)
                {
                    sumDiff += jewels[idx - 1].V - mid * jewels[idx - 1].W;
                }

                if (sumDiff > 0)
                {
                    left = mid;
                }
                else
                {
                    right = mid;
                }
                ans = cand;
            }

            foreach (int idx in ans)
            {
                Console.WriteLine(idx);
            }
        }
    }
}
