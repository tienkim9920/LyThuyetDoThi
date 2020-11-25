using System;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("TIMDUONG.INP");
            graph.WriteData();
            graph.TimDuong("TIMDUONG.OUT");
           // graph.BFS_Visit("LIENTHONG.OUT");
        }
    }
}
