using System;

namespace PolygonTriangulation
{
    public class Triangle : IShape
    {
        public Point[] Points { get; }

        public Triangle(Point p1, Point p2, Point p3)
        {
            Points = new[] { p1, p2, p3 };
        }

        public float CalculateArea()
        {
            float Area = Math.Abs((Points[0].X * (Points[1].Y - Points[2].Y) +
                             Points[1].X * (Points[2].Y - Points[0].Y) +
                             Points[2].X * (Points[0].Y - Points[1].Y)) / 2);
            Console.WriteLine(Area);
            return Area;
        }
    }
}

