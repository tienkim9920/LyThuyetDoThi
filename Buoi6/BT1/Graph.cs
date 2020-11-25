using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    class Graph
    {
        private int soDinhDoThi;
        List<int>[] a;
        bool[] visited;
        List<int> vertices;

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

            visited[s] = true;
            vertices.Add(s);

            foreach (int v in a[s])
            {
                if (visited[v] == false)
                {
                    DFS_Visit(v);
                }
            }
        }
        public void DFS(string fname)
        {
            bool flag = true;
            visited = new bool[soDinhDoThi + 1];
            vertices = new List<int>();
            DFS_Visit(1);
            for (int i = 1; i <= soDinhDoThi; i++)
            {
                if (visited[i] == false)
                {
                    flag = false;
                    break;
                }
            }
            using (StreamWriter stream = new StreamWriter(fname))
            {
                if (flag == true)
                {
                    stream.Write("YES");
                }
                else
                    stream.Write("NO");
            }
        }
    }
}
