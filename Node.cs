using System;
using System.Collections.Generic;

namespace DjikstraV2
{
    public class Node
    {
        private readonly Lazy<List<Edge>> _connectedNodes = new(() => new List<Edge>());

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of this node</param>
        /// <param name="index">Unique index for this node</param>
        public Node(string name, int index)
        {
            this.Name = name;
            this.Index = index;
        }

        /// <summary>
        /// Name of this node
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// Unique index of this node
        /// </summary>
        public int Index { get; }

        public IList<Edge> Edges => _connectedNodes.Value;

        public override string ToString()
        {
            return Name + " num edges: " + Edges.Count;
        }
    }
}
