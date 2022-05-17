using System.Drawing;

namespace ShapePosition.Models
{
    public sealed class Rectangle
    {
        public Point TopLeft { get; }
        public Point TopRight { get; }
        public Point BottomRight { get; }
        public Point BottomLeft { get; }

        public Rectangle(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY)
        {
            this.TopLeft = new Point(topLeftX, topLeftY);
            this.BottomRight = new Point(bottomRightX, bottomRightY);
            this.TopRight = new Point(BottomRight.X, TopLeft.Y);
            this.BottomLeft = new Point(TopLeft.X, BottomRight.Y);
        }

        public static bool TryParse(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY, out Rectangle result)
        {
            if (IsValid(topLeftX, topLeftY, bottomRightX, bottomRightY))
            {
                result = new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY);
                return true;
            }
            else
            {
                result = null;
                return false;
            }
        }

        private static bool IsValid(int topLeftX, int topLeftY, int bottomRightX, int bottomRightY) =>
            topLeftX != bottomRightX // x coordinates cannot exist on the same point 
            && topLeftY != bottomRightY // y coordinates cannot exist on the same point
            && bottomRightX > topLeftX
            && bottomRightY < topLeftY;
    }
}
