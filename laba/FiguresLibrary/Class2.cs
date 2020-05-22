using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shapes;
using System.Drawing;
namespace FiguresLibrary
{
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
    }
}
