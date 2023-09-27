using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphix
{
    internal class BFS
    {
        private Graph g;
        private bool[] visited;
        private Queue<int> queue;

        public BFS(Graph g)
        {
            this.g = g;
        }

        public void StartBFS(int nameStartVertex)
        {
            visited = new bool[g.n];
            queue = new Queue<int>();

            int index = g.getIndexFromVertextName(nameStartVertex);

            if (index >= 0)
                Bfs(index);
            else
                Console.WriteLine("Vertex not exist");
        }

        private void Bfs(int startVertex)
        {
            queue.Enqueue(startVertex);
            visited[startVertex] = true;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                Console.Write(g.vertices[u] + "\t");

                for (int v = 0; v < g.n; ++v)
                    if (g[u, v] > 0 && visited[v] == false)
                    {
                        visited[v] = true;
                        queue.Enqueue(v);
                    }
            }
        }
    }
}
