using System;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("LIENTHONG.INP");
            graph.WriteData();
            graph.BFS_Visit("LIENTHONG.OUT");
           // graph.LienThong("LIENTHONG.OUT");
        }
    }
}
