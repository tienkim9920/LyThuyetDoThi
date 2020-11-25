using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Buoi2
{
    class Graph
    {
        private int soDinh;
        private int soCanh;
        private int[,] arrGraph;

        public void ReadData(string fName)
        {
            StreamReader streamReader = new StreamReader(fName);
            string[] row = streamReader.ReadLine().Split();
            soDinh = int.Parse(row[0]);
            soCanh = int.Parse(row[1]);
            arrGraph = new int[soCanh, soCanh];
            for(int i = 0; i < soCanh; i++)
            {
                string[] line = streamReader.ReadLine().Split();
                for(int j = 0; j < line.Length; j++)
                {
                    arrGraph[i, j] = int.Parse(line[j]);
                }
            }
        }

        public void WriteData()
        {
            Console.WriteLine($"{soDinh}  {soCanh}");
            for(int i = 0; i < soCanh; i++)
            {
                for(int j = 0; j < soCanh; j++)
                {
                    if(arrGraph[i,j]!=0)
                        Console.Write($"{arrGraph[i,j]}  ");
                }
                Console.WriteLine();
            }
        }

        public void CanhSangKe(string fName)
        {
            using (StreamWriter streamWriter=new StreamWriter(fName))
            {
                streamWriter.WriteLine(soDinh);
                for (int k = 1; k <= soDinh; k++)
                {
                    for (int i = 0; i < soCanh; i++)
                    {
                        int canhke = 0;
                        for (int j = 0; j < soCanh; j++)
                        {
                            if (arrGraph[i, j] == k)
                            {
                                if (arrGraph[i, j + 1] != 0)
                                {
                                    canhke = arrGraph[i, j + 1];
                                }
                                else canhke = arrGraph[i, j - 1];
                            }
                        }
                        if(canhke!=0)
                            streamWriter.Write("{0,-3}",canhke);

                    }
                    streamWriter.WriteLine();
                }
            }
        }
    }
}
