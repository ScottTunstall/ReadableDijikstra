using System;
using System.Collections.Generic;

namespace DjikstraV2
{

    class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = new int[,]
            {
                //A   B   C   D   E   F   G   H   I 
                { 0,  4,  0,  0,  0,  0,  0,  8,  0 }, // A
                { 0,  0,  8,  0,  0,  0,  0,  11, 0 },
                { 0,  8,  0,  7,  0,  4,  0,  0,  2 },
                { 0,  0,  7,  0,  9,  14, 0,  0,  0 },
                { 0,  0,  0,  9,  0,  10, 0,  0,  0 },
                { 0,  0,  4,  14, 10, 0,  2,  0,  0 },
                { 0,  0,  0,  0,  0,  2,  0,  1,  6 },
                { 8,  11, 0,  0,  0,  0,  1,  0,  7 },
                { 0,  0,  2,  0,  0,  0,  6,  7,  0 }  // I
            };

            var t = new Solution();
            var distances = t.Dijkstra(graph, 9, 0);

            Console.Write("Vertex\t\tDistance from Source\n");
            for (int i = 0; i < 9; i++)
                Console.Write(i + " \t\t " + distances[i] + "\n");
        }
    }
}
