using System.Collections.Generic;

namespace PolygonTriangulation
{
    public static class PolygonBuilder
    {
        public static Polygon BuildRandomPolygon(int verticesCount, int maxWidth, int maxHeight)
        {
            var points = new List<Point>();
            for (int i = 0; i < verticesCount; i++)
            {
                int x = RandomGenerator.Instance.Next(0, maxWidth);
                int y = RandomGenerator.Instance.Next(0, maxHeight);
                points.Add(new Point(x, y));
            }

            points.Sort((p1, p2) => Math.Atan2(p1.Y, p1.X).CompareTo(Math.Atan2(p2.Y, p2.X)));

            return new Polygon(points);
        }
    }
}
