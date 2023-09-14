using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Graphix
{
    internal class FileManager
    {
        public (string, int) CreateFiles(Graph graph, string fileName)
        {
            string maxtrixFilename = fileName + "_M.txt";
            string verticeFilename = fileName + "_V.txt";

            (string message, int code) = FileIO.WriteFile(verticeFilename, Ultils.ConvertToArrString(graph.vertices));

            if (code == 0)
            {
                (message, code) = FileIO.WriteFile(maxtrixFilename, Ultils.ConvertToArrString(graph.weights));

                if (code != 0)
                    return FileIO.DeleteFile(verticeFilename);
            }

            return (message, code);
        }

        public (Graph, int) ReadFiles(string matrixFilename, string vertexFilename)
        {
            (string[] matrixFileLines, int matrixCode) = FileIO.ReadFile(matrixFilename);
            (string[] vertexFileLines, int vertexCode) = FileIO.ReadFile(vertexFilename);

            if (matrixCode != 0 || vertexCode != 0)
                return (null, -1);

            int n = int.Parse(matrixFileLines[0]);
            Graph graph = new Graph(n);

            for (int i = 1; i < matrixFileLines.Length; ++i)
            {
                string[] weightsInLine = Ultils.SplitListStr(matrixFileLines[i]);

                for (int j = 0; j < n; ++j)
                    graph[i - 1, j] = int.Parse(weightsInLine[j]);

                graph.vertices.Add(int.Parse(vertexFileLines[i]));
            }

            return (graph, 0);
        }
    }
}
