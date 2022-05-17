using ShapePosition.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Rectangle = ShapePosition.Models.Rectangle;

namespace ShapePosition
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Rectangle> rectangles = RectangleGenerator.Generate();

            var posCal = new RectanglePositionCalculator(rectangles.First(), rectangles.Last());

            PositionResponse result = posCal.CalculatePositions();

            WriteResponse(result);
        }

        private static void WriteResponse(PositionResponse result)
        {
            Console.WriteLine("\nResults: \n" + $"Is Intersecting: {result.Intersect.IsIntersecting}");

            if (result.Intersect.IsIntersecting)
            {
                string pointsOfIntersect = $"    Points of Intersect: {result.Intersect.PointOfIntersect1}, {result.Intersect.PointOfIntersect2}";

                if (result.Intersect.PointOfIntersect3 != Point.Empty && result.Intersect.PointOfIntersect4 != Point.Empty)
                {
                    pointsOfIntersect += $", {result.Intersect.PointOfIntersect3}, {result.Intersect.PointOfIntersect4}";
                }

                Console.WriteLine(pointsOfIntersect);
            }

            Console.WriteLine($"Is Adjacent: {result.Adjacency.IsAdjacent} \n    Adjacency Type: {result.Adjacency.AdjacencyType}");
            Console.WriteLine($"Is Contained: {result.Contained.IsContained}");
            Console.ReadLine();
        }
    }
}
