using System;

namespace Bai3
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("DODAITRUNGBINHCANH.INP");
            graph.WriteData();
            graph.DoDaiTrungBinhCanh("DODAITRUNGBINHCANH.OUT");
        }
    }
}
