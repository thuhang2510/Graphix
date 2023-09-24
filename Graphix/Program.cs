using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int N = 10000;
            int[,] mx = new int[N, N];

            for (int i = 0; i < N; ++i)
                for (int j = 0; j < N; ++j)
                    if (i != j) mx[i, j] = 1;

            List<int> m = new List<int>(N);
            for(int i = 0; i < N; ++i)
                m.Add(i);*/

            /*int[,] mx = new int[4, 4]
                                   {{ 0   ,1   ,1   ,0 },
                                    { 1   ,0   ,0   ,1 },
                                    { 1   ,0   ,0   ,1 },
                                    { 0   ,1   ,1   ,0 } };

            List<int> m = new List<int>();
            m.Add(77);
            m.Add(7);
            m.Add(1);
            m.Add(100);*/

            int N = 21000;
            int[,] mx = new int[N, N];

            for (int i = 0; i < N - 1; ++i)
                mx[i, i + 1] = 1;

            List<int> m = new List<int>(N);
            for (int i = 0; i < N; ++i)
                m.Add(i);

            Graph graph = new Graph(N);
            graph.weights = mx;
            graph.vertices = m;

            DFS dfs = new DFS(graph);
            dfs.StartDFS(0);

            //BFS dfs2 = new BFS(graph);
            //dfs2.StartBFS(0);

            //FileManager fileManager = new FileManager();
            //fileManager.CreateFiles(graph, Ultils.CreateFileName());
            //fileManager.ReadFiles("1694704347_M.txt", "1694704347_V.txt");
        }
    }
}
