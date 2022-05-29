﻿using SplashKitSDK;

namespace Bomberman_V3.ShapeClasses
{
    public class Circle : Shape
    {
        private float _radius;
        public Circle(float radius, float centreX, float centreY, Color color) : base(centreX, centreY, color)
        {
            _radius = radius;
        }
        public float Radius { get { return _radius; } set { _radius = value; } }
        public override void Draw()
        {
            SplashKit.FillCircle(Color, (double)X, (double)Y, (double)Radius);
        }
    }
}