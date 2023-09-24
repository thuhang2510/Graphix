using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Graphix
{
    internal class FileManager
    {
        public (string, int) WriteFiles(Graph graph, string fileName)
        {
            string weightFilename = fileName + "_M.txt";
            string vertexFilenam = fileName + "_V.txt";

            (string message, int code) = FileIO.WriteFile(vertexFilenam, Ultils.ConvertToArrString(graph.vertices));

            if (code == 0)
            {
                (message, code) = FileIO.WriteFile(weightFilename, Ultils.ConvertToArrString(graph.weights));

                if (code != 0)
                    FileIO.DeleteFile(vertexFilenam);
            }

            return (message, code);
        }

        public (Graph, string, int) ReadFiles(string weightFilename, string vertexFilename)
        {
            (string[] matrixFileLines, int matrixCode) = FileIO.ReadFile(weightFilename);

            if (matrixCode != 0)
                return (null, "read file fail", -1);

            (string[] vertexFileLines, int vertexCode) = FileIO.ReadFile(vertexFilename);

            if (vertexCode != 0)
                return (null, "read file fail", -1);

            if (matrixFileLines[0] != vertexFileLines[0])
                return (null, "number vertices in files not match", -1);

            return (Ultils.ConvertToGraph(matrixFileLines, vertexFileLines), "read file success", 0);
        }
    }
}
