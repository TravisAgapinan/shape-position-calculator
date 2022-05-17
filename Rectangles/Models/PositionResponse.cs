using System;

namespace ShapePosition.Models
{
    public class PositionResponse
    {
        public Intersect Intersect { get; }
        public Adjacency Adjacency { get; }
        public Contained Contained { get; }

        public PositionResponse(Intersect intersect, Adjacency adjacency, Contained contained)
        {
            this.Intersect = intersect ?? throw new ArgumentNullException(nameof(intersect));
            this.Adjacency = adjacency ?? throw new ArgumentNullException(nameof(adjacency));
            this.Contained = contained ?? throw new ArgumentNullException(nameof(contained));
        }
    }
}
