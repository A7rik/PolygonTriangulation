using System.Collections.Generic;

namespace PolygonTriangulation
{
    public static class ShapeFactory
    {
        public static IShape CreateShape(string shapeType, List<Point> points)
        {
            return shapeType switch
            {
                "Polygon" => new Polygon(points),
                _ => throw new System.ArgumentException("Invalid shape type"),
            };
        }
    }
}
