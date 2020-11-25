using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai3
{
    class Graph
    {
        private int soDinh;
        int x;
        int count1 = 0;
        int count2 = 0;
        List<int>[] a;
        Queue<int> q;
        bool[] visited;
        List<int> vertices;

        public void ReadData(string fName)
        {
            StreamReader streamReader = new StreamReader(fName);
            string[] row = streamReader.ReadLine().Split();
            soDinh = int.Parse(row[0]);
            x = int.Parse(row[1]);
            a = new List<int>[soDinh + 1];
            a[0] = new List<int> { soDinh,x };
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
                foreach (var v in a[i])
                {
                    Console.Write($"{v}  ");
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
        public void BFS()
        {
            for (int i = 1; i <= soDinh; i++)
            {
                if (visited[i] == false)
                {
                    BFS_Visit(i);
                    count1++;
                }
            }
        }
        public void CanhCau(string fname)
        {
            visited = new bool[soDinh + 1];
            BFS();
            foreach (var v in a[x])
            {
                a[v].Remove(x);
            }
            a[x].RemoveRange(0, a[x].Count);
            for (int i = 1; i <= soDinh; i++)
            {
                visited[i] = false;
            }
            for (int i = 1; i <= soDinh; i++)
            {
                if (visited[i] == false)
                {
                    BFS_Visit(i);
                    count2++;
                }
            }
            Console.WriteLine(count1);
            Console.WriteLine(count2);

            using (StreamWriter stream = new StreamWriter(fname))
            {
                if (count2>=count1+2)
                {
                    stream.Write("YES");
                }
                else stream.Write("NO");
            }

        }
    }
}
