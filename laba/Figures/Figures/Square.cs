using System.Drawing;
namespace Shapes{
    public class Square:Shapes.Rectangle{

        public override void UpdateHeight(int height)
        {
            Height = height;
            Endpoint.Y = Startpoint.Y + Height;
            Width = height;
            Endpoint.X = Startpoint.X + Width;
            SetVert();
        }
        public override void UpdateWidth(int width)
        {
            Width = width;
            Endpoint.X = Startpoint.X + Width;
            Height = width;
            Endpoint.Y = Startpoint.Y + Height;
            SetVert();
        }
        public Square(int startPointX, int startPointY, int endPointX, int endPointY)
            : base(startPointX, startPointY, endPointX, endPointY)
        {
            Name = "Square";

            Vertices = new Point[4];

            SetVert();
        }
        override public void SetVert()
        {
            if (System.Math.Abs(Height) >= System.Math.Abs(Width))
            {
                Height = System.Math.Sign(Height) * System.Math.Abs(Width);
            }
            else
            {
                Width = System.Math.Sign(Width) * System.Math.Abs(Height);
            }
            Vertices[0].X = Startpoint.X;
            Vertices[0].Y = Startpoint.Y;
            Vertices[1].X = Startpoint.X + Width;
            Vertices[1].Y = Startpoint.Y;
            Vertices[2].X = Startpoint.X + Width;
            Vertices[2].Y = Startpoint.Y + Height;
            Vertices[3].X = Startpoint.X;
            Vertices[3].Y = Startpoint.Y + Height;
        }

    }
}