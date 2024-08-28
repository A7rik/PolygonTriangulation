using System;
using System.Collections.Generic;

namespace PolygonTriangulation
{
      
    public static class Triangulation
    {
        public static List<Triangle> TriangulatePolygon(List<Point> points)
        {
            var triangles = new List<Triangle>();

            while (points.Count > 3)
            {
                bool earFound = false;

                for (int i = 0; i < points.Count; i++)
                {
                    int prevIndex = (i == 0) ? points.Count - 1 : i - 1;
                    int nextIndex = (i == points.Count - 1) ? 0 : i + 1;

                    Point prev = points[prevIndex];
                    Point curr = points[i];
                    Point next = points[nextIndex];

                    if (IsEar(points, prev, curr, next))
                    {
                        triangles.Add(new Triangle(prev, curr, next));
                        points.RemoveAt(i);
                        earFound = true;
                        break;
                    }
                }

                if (!earFound)
                {
                    throw new InvalidOperationException("No ear found.");
                }
            }

            triangles.Add(new Triangle(points[0], points[1], points[2]));

            return triangles;
        }

        private static bool IsEar(List<Point> points, Point prev, Point curr, Point next)
        {
            if (!IsConvex(prev, curr, next))
            {
                return false;
            }

            for (int i = 0; i < points.Count; i++)
            {
                Point point = points[i];
                if (point.X != prev.X && point.Y != prev.Y && point.X != curr.X && point.Y != curr.Y&& point.X != next.X &&  point.Y != next.Y && IsPointInTriangle(point, prev, curr, next))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsConvex(Point a, Point b, Point c)
        {
            return CrossProduct(a, b, c) > 0;
        }

        private static double CrossProduct(Point a, Point b, Point c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }

        private static bool IsPointInTriangle(Point p, Point a, Point b, Point c)
        {
            double d1 = Sign(p, a, b);
            double d2 = Sign(p, b, c);
            double d3 = Sign(p, c, a);

            bool hasNeg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            bool hasPos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(hasNeg && hasPos);
        }

        private static double Sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }
    }
}
