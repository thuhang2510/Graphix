using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphix
{
    internal class Graph
    {
        public int n { get; private set; }
        public int[,] weights { get; set; }
        public List<int> vertices { get; set; }

        public Graph(int n)
        {
            this.n = n;
            weights = new int[n, n];
            vertices = new List<int>();
        }

        public int this[int u, int v]
        {
            get { return weights[u, v]; }
            set { weights[u, v] = value; }
        }
    }
}
