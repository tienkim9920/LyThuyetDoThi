﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT1
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph();
            graph.Dijkstra("Dijkstra.INP");
        }
    }
}
