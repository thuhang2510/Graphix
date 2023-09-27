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
        public int[,] weights { get; private set; }
        public List<int> vertices { get; private set; }

        public Graph(int n = 0)
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

        private int[,] IncreaseArraySize()
        {
            int[,] newArray = new int[n + 1, n + 1];

            for (int i = 0; i < n; ++i)
                for (int j = 0; j < n; ++j)
                    newArray[i, j] = weights[i, j];

            for (int i = 0; i < n + 1; ++i)
            {
                newArray[i, n] = 0;
                newArray[n, i] = 0;
            }

            return newArray;
        }

        public void AddVertex(int vertexName)
        {
            weights = IncreaseArraySize();

            vertices.Add(vertexName);
            ++n;
        }

        private bool IsVertext(int vertextName)
        {
            for (int i = 0; i < n; i++)
            {
                if (vertices[i] == vertextName)
                    return true;

            }

            return false;
        }

        public int getIndexFromVertextName(int vertextName)
        {
            for (int i = 0; i < n; i++)
                if (vertices[i] == vertextName)
                    return i;

            return -1;
        }

        private int[,] ReduseArraySize(int index)
        {
            int[,] newArray = new int[n - 1, n - 1];

            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - 1; j++)
                {
                    if (i < index && j >= index)
                        newArray[i, j] = weights[i, j + 1];
                    else if (i >= index && j < index)
                        newArray[i, j] = weights[(i + 1), j];
                    else if (i >= index && j >= index)
                        newArray[i, j] = weights[(i + 1), (j + 1)];
                    else newArray[i, j] = weights[i, j];
                }

            return newArray;
        }


        public void RemoveVertex(int vertexName)
        {
            // kiem tra xem ten dinh con ton tai khong
            if (!IsVertext(vertexName))
            {
                Console.Write("\n Verter khong ton tai!");
                return;
            }
            else
            {
                int index = getIndexFromVertextName(vertexName);
                if (index != -1)
                {
                    vertices.RemoveAt(index);
                    weights = ReduseArraySize(index);
                    n--;
                }
            }
        }


        public void UpdateVertex(int oldvVertextName, int newVertextName)
        {
            //kiem tra xem ten con ton tai khong
            if (!IsVertext(oldvVertextName) || (IsVertext(newVertextName)))
            {
                Console.Write("\n Verter khong ton tai!");
                return;
            }
            int index = getIndexFromVertextName(oldvVertextName);

            if (index != -1)
            {
                vertices[index] = newVertextName;
            }

        }

        public void RandomVertext(int n)
        {
            Random random = new Random();

            for (int i = 1; i <= n; i++)
            {
                vertices.Add(random.Next(1000));
            }

        }

        public void DisplayMatrix()
        {
            Console.WriteLine("Ma tran");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(weights[i, j] + "\t");

                Console.WriteLine();
            }
        }

        public void DisplayVertices()
        {
            Console.WriteLine("Danh sach ten dinh");

            foreach (int i in vertices)
                Console.Write(i + "\t");

            Console.WriteLine();
        }

        public void AddEdge(int dinhdau, int dinhden, int trongso)
        {
            int dinhDauIndex = -1;
            int dinhDenIndex = -1;
            // Tìm chỉ số (index) của đỉnh đầu và đỉnh đích trong danh sách đỉnh
            for (int i = 0; i < n; i++)
            {
                if (vertices[i] == dinhdau)
                {
                    dinhDauIndex = i;
                }

                if (vertices[i] == dinhden)
                {
                    dinhDenIndex = i;
                }
            }
            if (dinhDauIndex != -1 && dinhDenIndex != -1)
            {
                weights[dinhDauIndex, dinhDenIndex] = trongso;
                // adjacencyMatrix[dinhDenIndex, dinhDauIndex] = trongso; // Đối xứng cho đồ thị vô hướng
            }
            else
            {
                Console.WriteLine("Dinh nguon hoac dinh dich khong hop le.");
            }


        }


        public void RandomCanh(int canh)

        {
            Random random = new Random();  // 
            for (int i = 0; i < n; i++)  // Số cạnh ngẫu nhiên
            {
                int dinhDau = random.Next(n);  // Lựa chọn ngẫu nhiên một đỉnh đầu
                int dinhDen = random.Next(n); // Lựa chọn ngẫu nhiên một đỉnh đích
                int trongSo = random.Next(1, 11);       // Trọng số ngẫu nhiên từ 1 đến 10

                AddEdge(vertices[dinhDau], vertices[dinhDen], trongSo);
            }

        }


        public void UpdateCanh(int dinhdau, int dinhden, int trongsomoi)
        {
            int dinhDauIndex = -1;
            int dinhDenIndex = -1;
            for (int i = 0; i < n; i++)
            {
                if (vertices[i] == dinhdau)
                {
                    dinhDauIndex = i;
                }

                if (vertices[i] == dinhden)
                {
                    dinhDenIndex = i;
                }
            }
            if (dinhDauIndex != -1 && dinhDenIndex != -1)
            {
                weights[dinhDauIndex, dinhDenIndex] = trongsomoi;
            }
            else
            {
                Console.WriteLine("Dinh nguon hoac dinh dich khong hop le.");
            }
        }


        public void RemoveEdge(int dinhdau, int dinhden)
        {
            int dinhDauIndex = -1;
            int dinhDenIndex = -1;
            // Tìm chỉ số (index) của đỉnh đầu và đỉnh đích trong danh sách đỉnh
            for (int i = 0; i < n; i++)
            {
                if (vertices[i] == dinhdau)
                {
                    dinhDauIndex = i;
                }

                if (vertices[i] == dinhden)
                {
                    dinhDenIndex = i;
                }
            }
            if (dinhDauIndex != -1 && dinhDenIndex != -1)
            {
                weights[dinhDauIndex, dinhDenIndex] = 0;
                // adjacencyMatrix[dinhDenIndex, dinhDauIndex] = trongso; // Đối xứng cho đồ thị vô hướng
            }
            else
            {
                Console.WriteLine("Dinh nguon hoac dinh dich khong hop le.");
            }

        }
    }
}
