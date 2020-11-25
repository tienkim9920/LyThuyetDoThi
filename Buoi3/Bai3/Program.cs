using System;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("LIENTHONG.INP");
            graph.WriteData();
            graph.BFS("LIENTHONG.OUT");
        }
    }
}
