using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.ReadData("CHUTRINH.INP");
            graph.WriteData();
            graph.DFS("CHUTRINH.OUT");
        }
    }
}
