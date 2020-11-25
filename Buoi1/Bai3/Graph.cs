using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai3
{
    class Graph
    {
        private int n;
        private int[,] arrGraph;

        public void ReadData(string fName)
        {
            StreamReader sr = new StreamReader(fName);
            n = int.Parse(sr.ReadLine());
            arrGraph = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                int[]line= sr.ReadLine().Split();
                for (int j = 0; j < line.Length; j++)
                {
                        arrGraph[i, j] = int.Parse(line[j]);
                        
                }
            }
            sr.Close();
        }
        public void WriteData()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(arrGraph[i,j]!=0)
                        Console.Write($"{arrGraph[i, j]}  ");
                }
                Console.WriteLine();
            }
        }
        public void DanhSachKe(string fName)
        {
            using (StreamWriter sWriter = new StreamWriter(fName))
            {
                sWriter.WriteLine(n);
                for (int i = 0; i < n; i++)
                {
                    int count = 0;
                    for (int j = 0; j < n; j++)
                        if (arrGraph[i, j] != 0)
                        {
                            count++;
                        }
                    sWriter.Write($"{count}  ");
                }
            }
        }
    }
}
