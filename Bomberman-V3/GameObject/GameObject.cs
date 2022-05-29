using System;
using System.Collections.Generic;
using SplashKitSDK;
using Bomberman_V3.ShapeClasses;

namespace Bomberman_V3.GameObject
{
    public abstract class GameObject
    {
        private Shape _shape;
        public GameObject(Shape shape)
        {
            _shape = shape;
        }
        public float X { get { return _shape.X; } }
        public float Y { get { return _shape.Y; } }
        public Shape Shape { get { return _shape; } }
        
        public bool IsCollidingWith(GameObject collider)
        {
            return CollisionChecker.Instance().IsColliding(this._shape, collider._shape);
        }
    }
}
