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
        private Stack<int> stack;

        public DFS(Graph g)
        {
            visited = new bool[g.n];
            this.g = g;
        }

        public void StartDFS(int u)
        {
            visited = new bool[g.n];
            stack = new Stack<int>();

            int index = g.getIndexFromVertextName(u);

            if (index >= 0)
                DfsUseStack(index);
            else
                Console.WriteLine("Vertex not exist");
        }

        private void DfsUseStack(int start)
        {
            visited[start] = true;
            stack.Push(start);
            Console.Write(g.vertices[start] + "\t");

            while (stack.Count > 0)
            {
                int u = stack.Pop();

                for (int v = 0; v < g.n; ++v)
                    if (g[u, v] > 0 && visited[v] == false)
                    {
                        Console.WriteLine(g.vertices[v] + "\t");
                        visited[v] = true;
                        stack.Push(u);
                        stack.Push(v);
                        break;
                    }
            }
        }
    }
}
