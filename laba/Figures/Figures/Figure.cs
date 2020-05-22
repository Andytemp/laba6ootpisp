using System.Drawing;
namespace Shapes{
    public abstract class Figure{
        protected int rotaion;
        private int width;
        public string Name = "Figure";
        public virtual int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;

        public virtual int Height
        {
            get { return height; }
            set { height = value; }
        }
        public Point Startpoint;
        public Point Endpoint;
        protected Color color=Color.Red;
        public Color ShapeColor
        {
            get  
            {
                return color;  
            }  
            set  
            {
                color = value;  
            }  
        }
        public int Rotation{
            get  
            {  
                return rotaion;  
            }  
            set  
            {  
                rotaion = value;  
            }  
        }

        public abstract Point[] GetBasePoints();
        public void SetLengthWidth(int width, int height) {
            this.width = width;
            this.height = height;
            Endpoint.X = Startpoint.X + this.width;
            Endpoint.Y = Startpoint.Y + this.height;
        }
        public void Move(int newx, int newy) {
            Startpoint.X = newx;
            Startpoint.Y = newy;
            Endpoint.X = Startpoint.X + width;
            Endpoint.Y = Startpoint.Y + height;
        }
        public virtual void UpdateWidth(int width){
            Width = width;
        }
        public virtual void UpdateHeight(int height)
        {
            Height = height;
        }
        public virtual void UpdateX(int x)
        {
            Startpoint.X = x;
        }
        public virtual void UpdateY(int y)
        {
            Startpoint.Y = y;
        }
        public abstract Figure Clone();
    }
}