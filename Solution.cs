using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable enable

namespace DjikstraV2
{
    public class Solution
    {
        private int[] Distances { get; set; }
        private bool[] NodeVisited { get; set; }

        public int[] Dijkstra(int[,] graph, int numberOfNodesInGraph, int src)
        {
            Distances = new int[numberOfNodesInGraph];
            NodeVisited = new bool[numberOfNodesInGraph];
            
            // Distance of source vertex from itself is always 0 
            Distances[0] = 0;
            for (int i = 1; i < numberOfNodesInGraph; i++)
            {
                Distances[i] = int.MaxValue;
            }

            // Put a breakpoint on this line and then view the nodes list in the VS 2019 watch window.
            // You will see a list of 9 nodes, and when you drill down into each node, "Edges" will tell you
            // what node(s) they are connected to.
            var nodes = CreateNodes(graph, numberOfNodesInGraph);

            // find the first node to start at
            var currentNode = nodes[src];

            // Yes, it really is this easy!
            do
            {
                UpdateDistances(currentNode);

                NodeVisited[currentNode.Index] = true;

                currentNode = GetClosestNode(currentNode);

            } while (currentNode != null);

            return Distances;
        }




        /// <summary>
        /// Create nodes and their edges 
        /// </summary>
        /// <param name="graph">the adjacency matrix describing connected nodes</param>
        /// <param name="numberOfNodesInGraph">the number of nodes there are in the graph.</param>
        /// <returns>A list of <seealso cref="Node"/> nodes representing the graph.</returns>
        private IList<Node> CreateNodes(int[,] graph, int numberOfNodesInGraph)
        {
            var nodes = MakeNodes(numberOfNodesInGraph);

            // Load the graph and find out what nodes are connected (their "edges")
            for (int i = 0; i < numberOfNodesInGraph; i++)
            {
                for (int j = 0; j < numberOfNodesInGraph; j++)
                {
                    var distance  = graph[i,j];

                    // if the weight isn't zero then the nodes are connected.
                    if (distance != 0)
                    {
                        Node dest = nodes[j];
                        nodes[i].Edges.Add(new Edge(dest, distance));
                    }
                }
            }

            return nodes;
        }


        /// <summary>
        /// Creates a list of nodes named after letters in the alphabet.
        /// Node index 0 has name "A", node index 1 has name "B", 2 "C" etc. etc.
        /// </summary>
        /// <param name="count">Number of nodes to create. Maximum of 26.</param>
        /// <returns></returns>
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
        private void UpdateDistances(Node currentNode)
        {
            foreach (var edge in currentNode.Edges)
            {
                var targetNode = edge.DestinationNode;

                if (NodeVisited[targetNode.Index])
                    continue;

                if (Distances[currentNode.Index] + edge.Distance < Distances[targetNode.Index])
                    Distances[edge.DestinationNode.Index] = Distances[currentNode.Index] + edge.Distance;
            }
        }


        /// <summary>
        /// Get the closest Node to the supplied Node
        /// </summary>
        /// <param name="currentNode"></param>
        /// <returns>Returns the closest unvisited neighbour if one exists; null otherwise</returns>
        private Node? GetClosestNode(Node currentNode)
        {
            var bestDistance = int.MaxValue;
            Node? closestNeighbour = null;

            foreach (var edge in currentNode.Edges)
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
