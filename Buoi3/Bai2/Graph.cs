using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Bai2
{
    class Graph
    {

        int soDinh;
        int s;
        int t;
        List<int>[] a;
        Queue<int> q;
        bool[] visited;
        List<int> vertices;
        int[] pre;
        List<int> path;

        public void ReadData(string fName)
        {
            StreamReader streamReader = new StreamReader(fName);
            string[] row = streamReader.ReadLine().Split();
            soDinh = int.Parse(row[0]);
            s = int.Parse(row[1]);
            t = int.Parse(row[2]);

            path = new List<int>(soDinh);
            a = new List<int>[soDinh + 1];
            a[0] = new List<int> { soDinh,s,t };
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
            BFS_VISIT();
            FindPath(t);

        }
        public void BFS_VISIT()
        {
            visited = new bool[soDinh+1];
            pre = new int[soDinh+1];
            vertices = new List<int>();
            for (int i = 1; i < soDinh+1; i++)
            {
                visited[i] = false;
                pre[i] = -1;
            }

            q = new Queue<int>();
            q.Enqueue(s);

            visited[s] = true;
            vertices.Add(s);
            while (q.Count != 0)
            {
                int u = q.Dequeue();
                foreach (int v in a[u])
                {
                    if (visited[v]) continue;

                    visited[v] = true;
                    q.Enqueue(v);
                    pre[v] = u;
                    vertices.Add(v);
                }
            }
        }
        public void FindPath(int t)
        {
            if (t == -1) return;
            path.Add(t);
            FindPath(pre[t]);
        }
        public void TimDuong(string fname)
        {
            path.Reverse();
            using (StreamWriter stream = new StreamWriter(fname))
            {

                foreach (var c in path)
                {
                        stream.Write($"{c}  ");
                }
            }
        }
    }
}
