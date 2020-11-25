using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    class Graph
    {
        public const int Inf = 1000;
        List<List<Tuple<int, int>>> adjWList;
        int numVertices;
        int numEdges;
        int nRow;
        int nCol;
        bool[] status;
        int sVertex;
        int eVertex;
        int iVertex;
        int[] path;
        int[] distance;

        public void Dijkstra(string fname)
        {
            ReadAdjListSP(fname);
            ShortestPath();
            WriteShortestPath(fname.Substring(0, fname.Length - 3) + "out");

        }
        protected void ReadAdjListSP(string fname)
        {
            string[] lines = System.IO.File.ReadAllLines(fname);

            string[] line = lines[0].Split(' ');
            numVertices = Int32.Parse(line[0].Trim());
            numEdges = Int32.Parse(line[1].Trim());
            sVertex = Int32.Parse(line[2].Trim()) - 1;
            eVertex = Int32.Parse(line[3].Trim()) - 1;
            if (line.Length > 4)
                iVertex = Int32.Parse(line[4].Trim()) - 1;

            Console.WriteLine("\t Number of vertices: " + numVertices);

            adjWList = new List<List<Tuple<int, int>>>();
            for (int i = 0; i < numVertices; i++)
                adjWList.Add(new List<Tuple<int, int>>());

            Console.WriteLine(adjWList.Count);
            for (int i = 0; i < numEdges; i++)
            {
                line = lines[i + 1].Split(' ');

                Console.WriteLine(lines[i + 1]);
                int v1 = Int32.Parse(line[0].Trim()) - 1;
                int v2 = Int32.Parse(line[1].Trim()) - 1;
                int w = Int32.Parse(line[2].Trim());
                adjWList[v1].Add(new Tuple<int, int>(v2, w));
                adjWList[v2].Add(new Tuple<int, int>(v1, w));
            }

        }

        protected void InitIntArray(int value, int type = 1)
        {

            if (type == 1)
            {
                path = new int[numVertices];

                for (int i = 0; i < path.Length; i++)
                    path[i] = value;

                return;
            }

            if (type == 2)
            {
                distance = new int[numVertices];

                for (int i = 0; i < distance.Length; i++)
                    distance[i] = value;

                return;
            }

        }
        protected void InitBoolArray(bool value, bool isGrid = false)
        {
            status = new bool[numVertices];
            if (isGrid)
                status = new bool[nCol * nRow];
            for (int i = 0; i < status.Length; i++)
                status[i] = value;
        }


        protected void ShortestPath()
        {
            InitIntArray(-1);
            InitIntArray(Inf, 2);
            InitBoolArray(false);
            int g = sVertex;
            distance[g] = 0;

            do
            {
                g = eVertex;
                for (int i = 0; i < numVertices; i++)
                {
                    if (!status[i] && distance[g] > distance[i])
                    {
                        g = i;
                    }
                }
                status[g] = true;
                if ((distance[g] == Inf) || g == eVertex)
                    break;
                foreach (Tuple<int, int> v in adjWList[g])
                {
                    if (!status[v.Item1])
                    {
                        int d = distance[g] + v.Item2;
                        if (distance[v.Item1] > d)
                        {
                            distance[v.Item1] = d;
                            path[v.Item1] = g;
                        }
                    }
                }

            }
            while (true);
        }

        protected void TracePath(ref string strPath, ref int length, int x, int y)
        {
            int v = path[y];
            Console.Write(String.Format("{0,-3}", v));
            if (v != -2)
            {
                strPath = String.Format("{0,-3}", y + 1);
                length = 2;
                while (v != sVertex)
                {
                    strPath = String.Format("{0,-3}-> ", v + 1) + strPath;
                    v = path[v];
                    length++;
                }
                strPath = String.Format("{0,-3}-> ", x + 1) + strPath;
            }
            else
            {
                strPath = String.Format("Khong co duong di tu {0, -3} den {1, -3}", x + 1, y + 1);
            }
        }


        protected void WriteShortestPath(string fname)
        {
            string str = "";
            int size = 0;
            TracePath(ref str, ref size, sVertex, eVertex);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fname))
            {
                file.WriteLine(String.Format("{0,-3}", distance[eVertex]));
                if (distance[eVertex] < Inf)
                    file.WriteLine(str);
            }

        }
    }
}
