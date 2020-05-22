using System.Drawing;
namespace Shapes
{
    public class Romb : Polygon
    {
        public Romb(int startPointX, int startPointY, int endPointX, int endPointY)
            : base(startPointX, startPointY, endPointX, endPointY)
        {
            Name = "Romb";

            Vertices = new Point[4];

            SetVert();
        }
        override public void SetVert()
        {
            Vertices[0].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[0].Y = Startpoint.Y;

            Vertices[1].X = Endpoint.X;
            Vertices[1].Y = (int)(Startpoint.Y + Height * 0.5);

            Vertices[2].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[2].Y = Endpoint.Y;

            Vertices[3].X = Startpoint.X;
            Vertices[3].Y = (int)(Startpoint.Y + Height * 0.5);
        }
        public override Figure Clone()
        {
            return new Romb(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y);
        }
    }
}