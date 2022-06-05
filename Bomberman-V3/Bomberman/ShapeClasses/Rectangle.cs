using SplashKitSDK;

namespace Bomberman_V3
{
    public class Rectangle : Shape
    {
        private float _width;
        private float _height;
        public Rectangle(float x, float y, Color color, float width, float height) : base(x,y,color)
        {
            _width = width;
            _height = height;
        }
        public override bool IsAt(Point2D point)
        {
            return (point.X > X && point.X < X + Width && point.Y > Y && point.Y < Y + Height);
        }
        public float Width { get { return _width; } set { _width = value; } }
        public float Height { get { return _height; } set { _height = value; } }
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, (double)X, (double)Y, (double)Width, (double)Height);
        }
    }
}
