using System.Collections.Generic;
using System.Linq;

namespace PolygonTriangulation
{
    public abstract class CompositeShape : IShape
    {
        protected readonly List<IShape> Shapes = new();

        public void AddShape(IShape shape)
        {
            Shapes.Add(shape);
        }

        public float CalculateArea()
        {
            return Shapes.Sum(shape => shape.CalculateArea());
        }
    }
}
