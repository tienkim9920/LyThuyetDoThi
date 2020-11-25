using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai4
{
    class Graph
    {
        private int soDinh;
        private int soCanh;
        private int[,] arrGraph;

        public void ReadData(string fName)
        {
            StreamReader sr = new StreamReader(fName);
            string[] row = sr.ReadLine().Split();
            soDinh = int.Parse(row[0]);
            soCanh= int.Parse(row[1]);

            arrGraph = new int[soCanh, soCanh];
            for (int i = 0; i < soCanh; i++)
            {
                string[] line = sr.ReadLine().Split();
                for (int j = 0; j < line.Length; j++)
                {
                    arrGraph[i, j] = int.Parse(line[j]);

                }
            }
            sr.Close();
        }
        public void WriteData()
        {
            Console.WriteLine($"{soDinh}  {soCanh}");
            for (int i = 0; i < soCanh; i++)
            {
                for (int j = 0; j < soCanh; j++)
                {
                    if (arrGraph[i, j] != 0)
                        Console.Write($"{arrGraph[i, j]}  ");
                }
                Console.WriteLine();
            }
        }

        public void DanhSachCanh(string fName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fName))
            {
                for(int k = 1; k <= soDinh; k++)
                {
                    int count = 0;
                    for (int i = 0; i < soCanh; i++)
                    {
                        for (int j = 0; j < soCanh; j++)
                        {
                            if (arrGraph[i,j] == k)
                            {
                                count++;
                            }
                        }
                    }
                    streamWriter.Write(count + "  ");
                }
                
            }
        }
    }
}
