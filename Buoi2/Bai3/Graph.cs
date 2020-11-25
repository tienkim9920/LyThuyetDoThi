using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai3
{
    class Graph
    {
        private int soDinh;
        private int soCanh;
        private int[,] arrGraph;
        private int[] trongSo;

        public void ReadData(string fName)
        {

            trongSo =new int[]{7,9,4,10,10,8};

            StreamReader streamReader = new StreamReader(fName);
            string[] row = streamReader.ReadLine().Split();
            soDinh = int.Parse(row[0]);
            soCanh = int.Parse(row[1]);
            arrGraph = new int[soCanh, soCanh];
            for (int i = 0; i < soCanh; i++)
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

        public void DoDaiTrungBinhCanh(string fName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fName))
            {
                int max = 0;
                int maxcanh = 0;
                for (int i = 0; i <soCanh; i++)
                {
                        if (trongSo[i] > max)
                        {
                            max = trongSo[i];
                            maxcanh = arrGraph[i, 0];
                        }
                }
                streamWriter.WriteLine(maxcanh);
                for(int i = 0; i < soCanh; i++)
                {
                    if (trongSo[i] == max)
                    {
                       for(int j = 0; j < soCanh; j++)
                        {
                            if(arrGraph[i, j]!=0)
                                streamWriter.Write("{0,-3}",arrGraph[i,j]);
                        }
                        streamWriter.Write(max);
                        streamWriter.WriteLine();
                    }
                   
                }
            }
        }

      
    }
}
