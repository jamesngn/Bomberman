using SplashKitSDK;

namespace Bomberman_V3.ShapeClasses
{
    public class Square : Shape
    {
        private Rectangle _rect;
        public Square(float x, float y, Color color, float size) : base(x, y, color)
        {
            _rect = new Rectangle(x, y, color, size, size);
        }
        public override void Draw()
        {
            _rect.Draw();
        }
    }
}
