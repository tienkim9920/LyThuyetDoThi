using System;

namespace Bai4
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("DEMLIENTHONG.INP");
            graph.WriteData();
            graph.BFS("DEMLIENTHONG.OUT");
        }
    }
}
