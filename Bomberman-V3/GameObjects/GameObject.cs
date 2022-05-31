using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Bomberman_V3
{
    public abstract class GameObject : ICollidable
    {
        public virtual void ResolveCollision(ICollidable collidable) { }
        public virtual void ResolveCollision(BreakableTile tile) { }
        public virtual void ResolveCollision(UnbreakableTile tile) { }
        public virtual void ResolveCollision(Player player) { }
        public virtual void ResolveCollision(Explosion explosion) { }
        public virtual Shape Shape { get; set; }
        public float X { get { return Shape.X; } set { Shape.X = value; } }
        public float Y { get { return Shape.Y; } set { Shape.Y = value; } }
        public GameObject() 
        {
            SingleSource.Instance().Add(this);
        }
        public bool IsCollidingWith(GameObject collider)
        {
            return CollisionChecker.Instance().IsColliding(this.Shape, collider.Shape);
        }
    }
}
