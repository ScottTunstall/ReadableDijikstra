#nullable disable

namespace DijkstraV2
{
    /// <summary>
    /// Represents an edge in a graph.
    /// </summary>
    /// <remarks>
    /// An edge is a connection from one Node to another.
    /// </remarks>
    public class Edge
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="destinationNode">destination node of this edge</param>
        /// <param name="distance">units of distance</param>
        /// <remarks>
        /// The <see cref="Node"/> object that contains this instance of <see cref="Edge"/> is the source node
        /// This is why the constructor does not take a source node parameter.
        /// </remarks>
        public Edge(Node destinationNode, int distance)
        {
            DestinationNode = destinationNode;
            Distance = distance;
        }

        public Node DestinationNode { get; }

        public int Distance { get; }

        public override string ToString()
        {
            return DestinationNode.Name + " distance: " + Distance;
        }
    }
}
