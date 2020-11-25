using System;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("DANHSACHKE.INP");
            graph.WriteData();
            graph.DanhSachKe("DANHSACHKE.OUT");
        }
    }
}
