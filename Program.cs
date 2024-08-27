using System;
using System.Collections.Generic;

namespace PolygonTriangulation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfVertices = 10;
            int seed = 68;
            RandomGenerator.Instance.SetSeed(seed);

            Polygon polygon = PolygonBuilder.BuildRandomPolygon(numberOfVertices, 100, 100);
            float area = AreaCalculator.CalculatePolygonArea(polygon);

            Console.WriteLine("Polygon Points:");
            foreach (var point in polygon.Points)
            {
                Console.WriteLine($"({point.X}, {point.Y})");
            }

            Console.WriteLine("\nTriangles and their areas:");
            foreach (var triangle in polygon.Triangles)
            {
                Console.WriteLine($"Triangle points: ({triangle.Points[0].X}, {triangle.Points[0].Y}), ({triangle.Points[1].X}, {triangle.Points[1].Y}), ({triangle.Points[2].X}, {triangle.Points[2].Y})");
                Console.WriteLine($"Area: {triangle.CalculateArea()}");
            }

            Console.WriteLine($"\nTotal Polygon Area: {area}");
        }
    }
}
