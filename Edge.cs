using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraV2
{
    /// <summary>
    /// Represents an edge in a graph.
    /// </summary>
    /// <remarks>
    /// An edge is a connection from one Node to another
    /// </remarks>
    public class Edge
    {

        public Edge(Node destinationNode, int distance)
        {
            DestinationNode = destinationNode;
            Distance = distance;
        }

        public Node DestinationNode { get; }

        public int Distance { get; }

        public override string ToString()
        {
            return DestinationNode!.Name + " distance: " + Distance;
        }
    }
}
