using System;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("CANHCAU.INP");
            graph.CanhCau("CANHCAU.OUT");
        }
    }
}
