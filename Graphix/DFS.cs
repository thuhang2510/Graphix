using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphix
{
    internal class DFS
    {
        private Graph g;
        private bool[] visited;

        public DFS(Graph g)
        {
            visited = new bool[g.n];
            this.g = g;
        }

        public void StartDFS(int u)
        {
            visited = new bool[g.n];
            Dfs(u);
        }

        private void Dfs(int u)
        {
            visited[u] = true;
            Console.WriteLine(g.vertices[u]);

            for (int v = 0; v < g.n; ++v)
                if (g[u, v] > 0 && visited[v] == false)
                    Dfs(v);
        }
    }
}
