using System.Drawing;
namespace Shapes
{
    public class Arrow : Polygon
    {
        public Arrow(int startPointX, int startPointY, int endPointX, int endPointY)
            : base(startPointX, startPointY, endPointX, endPointY)
        {
            Name = "Arrow";

            Vertices = new Point[7];

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

            Vertices[3].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[3].Y = (int)(Startpoint.Y + Height * 0.75);

            Vertices[4].X = Startpoint.X;
            Vertices[4].Y = (int)(Startpoint.Y + Height * 0.75);

            Vertices[5].X = Startpoint.X;
            Vertices[5].Y = (int)(Startpoint.Y + Height * 0.25);

            Vertices[6].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[6].Y = (int)(Startpoint.Y + Height * 0.25);
        }
        public override Figure Clone()
        {
            return new Arrow(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y);
        }
    }
}