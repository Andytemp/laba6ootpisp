namespace Shapes{
    public class Circle:Ellipse{
        public Circle(int startPointX,int startPointY, int endPointX, int endPointY){
            Name = "Circle";
            BaseRectangle = new Square(startPointX, startPointY, endPointX, endPointY);
            Startpoint = BaseRectangle.Startpoint;
            Endpoint = BaseRectangle.Endpoint;
        }
    }
}