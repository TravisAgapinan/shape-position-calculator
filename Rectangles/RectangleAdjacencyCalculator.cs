using ShapePosition.Models;
using System;

namespace ShapePosition
{
    public class RectangleAdjacencyCalculator
    {
        internal Adjacency CalculateAdjacency(Rectangle rectangle1, Rectangle rectangle2)
        {
            if (rectangle1 is null) throw new ArgumentNullException(nameof(rectangle1));
            if (rectangle2 is null) throw new ArgumentNullException(nameof(rectangle2));

            var adjacencyType = AdjacencyType.None;

            // Determine adjacency right or left
            // Rectangle 1 right side adjacent to Rectangle 2 left side
            if (rectangle1.TopRight.X == rectangle2.TopLeft.X)
            {
                if (rectangle1.TopRight.Y == rectangle2.TopLeft.Y && rectangle1.BottomRight.Y == rectangle2.BottomLeft.Y)
                {
                    adjacencyType = AdjacencyType.Proper;
                }
                else if ((rectangle1.TopRight.Y > rectangle2.TopLeft.Y && rectangle1.BottomRight.Y < rectangle2.BottomLeft.Y)
                    || rectangle1.TopRight.Y < rectangle2.TopLeft.Y && rectangle1.BottomRight.Y > rectangle2.BottomLeft.Y)
                {
                    adjacencyType = AdjacencyType.SubLine;
                }
                else
                {
                    // At this point if it's outside of the confines of a sub-line and proper,
                    // I _think_ its safe to assume partial adjacency 
                    adjacencyType = AdjacencyType.Partial;
                }
            }
            // Rectangle 1 left side adjacent to Rectangle 2 right side
            else if (rectangle1.TopLeft.X == rectangle2.TopRight.X)
            {
                if (rectangle1.TopLeft.Y == rectangle2.TopRight.Y && rectangle1.BottomLeft.Y == rectangle2.BottomRight.Y)
                {
                    adjacencyType = AdjacencyType.Proper;
                }
                else if ((rectangle1.TopLeft.Y > rectangle2.TopRight.Y && rectangle1.BottomLeft.Y < rectangle2.BottomRight.Y)
                    || rectangle1.TopLeft.Y < rectangle2.TopRight.Y && rectangle1.BottomLeft.Y > rectangle2.BottomRight.Y)
                {
                    adjacencyType = AdjacencyType.SubLine;
                }
                else
                {
                    adjacencyType = AdjacencyType.Partial;
                }
            }

            // Possible expansion thoughts listed in readme.md

            return new Adjacency(adjacencyType != AdjacencyType.None, adjacencyType);
        }
    }
}
