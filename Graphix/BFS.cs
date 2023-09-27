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

        public BFS(Graph g)
        {
            this.g = g;
        }

        public void StartBFS(int startVertex)
        {
            bool[] visited = new bool[g.n];
            Queue<int> queue = new Queue<int>();

            var watch = Stopwatch.StartNew();

            queue.Enqueue(startVertex);
            visited[startVertex] = true;

            while (queue.Count > 0)
            {
                int u = queue.Dequeue();
                //Console.Write(g.vertices[u] + "\t");

                for (int v = 0; v < g.n; ++v)
                    if (g[u, v] > 0 && visited[v] == false)
                    {
                        visited[v] = true;
                        queue.Enqueue(v);
                    }
            }

            watch.Stop();
            Console.WriteLine("BFS");
            Console.WriteLine((watch.ElapsedMilliseconds / 1000) + " giây");
        }
    }
}
