using System.Collections.Generic;

namespace PolygonTriangulation
{
    public static class GeometryUtils
    {
        public static List<Triangle> TriangulatePolygon(List<Point> points)
        {
            var triangles = new List<Triangle>();
            for (int i = 1; i < points.Count - 1; i++)
            {
                triangles.Add(new Triangle(points[0], points[i], points[i + 1]));
            }
            return triangles;
        }
    }
}
