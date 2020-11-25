using System;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("MIENLIENTHONG.INP");
            graph.WriteData();
            graph.BFS("MIENLIENTHONG.OUT");
        }
    }
}
