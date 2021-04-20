using System;
using System.Collections.Generic;

#nullable enable

namespace DijkstraV2
{
    public class Solution
    {
        private int[] Distances { get; set; }
        private bool[] NodeVisited { get; set; }

        // Function that implements Dijkstra's 
        // single source shortest path algorithm 
        // for a graph represented using adjacency 
        // matrix representation  (see https://www.youtube.com/watch?v=5S1II7Mc8v8)
        public int[] Dijkstra(int[,] graph, int numberOfNodesInGraph, int src)
        {
            Distances = new int[numberOfNodesInGraph];
            NodeVisited = new bool[numberOfNodesInGraph];
            
            // Distance of source node from itself is always 0 
            Distances[src] = 0;

            // For the other nodes, set their distances to MaxValue, which effectively means "uncalculated as yet"
            for (int i = 1; i < numberOfNodesInGraph; i++)
            {
                Distances[i] = int.MaxValue;
            }

            // 
            // Put a breakpoint on the line below and then step over. View the nodes list in the VS 2019 watch window.
            // You will see a list of 9 nodes, and when you drill down into each node, "Edges" will tell you
            // what node(s) they are connected to.
            var nodes = CreateNodes(graph, numberOfNodesInGraph);

            // find the first node to start at
            var currentNode = nodes[src];

            // Yes, it really is this easy!
            do
            {
                UpdateUnvisitedNeighbourDistances(currentNode);

                NodeVisited[currentNode.Index] = true;

                currentNode = GetClosestUnvisitedNeighbour(currentNode);

            } while (currentNode != null);

            return Distances;
        }




        /// <summary>
        /// Create a graph of nodes and their edges from a supplied adjacency matrix 
        /// </summary>
        /// <param name="graph">the adjacency matrix</param>
        /// <param name="numberOfNodesInGraph">the number of nodes there are in the graph.</param>
        /// <returns>A list of <see cref="Node"/> nodes representing the graph.</returns>
        private IList<Node> CreateNodes(int[,] graph, int numberOfNodesInGraph)
        {
            var nodes = MakeNodes(numberOfNodesInGraph);

            // Load the graph and find out what nodes are connected (via "edges")
            for (int i = 0; i < numberOfNodesInGraph; i++)
            {
                for (int j = 0; j < numberOfNodesInGraph; j++)
                {
                    var distance  = graph[i,j];

                    // if the distance isn't zero then the nodes are connected.
                    if (distance != 0)
                    {
                        Node sourceNode = nodes[i];
                        Node destinationNode = nodes[j];

                        sourceNode.Edges.Add(new Edge(destinationNode, distance));
                    }
                }
            }

            return nodes;
        }


        /// <summary>
        /// Creates a specified number of <see cref="Node"/>(s) and returns them as a list.
        /// <para>
        /// Each node is assigned a unique, ascending letter of the alphabet as its name, starting from "A".
        /// </para>
        /// <para>
        /// For example, supplying 3 as <see cref="count"/> creates and returns a list with 3 <see cref="Node"/> instances named "A","B","C".
        /// A node named "A" will be first (index 0) in the list, "B" will be second (index 1), "C" will be third (index 2) and so on.
        /// </para>
        /// </summary>
        /// <param name="count">Number of <see cref="Node"/>(s) to create. Maximum of 26.</param>
        /// <returns>A list of <see cref="Node"/> objects</returns>
        private IList<Node> MakeNodes(int count)
        {
            var nodes = new List<Node>(count);
            for (int i = 0; i < count; i++)
            {
                var name = Convert.ToChar('A' + i).ToString();
                nodes.Add(new Node(name,i));
            }

            return nodes;
        }


        // I considered xmldocs here but I think they might muddy the learning for you
        private void UpdateUnvisitedNeighbourDistances(Node currentNode)
        {
            foreach (var edge in currentNode.Edges)
            {
                var targetNode = edge.DestinationNode;

                if (NodeVisited[targetNode.Index])
                    continue;

                if (Distances[currentNode.Index] + edge.Distance < Distances[targetNode.Index])
                    Distances[targetNode.Index] = Distances[currentNode.Index] + edge.Distance;
            }
        }


        /// <summary>
        /// Evaluates all neighbours of node <see cref="startNode"/>
        /// and returns the closest unvisited node.
        /// </summary>
        /// <param name="startNode">Starting node</param>
        /// <remarks>
        /// Neighbour nodes are those that have an edge from <see cref="startNode"/> to them
        /// </remarks>
        /// <returns>Returns the closest unvisited neighbour <see cref="Node"/> if one exists; null otherwise</returns>
        private Node? GetClosestUnvisitedNeighbour(Node startNode)
        {
            var bestDistance = int.MaxValue;
            Node? closestNeighbour = null;

            foreach (var edge in startNode.Edges)
            {
                var targetNode = edge.DestinationNode;

                if (NodeVisited[edge.DestinationNode.Index])
                    continue;

                if (Distances[targetNode.Index] < bestDistance)
                {
                    bestDistance = Distances[targetNode.Index];
                    closestNeighbour = targetNode;
                }
            }

            return closestNeighbour;
        }
    }
}
