﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphix
{
    internal class Ultils
    {
        public static string[] ConvertToArrString(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            string[] lines = new string[n + 1];
            lines[0] = n.ToString();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    lines[i + 1] += matrix[i, j] + "\t";
            }

            return lines;
        }

        public static string[] ConvertToArrString(List<int> dinhs)
        {
            int n = dinhs.Count;
            string[] lines = new string[n + 1];
            lines[0] = n.ToString();

            for (int i = 0; i < n; i++)
                lines[i + 1] += dinhs[i].ToString();

            return lines;
        }

        public static string CreateFileName()
        {
            DateTimeOffset date = (DateTimeOffset)DateTime.UtcNow;
            return date.ToUnixTimeSeconds().ToString();
        }

        public static string[] SplitListStr(string fileLine)
        {
            char[] sep = new char[] { ' ', '\t' };

            return fileLine.Trim().Split(sep, System.StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
