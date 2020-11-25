using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Bai2
{
    class Graph
    {
        private int soDinh;
        private int x;
        private int y;
        List<int>[] a;
        int[] pre;
        bool[] visited;
        List<int> path;
        List<int> vertices;

        public void ReadData(string fName)
        {
            StreamReader streamReader = new StreamReader(fName);
            string[] row = streamReader.ReadLine().Split();
            soDinh = int.Parse(row[0]);
            x = int.Parse(row[1]);
            y = int.Parse(row[2]);
            a = new List<int>[soDinh + 1];
            a[0] = new List<int> { soDinh, x,y };
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
            path = new List<int>();
            for (int i = 0; i <= soDinh; i++)
            {
                foreach (var x in a[i])
                {
                    Console.Write($"{x}  ");
                }
                Console.WriteLine();
            }
            DFS();
            FindPath(y);
        }
        public void DFS_Visit(int s)
        {

            visited[s] = true;
            vertices.Add(s);

            foreach (int v in a[s])
            {
                if (visited[v] == false)
                {
                    pre[v] = s;
                    DFS_Visit(v);
                }
            }
        }
        public void DFS()
        {
            visited = new bool[soDinh + 1];
            pre = new int[soDinh + 1];
            vertices = new List<int>();
            for (int i = 1; i < soDinh+1; i++)
            {
                pre[i] = -1;
            }
            DFS_Visit(x);

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
