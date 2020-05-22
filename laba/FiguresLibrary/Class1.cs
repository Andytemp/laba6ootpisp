using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shapes;
using System.Drawing;
namespace laba.Plugins
{
    public class Star : Polygon
    {
        public Star(int startPointX, int startPointY, int endPointX, int endPointY)
            : base(startPointX, startPointY, endPointX, endPointY)
        {
            Name = "Star";

            Vertices = new Point[10];

            SetVert();

        }
        override public void SetVert()
        {

            Vertices[0].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[0].Y = Startpoint.Y;

            Vertices[1].X = (int)(Startpoint.X + Width * 0.6);
            Vertices[1].Y = (int)(Startpoint.Y + Height * 0.4);

            Vertices[2].X = Endpoint.X;
            Vertices[2].Y = (int)(Startpoint.Y + Height * 0.4);

            Vertices[3].X = (int)(Startpoint.X + Width * 0.7);
            Vertices[3].Y = (int)(Startpoint.Y + Height * 0.6);

            Vertices[4].X = (int)(Startpoint.X + Width * 0.8);
            Vertices[4].Y = Endpoint.Y;

            Vertices[5].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[5].Y = (int)(Startpoint.Y + Height * 0.8);

            Vertices[6].X = (int)(Startpoint.X + Width * 0.2);
            Vertices[6].Y = Endpoint.Y;

            Vertices[7].X = (int)(Startpoint.X + Width * 0.3);
            Vertices[7].Y = (int)(Startpoint.Y + Height * 0.6);

            Vertices[8].X = Startpoint.X;
            Vertices[8].Y = (int)(Startpoint.Y + Height * 0.4);

            Vertices[9].X = (int)(Startpoint.X + Width * 0.4);
            Vertices[9].Y = (int)(Startpoint.Y + Height * 0.4);
        }
        public override Figure Clone()
        {
            return new Star(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y);
        }
    }
    public class Hexagon : Polygon
    {
        public Hexagon(int startPointX, int startPointY, int endPointX, int endPointY)
            : base(startPointX, startPointY, endPointX, endPointY)
        {
            Name = "Hexagon";

            Vertices = new Point[6];

            SetVert();

        }
        override public void SetVert()
        {

            Vertices[0].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[0].Y = Startpoint.Y;

            Vertices[1].X = Endpoint.X;
            Vertices[1].Y = (int)(Startpoint.Y + Height * 0.25);

            Vertices[2].X = Endpoint.X;
            Vertices[2].Y = (int)(Startpoint.Y + Height * 0.75);

            Vertices[3].X = (int)(Startpoint.X + Width * 0.5);
            Vertices[3].Y = Endpoint.Y;

            Vertices[4].X = Startpoint.X;
            Vertices[4].Y = (int)(Startpoint.Y + Height * 0.75);

            Vertices[5].X = Startpoint.X;
            Vertices[5].Y = (int)(Startpoint.Y + Height * 0.25);
        }
        public override Figure Clone()
        {
            return new Hexagon(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y);
        }
    }
}