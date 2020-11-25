using System;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("LIENTHONGDFS.INP");
            graph.WriteData();
            graph.DFS("LIENTHONGDFS.OUT");
        }
    }
}
