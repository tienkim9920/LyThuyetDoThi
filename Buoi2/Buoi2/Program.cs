using System;

namespace Buoi2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("CANHSANGKE.INP");
            graph.WriteData();
            graph.CanhSangKe("CANHSANGKE.OUT");
        }
    }
}
