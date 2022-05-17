using ShapePosition.Models;
using System;

namespace ShapePosition
{
    public class RectangleIntersectCalculator
    {
        internal Intersect CalculateIntersect(Rectangle rectangle1, Rectangle rectangle2)
        {
            if (rectangle1 is null) throw new ArgumentNullException(nameof(rectangle1));
            if (rectangle2 is null) throw new ArgumentNullException(nameof(rectangle2));

            Intersect intersect;

            if (rectangle1.TopLeft.X >= rectangle2.BottomRight.X // Rectangle 1 is to the right of Rectangle 2
                || rectangle2.TopLeft.X >= rectangle1.BottomRight.X // Rectangle 2 is to the right of Rectangle 1
                || rectangle1.BottomRight.Y >= rectangle2.TopLeft.Y // Rectangle 1 is above Rectangle 2
                || rectangle2.BottomRight.Y >= rectangle1.TopLeft.Y) // Rectangle 2 is above Rectangle 2  
            {
                intersect = new Intersect(System.Drawing.Point.Empty, System.Drawing.Point.Empty, false);
            }
            else
            {
                intersect = GetPointsOfIntersect(rectangle1, rectangle2);
            }

            return intersect;
        }

        internal Intersect GetPointsOfIntersect(Rectangle rectangle1, Rectangle rectangle2)
        {
            Rectangle innerRectangle = GetInnerRectangle(rectangle1, rectangle2);

            var intersect = HasFourPointsOfIntersect(innerRectangle, rectangle1, rectangle2)
                ? new Intersect(innerRectangle.TopLeft, innerRectangle.TopRight, innerRectangle.BottomLeft, innerRectangle.BottomRight, true)
                : HasIntersectAtTop(innerRectangle, rectangle1, rectangle2)
                    ? new Intersect(innerRectangle.TopLeft, innerRectangle.TopRight, true)
                    : HasIntersectAtBottom(innerRectangle, rectangle1, rectangle2)
                        ? new Intersect(innerRectangle.BottomLeft, innerRectangle.BottomRight, true)
                        : HasIntersectAtLeft(innerRectangle, rectangle1, rectangle2)
                            ? new Intersect(innerRectangle.TopLeft, innerRectangle.BottomLeft, true)
                            : HasIntersectAtRight(innerRectangle, rectangle1, rectangle2)
                                ? new Intersect(innerRectangle.TopRight, innerRectangle.BottomRight, true)
                                : HasIntersectAtTopLeftOrBottomRight(innerRectangle, rectangle1, rectangle2)
                                    ? new Intersect(innerRectangle.TopRight, innerRectangle.BottomLeft, true)
                                    : new Intersect(innerRectangle.TopLeft, innerRectangle.BottomRight, true); // HasIntersectAtTopRightOrBottomLeft

            return intersect;
        }

        private Rectangle GetInnerRectangle(Rectangle rectangle1, Rectangle rectangle2)
        {
            // Get inner rectangles top left and bottom right corner coordinates
            int topLeftX = Math.Max(rectangle1.TopLeft.X, rectangle2.TopLeft.X);
            int topLeftY = Math.Min(rectangle1.TopLeft.Y, rectangle2.TopLeft.Y);

            int bottomRightX = Math.Min(rectangle1.BottomRight.X, rectangle2.BottomRight.X);
            int bottomRightY = Math.Max(rectangle1.BottomRight.Y, rectangle2.BottomRight.Y);

            // Parse coordinates to inner rectangle 
            return new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);
        }

        private bool HasFourPointsOfIntersect(Rectangle innerRectangle, Rectangle rectangle1, Rectangle rectangle2)
        {
            bool hasFourPointsOfIntersectR1 = innerRectangle.TopLeft.X == rectangle1.TopLeft.X
                   && innerRectangle.TopLeft.Y == rectangle2.TopLeft.Y
                   && innerRectangle.BottomRight.X == rectangle1.BottomRight.X
                   && innerRectangle.BottomRight.Y == rectangle2.BottomRight.Y;

            bool hasFourPointsOfIntersectR2 = innerRectangle.TopLeft.X == rectangle2.TopLeft.X
                && innerRectangle.TopLeft.Y == rectangle1.TopLeft.Y
                && innerRectangle.BottomRight.X == rectangle2.BottomRight.X
                && innerRectangle.BottomRight.Y == rectangle1.BottomRight.Y;

            return hasFourPointsOfIntersectR1 || hasFourPointsOfIntersectR2;
        }

        private bool HasIntersectAtBottom(Rectangle innerRectangle, Rectangle rectangle1, Rectangle rectangle2)
        {
            bool isIntersectAtBottomR1 = innerRectangle.TopLeft.Y < rectangle1.TopLeft.Y
                && innerRectangle.TopLeft.X > rectangle1.TopLeft.X
                && innerRectangle.BottomRight.X < rectangle1.BottomRight.X;

            bool isIntersectAtBottomR2 = innerRectangle.TopLeft.Y < rectangle2.TopLeft.Y
                && innerRectangle.TopLeft.X > rectangle2.TopLeft.X
                && innerRectangle.BottomRight.X < rectangle2.BottomRight.X;

            return isIntersectAtBottomR1 || isIntersectAtBottomR2;
        }

        private bool HasIntersectAtTop(Rectangle innerRectangle, Rectangle rectangle1, Rectangle rectangle2)
        {
            bool isIntersectAtTopR1 = innerRectangle.BottomRight.Y > rectangle1.BottomRight.Y
                   && innerRectangle.BottomRight.X < rectangle1.BottomRight.X
                   && innerRectangle.TopLeft.X > rectangle1.TopLeft.X;

            bool isIntersectAtTopR2 = innerRectangle.BottomRight.Y > rectangle2.BottomRight.Y
                && innerRectangle.BottomRight.X < rectangle2.BottomRight.X
                && innerRectangle.TopLeft.X > rectangle2.TopLeft.X;

            return isIntersectAtTopR1 || isIntersectAtTopR2;
        }

        private bool HasIntersectAtLeft(Rectangle innerRectangle, Rectangle rectangle1, Rectangle rectangle2)
        {
            bool isIntersectAtLeftR1 = innerRectangle.TopLeft.X == rectangle1.TopLeft.X
                && innerRectangle.BottomRight.X < rectangle1.BottomRight.X
                && innerRectangle.TopLeft.Y < rectangle1.TopLeft.Y
                && innerRectangle.BottomLeft.Y > rectangle1.BottomLeft.Y;

            bool isIntersectAtLeftR2 = innerRectangle.TopLeft.X == rectangle2.TopLeft.X
                && innerRectangle.BottomRight.X < rectangle2.BottomRight.X
                && innerRectangle.TopLeft.Y < rectangle2.TopLeft.Y
                && innerRectangle.BottomLeft.Y > rectangle2.BottomLeft.Y;

            return isIntersectAtLeftR1 || isIntersectAtLeftR2;
        }

        private bool HasIntersectAtRight(Rectangle innerRectangle, Rectangle rectangle1, Rectangle rectangle2)
        {
            bool isIntersectAtRightR1 = innerRectangle.TopRight.X == rectangle1.TopRight.X
                && innerRectangle.BottomLeft.X > rectangle1.BottomLeft.X
                && innerRectangle.TopRight.Y < rectangle1.TopRight.Y
                && innerRectangle.BottomLeft.Y > rectangle1.BottomLeft.Y;

            bool isIntersectAtRightR2 = innerRectangle.TopRight.X == rectangle2.TopRight.X
                && innerRectangle.BottomLeft.X > rectangle2.BottomLeft.X
                && innerRectangle.TopRight.Y < rectangle2.TopRight.Y
                && innerRectangle.BottomLeft.Y > rectangle2.BottomLeft.Y;

            return isIntersectAtRightR1 || isIntersectAtRightR2;
        }

        private bool HasIntersectAtTopLeftOrBottomRight(Rectangle innerRectangle, Rectangle rectangle1, Rectangle rectangle2)
        {
            bool isIntersectAtTopLeftOrBottomRightR1 = innerRectangle.TopRight.X == rectangle1.TopRight.X
               && innerRectangle.BottomLeft.X == rectangle2.BottomLeft.X
               && innerRectangle.TopRight.Y < rectangle1.TopRight.Y
               && innerRectangle.BottomLeft.Y == rectangle1.BottomLeft.Y;

            bool isIntersectAtTopLeftOrBottomRightR2 = innerRectangle.TopRight.X == rectangle2.TopRight.X
                && innerRectangle.BottomLeft.X == rectangle1.BottomLeft.X
                && innerRectangle.TopRight.Y < rectangle2.TopRight.Y
                && innerRectangle.BottomLeft.Y == rectangle2.BottomLeft.Y;

            return isIntersectAtTopLeftOrBottomRightR1 || isIntersectAtTopLeftOrBottomRightR2;
        }
    }
}
