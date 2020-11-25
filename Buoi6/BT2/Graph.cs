using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    class Graph
    {
        private int soDinhDoThi;
        List<int>[] a;
        bool[] visited;
        List<int> vertices;
        int[] color;
        bool flag = false;

        public void ReadData(string fName)
        {
            StreamReader streamReader = new StreamReader(fName);
            string[] row = streamReader.ReadLine().Split();
            soDinhDoThi = int.Parse(row[0]);

            a = new List<int>[soDinhDoThi + 1];
            a[0] = new List<int> { soDinhDoThi };
            for (int i = 1; i <= soDinhDoThi; i++)
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
            for (int i = 0; i <= soDinhDoThi; i++)
            {
                foreach (var x in a[i])
                {
                    Console.Write($"{x}  ");
                }
                Console.WriteLine();
            }


        }
        public void DFS_Visit(int s)
        {
            color[s] = 1;
            visited[s] = true;
            vertices.Add(s);

            foreach (int v in a[s])
            {
                if (visited[v] == false)
                {
                    DFS_Visit(v);
                }
                if (color[v] == 1)
                {
                    flag = true;
                }
            }
            color[s] = 2;
        }
        public void DFS(string fname)
        {
            color = new int[soDinhDoThi + 1];
            visited = new bool[soDinhDoThi + 1];
            vertices = new List<int>();

            for (int i = 1; i <= soDinhDoThi; i++)
            {
                if (visited[i] == false)
                {
                    DFS_Visit(i);

                }
            }
            using (StreamWriter stream = new StreamWriter(fname))
            {
                if (!flag)
                {
                    stream.Write("NO");
                }
                else
                    stream.Write("YES");
            }
        }
    }
}
