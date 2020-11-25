using System;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("DINHKHOP.INP");
            graph.CanhCau("DINHKHOP.OUT");
            graph.WriteData();
        }
    }
}
