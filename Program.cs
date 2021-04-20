using System;


namespace DijkstraV2
{

    class Program
    {
        static void Main(string[] args)
        {
            // Adjacency matrix represented as 2D array.
            // See adjacency-matrix-visualised-as-graph.png for graph representation.
            int[,] graph = new int[,]
            {
                //A   B   C   D   E   F   G   H   I 
                { 0,  4,  0,  0,  0,  0,  0,  8,  0 }, // A
                { 0,  0,  8,  0,  0,  0,  0,  11, 0 }, // B
                { 0,  8,  0,  7,  0,  4,  0,  0,  2 }, // C
                { 0,  0,  7,  0,  9,  14, 0,  0,  0 }, // D
                { 0,  0,  0,  9,  0,  10, 0,  0,  0 }, // E
                { 0,  0,  4,  14, 10, 0,  2,  0,  0 }, // F
                { 0,  0,  0,  0,  0,  2,  0,  1,  6 }, // G
                { 8,  11, 0,  0,  0,  0,  1,  0,  7 }, // H
                { 0,  0,  2,  0,  0,  0,  6,  7,  0 }  // I
            };

            var solution = new Solution();
            var distances = solution.Dijkstra(graph, 9, 0);

            Console.Write("Vertex\t\tDistance from Source\n");
            for (int i = 0; i < 9; i++)
                Console.Write(i + " \t\t " + distances[i] + "\n");
        }
    }
}
