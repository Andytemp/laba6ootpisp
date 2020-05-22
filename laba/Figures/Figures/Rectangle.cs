using System.Drawing;
namespace Shapes{
    public class Rectangle:Polygon{
        public Rectangle() { }
        public Rectangle(int startPointX,int startPointY, int endPointX, int endPointY):base( startPointX, startPointY,  endPointX,  endPointY){
            
            Name = "Rectangle";
            
            Vertices=new Point[4];

            SetVert();
        }
        override public void SetVert() {
            Vertices[0].X = Startpoint.X;
            Vertices[0].Y = Startpoint.Y;
            Vertices[1].X = Endpoint.X;
            Vertices[1].Y = Startpoint.Y;
            Vertices[2].X = Endpoint.X;
            Vertices[2].Y = Endpoint.Y;
            Vertices[3].X = Startpoint.X;
            Vertices[3].Y = Endpoint.Y;
        }
        public override Figure Clone()
        {
            return new Rectangle(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y);
        }
    }
}