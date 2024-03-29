﻿using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// Abstract class: has basic information of a Shape such as X, Y, Draw method, Color
    /// </summary>
    public abstract class Shape 
    {
        private float _x, _y;
        private Color _color;
        public Shape (float x, float y, Color color)
        {
            _x = x;
            _y = y;
            _color = color;
        }
        public abstract bool IsAt(Point2D point);
        public abstract void Draw();
        public float X { get { return _x; } set { _x = value; } }
        public float Y { get { return _y; } set { _y = value; } }
        public Color Color { get { return _color; } set { _color = value; } }
    }
}
