using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai1
{
    class Graph
    {
        private int soDinh;
        private int dinh;
        List<int>[] a;
        Queue<int> q;
        bool[] visited;
        List<int> vertices;

        public void ReadData(string fName)
        {
            StreamReader streamReader = new StreamReader(fName);
            string[] row = streamReader.ReadLine().Split();
            soDinh = int.Parse(row[0]);
            dinh = int.Parse(row[1]);
            a = new List<int>[soDinh+1];
            a[0] = new List<int> { soDinh, dinh };
            for (int i = 1; i <= soDinh; i++)
            {
                a[i] = new List<int>();
                string[] line = streamReader.ReadLine().Split();
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] != "")
                    {
                        a[i].Add(int.Parse(line[j]));
                    }
                }
            }
        }
        public void WriteData()
        {
            for (int i = 0; i <= soDinh; i++)
            {
                foreach (var x in a[i])
                {
                    Console.Write($"{x}  ");
                }
                Console.WriteLine();
            }

        }

        public void BFS_Visit(string fname)
        {
            visited = new bool[soDinh+1];
            vertices = new List<int>();
            for (int i = 1; i <= soDinh; i++)
            {
                visited[i] = false;
            }
            q = new Queue<int>();
            q.Enqueue(dinh);

            visited[dinh] = true;
            vertices.Add(dinh);
            while (q.Count != 0)
            {
                int u = q.Dequeue();

                foreach (int v in a[u])
                {
                    if (visited[v]) continue;
                    visited[v] = true;
                    q.Enqueue(v);
                    vertices.Add(v);

                }
            }
                using (StreamWriter stream = new StreamWriter(fname))
                {

                    foreach (var b in vertices)
                    {
                        if(b!=dinh)
                           stream.Write($"{b}  ");
                    }
                }
                   
           
        }
    }
}
