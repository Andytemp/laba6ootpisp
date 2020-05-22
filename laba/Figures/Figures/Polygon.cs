using System.Drawing;
namespace Shapes{
    public abstract class Polygon:ClosedFigure{

        public override void UpdateHeight(int height)
        {
            Height = height;
            Endpoint.Y = Startpoint.Y + height;
            SetVert();
        }
        public override void UpdateWidth(int width)
        {
            Width = width;
            Endpoint.X = Startpoint.X + width;
            SetVert();
        }
        public override void UpdateX(int x)
        {
            Startpoint.X = x;
            Endpoint.X = x + Width;
            SetVert();
        }
        public override void UpdateY(int y)
        {
            Startpoint.Y = y;
            Endpoint.Y = y + Height;
            SetVert();
        }
        protected Point[] vertices;
        public Polygon(int startPointX, int startPointY, int endPointX, int endPointY)
        {
            Startpoint.X = startPointX;
            Startpoint.Y = startPointY;
            Endpoint.X = endPointX;
            Endpoint.Y = endPointY;

            Width = Endpoint.X - Startpoint.X;
            Height = Endpoint.Y - Startpoint.Y;
            
        }
        public Polygon() { }
        public Point[] Vertices { get { return vertices; } set { vertices = value; } }
        
        override public Point[] GetBasePoints(){
            return Vertices;
        }
        virtual public void SetVert() { 

        }/*
        public override Figure Clone()
        {
            return (new Polygon(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y));
        }*/
    }
}