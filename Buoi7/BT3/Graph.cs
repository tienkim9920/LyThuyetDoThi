using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT3
{
    class Graph
    {
        public const int Inf = 1000;
        int[,] arrGraph;
        int[,] floydMatrix;
        int numVertices;
        protected int maxWeight = 0;


        public void ReadMatrix2Matrix(string fname)
        {
            string[] lines = System.IO.File.ReadAllLines(fname);

            numVertices = Int32.Parse(lines[0].Trim());
            Console.WriteLine("\t Number of vertices: " + numVertices);
            arrGraph = new int[numVertices, numVertices];

            for (int i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');
                for (int j = 0; j < line.Length; j++)
                {
                    int value = Int32.Parse(line[j].Trim());
                    if (value > maxWeight)
                        maxWeight = value;
                    SetNode(i - 1, j, value);
                    Console.Write(String.Format("{0,-3}", GetNode(i - 1, j)));
                }
                Console.WriteLine();

            }
        }

        public void SetNode(int i, int j, int value)
        {
            if (i < 0 && i < numVertices && j > -1 && j < numVertices)
            {
                Console.WriteLine(String.Format("Out of range ({0}, {1})", i, j));
                return;
            }
            arrGraph[i, j] = value;
        }

        public int GetNode(int i, int j)
        {
            if (i < 0 && i < numVertices && j > -1 && j < numVertices)
            {
                Console.WriteLine(String.Format("Out of range ({0}, {1})", i, j));
                return Int32.MinValue;
            }
            return arrGraph[i, j];
        }


        public void ShortestPathFloyd(string fname)
        {
            ReadMatrix2Matrix(fname);
            FloydAlgorithm();
            WriteFloydMatrix(fname.Substring(0, fname.Length - 3) + "out");
        }

        private void WriteMatrix(int[,] matrix, int nrow, int ncol)
        {

            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncol; j++)
                {
                    Console.Write(String.Format("{0,-3}", matrix[i, j]));
                }
                Console.WriteLine();
            }
        }
        protected void FloydAlgorithm()
        {
            floydMatrix = new int[numVertices, numVertices];
            for (int i = 0; i < numVertices; i++)
            {
                floydMatrix[i, i] = 0;
                for (int j = i + 1; j < numVertices; j++)
                {
                    floydMatrix[i, j] = Inf;
                    floydMatrix[j, i] = Inf;
                    if (arrGraph[i, j] != 0)
                    {
                        floydMatrix[i, j] = arrGraph[i, j];
                        floydMatrix[j, i] = arrGraph[j, i];

                    }
                }
            }
            for (int k = 0; k < numVertices; k++)
            {
                Console.WriteLine(String.Format("k = {0,3}", k));
                for (int i = 0; i < numVertices; i++)
                    for (int j = 0; j < numVertices; j++)
                    {
                        int d = floydMatrix[i, k] + floydMatrix[k, j];
                        if (floydMatrix[i, j] > d)
                            floydMatrix[i, j] = d;
                    }

                WriteMatrix(floydMatrix, numVertices, numVertices);
            }

        }
        protected void WriteFloydMatrix(string fname)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fname))
            {

                file.WriteLine(String.Format("{0,-3}", numVertices));
                for (int i = 0; i < numVertices; i++)
                {
                    for (int j = 0; j < numVertices; j++)
                    {
                        string str = String.Format("{0,-5}", floydMatrix[i, j]);
                        if ((floydMatrix[i, j] >= (Inf - maxWeight)) && (floydMatrix[i, j] <= (Inf + maxWeight)))
                            str = "Inf";
                        file.Write(str);

                    }
                    file.WriteLine();
                }

            }
        }
    }
}
