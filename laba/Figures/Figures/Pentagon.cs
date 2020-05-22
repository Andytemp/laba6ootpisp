using System.Drawing;
namespace Shapes
{
    public class Pentagon : Polygon
    {
        public Pentagon(int startPointX, int startPointY, int endPointX, int endPointY)
            : base(startPointX, startPointY, endPointX, endPointY)
        {
            Name = "Pentagon";

            Vertices = new Point[5];

            SetVert();


        }
        override public void SetVert()
        {
            Vertices[0].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[0].Y = Startpoint.Y;

            Vertices[1].X = Endpoint.X;
            Vertices[1].Y = (int)(Startpoint.Y + Height * 2 / 5);

            Vertices[2].X = (int)(Startpoint.X + Width * 0.8);
            Vertices[2].Y = Endpoint.Y;

            Vertices[3].X = (int)(Startpoint.X + Width * 0.2);
            Vertices[3].Y = Endpoint.Y;

            Vertices[4].X = Startpoint.X;
            Vertices[4].Y = (int)(Startpoint.Y + Height * 2 / 5);
        }
        public override Figure Clone()
        {
            return new Pentagon(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y);
        }
    }
}