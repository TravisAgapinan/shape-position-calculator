using ShapePosition.Models;
using System;
using System.Drawing;
using Rectangle = ShapePosition.Models.Rectangle;

namespace ShapePosition
{
    public class RectanglePositionCalculator
    {
        private readonly Rectangle rectangle1;
        private readonly Rectangle rectangle2;

        public RectanglePositionCalculator(Rectangle rectangle1, Rectangle rectangle2)
        {
            this.rectangle1 = rectangle1 ?? throw new ArgumentNullException(nameof(rectangle1));
            this.rectangle2 = rectangle2 ?? throw new ArgumentNullException(nameof(rectangle2));
        }

        public PositionResponse CalculatePositions()
        {
            Contained contained = new RectangleContainCalculator().CalculateContained(this.rectangle1, this.rectangle2);

            Adjacency adjacency = contained.IsContained
                ? new Adjacency(false, AdjacencyType.None)
                : new RectangleAdjacencyCalculator().CalculateAdjacency(rectangle1, rectangle2);

            Intersect intersect = contained.IsContained || adjacency.IsAdjacent
                ? new Intersect(new Point(0, 0), new Point(0, 0), false)
                : new RectangleIntersectCalculator().CalculateIntersect(rectangle1, rectangle2);

            return new PositionResponse(intersect, adjacency, contained);
        }
    }
}
