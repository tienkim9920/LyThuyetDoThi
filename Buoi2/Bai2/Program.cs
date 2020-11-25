using System;

namespace Bai2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("KESANGCANH.INP");
            graph.WriteData();
            graph.CanhSangKe("KESANGCANH.OUT");
        }
    }
}
