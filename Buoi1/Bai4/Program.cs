using System;

namespace Bai4
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("DANHSACHCANH.INP");
            graph.WriteData();
            graph.DanhSachCanh("DANHSACHCANH.OUT");
        }
    }
}
