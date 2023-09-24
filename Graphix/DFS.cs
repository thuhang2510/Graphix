using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

            var watch = Stopwatch.StartNew();
            DfsUseStack(u);
            watch.Stop();
            Console.WriteLine("DFS");
            Console.WriteLine((watch.ElapsedMilliseconds / 1000) + " giây");
        }

        private void Dfs(int u)
        {
            visited[u] = true;
            Console.Write(g.vertices[u] + "\t");

            for (int v = 0; v < g.n; ++v)
                if (g[u, v] > 0 && visited[v] == false)
                    Dfs(v);
        }

        private void DfsUseStack(int start)
        {
            Stack<int> stack = new Stack<int>();
            visited[start] = true;
            stack.Push(start);

            while (stack.Count > 0)
            {
                int u = stack.Pop();

                for (int v = 0; v < g.n; ++v)
                    if (g[u, v] > 0 && visited[v] == false)
                    {
                        visited[v] = true;
                        stack.Push(u);
                        stack.Push(v);
                        break;
                    }
            }
        }
    }
}
