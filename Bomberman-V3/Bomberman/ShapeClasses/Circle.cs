using SplashKitSDK;

namespace Bomberman_V3
{
    public class Circle : Shape
    {
        private float _radius;
        public Circle(float radius, float centreX, float centreY, Color color) : base(centreX, centreY, color)
        {
            _radius = radius;
        }
        public override bool IsAt(Point2D point)
        {
            return (SplashKit.PointInCircle(point, SplashKit.CircleAt(point, _radius)));
        }
        public float Radius { get { return _radius; } set { _radius = value; } }
        public override void Draw()
        {
            SplashKit.FillCircle(Color, (double)X, (double)Y, (double)Radius);
        }
    }
}
