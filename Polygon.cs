using System.Collections.Generic;

namespace PolygonTriangulation
{
    public class Polygon : CompositeShape
    {
        public List<Point> Points { get; }
        public List<Triangle> Triangles { get; }

        public Polygon(List<Point> points)
        {
            Points = points;
            // Triangles = GeometryUtils.TriangulatePolygon(points);
            Triangles = Triangulation.TriangulatePolygon(points);
            foreach (var triangle in Triangles)
            {
                AddShape(triangle);
            }
        }
    }
}
