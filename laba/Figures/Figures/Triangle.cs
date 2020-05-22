using System.Drawing;
namespace Shapes
{
    public class Triangle : Polygon
    {
        public Triangle(int startPointX, int startPointY, int endPointX, int endPointY)
            : base(startPointX, startPointY, endPointX, endPointY)
        {
            Name = "Triangle";
            
            Vertices = new Point[3];

            SetVert();

        }
        override public void SetVert()
        {
            Vertices[0].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[0].Y = Startpoint.Y;

            Vertices[1].X = Endpoint.X;
            Vertices[1].Y = Endpoint.Y;

            Vertices[2].X = Startpoint.X;
            Vertices[2].Y = Endpoint.Y;
        }
        public override Figure Clone()
        {
            return new Triangle(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y);
        }
    }
}