using ShapePosition.Models;
using System;

namespace ShapePosition
{
    public class RectangleContainCalculator
    {
        public Contained CalculateContained(Rectangle rectangle1, Rectangle rectangle2) =>
            new Contained(IsRectangle1ContainedIn2(rectangle1, rectangle2)
                || IsRectangle2ContainedIn1(rectangle1, rectangle2));


        internal bool IsRectangle1ContainedIn2(Rectangle rectangle1, Rectangle rectangle2)
        {
            if (rectangle1 is null) throw new ArgumentNullException(nameof(rectangle1));
            if (rectangle2 is null) throw new ArgumentNullException(nameof(rectangle2));

            bool result = false;

            // Rectangle 1 inside of Rectangle 2
            if (rectangle1.TopLeft.X > rectangle2.TopLeft.X
                && rectangle1.BottomRight.X < rectangle2.BottomRight.X
                && rectangle1.TopLeft.Y < rectangle2.TopLeft.Y
                && rectangle1.BottomRight.Y > rectangle2.BottomRight.Y)
            {
                result = true;
            }

            return result;
        }

        internal bool IsRectangle2ContainedIn1(Rectangle rectangle1, Rectangle rectangle2)
        {
            if (rectangle1 is null) throw new ArgumentNullException(nameof(rectangle1));
            if (rectangle2 is null) throw new ArgumentNullException(nameof(rectangle2));

            bool result = false;

            // Rectangle 2 inside of Rectangle 1
            if (rectangle1.TopLeft.X < rectangle2.TopLeft.X
                && rectangle1.BottomRight.X > rectangle2.BottomRight.X
                && rectangle1.TopLeft.Y > rectangle2.TopLeft.Y
                && rectangle1.BottomRight.Y < rectangle2.BottomRight.Y)
            {
                result = true;
            }

            return result;
        }
    }
}
