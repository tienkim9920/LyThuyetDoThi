using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai2
{
    class Graph
    {
        private int soDinh;
        private int[,] arrGraph;

        public void ReadData(string fName)
        {
            StreamReader streamReader = new StreamReader(fName);
            soDinh = int.Parse(streamReader.ReadLine());
            arrGraph = new int[soDinh + 1, soDinh + 1];
            for (int i = 0; i < soDinh; i++)
            {
                string[] line = streamReader.ReadLine().Split();
                for (int j = 0; j < line.Length; j++)
                {
                    arrGraph[i, j] = int.Parse(line[j]);
                }
            }
        }

        public void WriteData()
        {
            Console.WriteLine($"{soDinh}");
            for (int i = 0; i < soDinh; i++)
            {
                for (int j = 0; j < soDinh; j++)
                {
                    if (arrGraph[i, j] != 0)
                        Console.Write($"{arrGraph[i, j]}  ");
                }
                Console.WriteLine();
            }
        }

        public void CanhSangKe(string fName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fName))
            {
                streamWriter.WriteLine("{0,-3}{1}",soDinh,soDinh+1);
    

                for (int i = 0; i < soDinh + 1; i++)
                {
                    for (int j = 0; j < soDinh + 1; j++)
                    {
                        if (arrGraph[i, j] != 0&&arrGraph[i,j]>i+1)
                            streamWriter.WriteLine("{0,-3}{1}", i + 1,arrGraph[i,j]);
                    }

                }
            }
        }
    }
}
