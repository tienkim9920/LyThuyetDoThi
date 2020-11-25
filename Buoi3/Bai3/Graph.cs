using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai3
{
    class Graph
    {
        private int soDinh;
        List<int>[] a;
        Queue<int> q;
        bool[] visited;
        List<int> vertices;

        public void ReadData(string fName)
        {
            StreamReader streamReader = new StreamReader(fName);
            string[] row = streamReader.ReadLine().Split();
            soDinh = int.Parse(row[0]);
            a = new List<int>[soDinh + 1];
            a[0] = new List<int> {soDinh};
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

        public void BFS_Visit(int dinh)
        {            
            vertices = new List<int>();
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
        }
        public void BFS(string fname)
        {
            bool flag = true;
            visited = new bool[soDinh + 1];
            for (int i = 1; i <= soDinh; i++)
            {
                visited[i] = false;
            }
            BFS_Visit(0);

            for (int i = 1; i < soDinh+1; i++)
            {
                if (visited[i] == false)
                {
                    flag = false;
                    break;
                }
            }
            using (StreamWriter stream = new StreamWriter(fname))
            {
                if (flag)
                {
                     stream.Write("YES");
                }
                else stream.Write("NO");
            }
           
                
        }
    }
}
