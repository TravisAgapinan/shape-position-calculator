using System;
using System.Drawing;

namespace ShapePosition.Models
{
    public class Intersect
    {
        public bool IsIntersecting { get; }
        public Point PointOfIntersect1 { get; }
        public Point PointOfIntersect2 { get; }
        public Point PointOfIntersect3 { get; }
        public Point PointOfIntersect4 { get; }

        public Intersect(Point intersect1, Point intersect2, bool isIntersecting)
            : this(intersect1, intersect2, new Point(0, 0), new Point(0, 0), isIntersecting) { }

        public Intersect(Point intersect1, Point intersect2, Point intersect3, Point intersect4, bool isIntersecting)
        {
            this.PointOfIntersect1 = intersect1;
            this.PointOfIntersect2 = intersect2;
            this.PointOfIntersect3 = intersect3;
            this.PointOfIntersect4 = intersect4;
            this.IsIntersecting = isIntersecting;
        }
    }
}
