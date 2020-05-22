using System.Drawing;
using System.Xml.Serialization;
namespace Shapes
{
    public class Line : Polygon
    {
        public Line(){}
        public Line(int startPointX, int startPointY, int endPointX, int endPointY)
            : base(startPointX, startPointY, endPointX, endPointY)
        {
            Name = "Line";

            Vertices = new Point[2];

            SetVert();

        }
        override public void SetVert()
        {
            Vertices[0].X = Startpoint.X;
            Vertices[0].Y = Startpoint.Y;

            Vertices[1].X = Endpoint.X;
            Vertices[1].Y = Endpoint.Y;
        }
        public override Figure Clone()
        {
            return new Line(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y);
        }
    }
}