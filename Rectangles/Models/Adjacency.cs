using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePosition.Models
{
    public class Adjacency
    {
        public bool IsAdjacent { get; }
        public AdjacencyType AdjacencyType { get; }

        public Adjacency(bool isAdjacent, AdjacencyType adjacencyType)
        {
            this.IsAdjacent = isAdjacent;
            this.AdjacencyType = adjacencyType;
        }
    }
}
