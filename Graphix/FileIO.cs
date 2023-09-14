using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphix
{
    internal class FileIO
    {
        public static (string, int) WriteFile(string fileName, string[] lines)
        {
            try
            {
                File.WriteAllLines(fileName, lines);
            }
            catch (IOException e)
            {
                return (e.Message, -1);
            }

            return ("write data to file success", 0);
        }

        public static (string, int) DeleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
            }
            catch (IOException e)
            {
                return (e.Message, -1);
            }

            return ("delete file success", 0);
        }

        public static (string[], int) ReadFile(string fileName)
        {
            string[] lines;

            try
            {
                lines = File.ReadAllLines(fileName);
            }
            catch (IOException)
            {
                return (null, -1);
            }

            return (lines, 0);
        }
    }
}
