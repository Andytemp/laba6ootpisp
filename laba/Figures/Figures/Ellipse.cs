using System.Drawing;
namespace Shapes{
    public class Ellipse:ClosedFigure{
        public Rectangle BaseRectangle;
        public Ellipse() { }
        override public  int Width
        {
            get { return BaseRectangle.Width; }
            set { BaseRectangle.Width = value; }
        }
        override public  int Height
        {
            get { return BaseRectangle.Height; }
            set { BaseRectangle.Height = value; }
        }
        public override void UpdateHeight(int height)
        {
            BaseRectangle.UpdateHeight(height);
        }
        public override void UpdateWidth(int width)
        {
            BaseRectangle.UpdateWidth(width);
        }
        public override void UpdateX(int x)
        {
            BaseRectangle.UpdateX(x);
            Startpoint = BaseRectangle.Startpoint;
        }
        public override void UpdateY(int y)
        {
            BaseRectangle.UpdateY(y);
            Startpoint = BaseRectangle.Startpoint;
        }
        public Ellipse(int startPointX,int startPointY, int endPointX, int endPointY){
            Name = "Ellipse";
            BaseRectangle=new Rectangle(startPointX,startPointY,endPointX,endPointY);
            Startpoint = BaseRectangle.Startpoint;
            Endpoint = BaseRectangle.Endpoint;


        }
        override public Point[] GetBasePoints(){
            return BaseRectangle.Vertices;
        }
        public override Figure Clone()
        {
            return new Ellipse(Startpoint.X, Startpoint.Y, Endpoint.X, Endpoint.Y);
        }
    }
}