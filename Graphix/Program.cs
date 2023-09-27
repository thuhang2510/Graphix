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
            Graph graph = null;
            FileManager fileManager;

            while (true)
            {
                Console.WriteLine("1. Tao do thi random");
                Console.WriteLine("2. Them dinh vao do thi");
                Console.WriteLine("3. Them canh vao do thi");
                Console.WriteLine("4. Xoa dinh");
                Console.WriteLine("5. Cap nhat ten dinh");
                Console.WriteLine("6. Xoa canh");
                Console.WriteLine("7. Cap nhat trong so canh");
                Console.WriteLine("8. Luu do thi vao file");
                Console.WriteLine("9. Doc do thi tu file");
                Console.WriteLine("10. Duyet do thi theo DFS");
                Console.WriteLine("11. Duyet do thi theo BFS");
                Console.WriteLine("12. Hien thi ma tran");
                Console.WriteLine("0. Exit");

                Console.WriteLine("Nhap so: ");
                int n = int.Parse(Console.ReadLine());

                switch(n)
                {
                    case 1:
                        Console.WriteLine("Nhap so luong dinh: ");
                        int sl = int.Parse(Console.ReadLine());
                        graph = new Graph(sl);
                        graph.RandomVertext(sl);
                        graph.RandomCanh(sl);
                        break;
                    case 2:
                        if (graph == null)
                            graph = new Graph();
                        Console.WriteLine("Nhap ten dinh: ");
                        int vertex = int.Parse(Console.ReadLine());
                        graph.AddVertex(vertex);
                        break;
                    case 3:
                        Console.WriteLine("Nhap ten dinh dau: ");
                        int vertexStart = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap ten dinh cuoi: ");
                        int vertexEnd = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap ten trong so: ");
                        int weight = int.Parse(Console.ReadLine());
                        graph.AddEdge(vertexStart, vertexEnd, weight);
                        break;
                    case 4:
                        Console.WriteLine("Nhap ten dinh can xoa: ");
                        vertex = int.Parse(Console.ReadLine());
                        graph.RemoveVertex(vertex);
                        break;
                    case 5:
                        Console.WriteLine("Nhap ten dinh can cập nhật: ");
                        int vertexOld = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap ten dinh moi: ");
                        int vertexNew = int.Parse(Console.ReadLine());
                        graph.UpdateVertex(vertexOld, vertexNew);
                        break;
                    case 6:
                        Console.WriteLine("Nhap ten dinh dau: ");
                        vertexStart = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap ten dinh cuoi: ");
                        vertexEnd = int.Parse(Console.ReadLine());
                        graph.RemoveEdge(vertexStart, vertexEnd);
                        break;
                    case 7:
                        Console.WriteLine("Nhap ten dinh dau: ");
                        vertexStart = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap ten dinh cuoi: ");
                        vertexEnd = int.Parse(Console.ReadLine());
                        Console.WriteLine("Nhap trong so moi: ");
                        int weightNew = int.Parse(Console.ReadLine());
                        graph.UpdateCanh(vertexStart, vertexEnd, weightNew);
                        break;
                    case 8:
                        fileManager = new FileManager();
                        fileManager.WriteFiles(graph, Ultils.CreateFileName());
                        break;
                    case 9:
                        Console.WriteLine("Nhap ten file trong so: ");
                        string fileWeight = Console.ReadLine();
                        Console.WriteLine("Nhap ten file ten dinh: ");
                        string fileVertex = Console.ReadLine();

                        fileManager = new FileManager();
                        (graph, _, _) = fileManager.ReadFiles(fileWeight, fileVertex);
                        break;
                    case 10:
                        Console.WriteLine("Nhap ten dinh bat dau: ");
                        vertexStart = int.Parse(Console.ReadLine());
                        DFS dFS = new DFS(graph);
                        dFS.StartDFS(vertexStart);
                        break;
                    case 11:
                        Console.WriteLine("Nhap ten dinh bat dau: ");
                        vertexStart = int.Parse(Console.ReadLine());
                        BFS bFS = new BFS(graph);
                        bFS.StartBFS(vertexStart);
                        break;
                    case 12:
                        graph.DisplayMatrix();
                        break;
                    case 0:
                        return;
                    default:
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
