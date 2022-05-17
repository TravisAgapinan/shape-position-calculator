using ShapePosition.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShapePosition
{
    public class RectangleGenerator
    {
        public static IEnumerable<Rectangle> Generate()
        {
            var rectangles = new List<Rectangle>();

            // iterate for 2 rectangles
            for (var i = 0; i < 2; i++)
            {
                var coordinates = new List<int>();
                string rectangleOrder = i == 0 ? "first" : "second";

                // iterate for 2 sets of 'x' and 'y' coordinates
                for (var j = 0; j < 4; j++)
                {
                    var axis = j == 0 || j == 2 ? "'X'" : "'Y'";
                    var corner = j < 2 ? "Top Left" : "Bottom Right";

                    coordinates.Add(ValidateInput(axis, rectangleOrder, corner, coordinates));
                }

                if (!Rectangle.TryParse(coordinates[0], coordinates[1], coordinates[2], coordinates[3], out Rectangle rect))
                {
                    Console.WriteLine($"Invalid coordinates to create the {rectangleOrder} rectangle");
                    Console.WriteLine($"Please press Enter to start over");
                    Console.ReadLine();
                    Generate();
                }

                rectangles.Add(rect);
            }

            return rectangles;
        }

        private static int ValidateInput(string axis, string rectangleOrder, string corner, List<int> coordinates)
        {
            Console.WriteLine($"Enter the {corner} corner's {axis} coordinate for the {rectangleOrder} rectangle");

            if (!int.TryParse(Console.ReadLine(), out int coordinate))
            {
                Console.WriteLine("Input must be a valid integer");
                return ValidateInput(axis, rectangleOrder, corner, coordinates);
            }

            // Enforce coordinates to be a valid bottom right corner in relation to top left corner's input 
            if (corner.Equals("Bottom Right"))
            {
                //  Bottom right X coordinate must be valid
                if (coordinates.Count().Equals(2) && coordinate <= coordinates[0])
                {
                    Console.WriteLine($"Bottom Right X coordinate must be greater than Top Left X coordinate: {coordinates[0]}");
                    return ValidateInput(axis, rectangleOrder, corner, coordinates);
                }

                // Bottom Y coordinate must be valid
                if (coordinates.Count().Equals(3) && coordinate >= coordinates[1])
                {
                    Console.WriteLine($"Bottom Right Y coordinate must be less than Top Left Y coordinate: {coordinates[1]}");
                    return ValidateInput(axis, rectangleOrder, corner, coordinates);
                }
            }

            return coordinate;
        }
    }
}
