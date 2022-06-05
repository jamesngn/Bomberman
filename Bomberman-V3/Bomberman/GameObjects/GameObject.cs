using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// Implement ICollidable interface to process the collision between different game objects
    /// This ICollidable is a part of visitor design pattern
    /// Has a Shape - used to define the shape of the GameObject, coordinates X and Y and Length
    /// </summary>
    public abstract class GameObject : ICollidable
    {
        public abstract void ResolveCollision(ICollidable collidable);
        public virtual void ResolveCollision(BreakableTile tile) { }
        public virtual void ResolveCollision(UnbreakableTile tile) { }
        public virtual void ResolveCollision(Player player) { }
        public virtual void ResolveCollision(Explosion explosion) { }
        public virtual void ResolveCollision(Enemy enemy) { }
        public virtual void ResolveCollision(Bomb bomb) { }
        public virtual void ResolveCollision(Item item) { }
        public GameObject() 
        {
            GameObjectManager.Instance().Add(this);
        }
        /// <summary>
        /// Check the collsion with other game objects
        /// Use CollisionChecker class
        /// </summary>
        /// <param name="collider">
        /// collider is a gameobject, also has Shape - use Shape to check collision
        /// </param>
        /// <returns>
        /// return true means colliding, return false means not colliding
        /// </returns>
        public bool IsCollidingWith(GameObject collider)
        {
            return CollisionChecker.Instance().IsColliding(this.Shape, collider.Shape);
        }
        public float X { get { return Shape.X; } protected set { Shape.X = value; } }
        public float Y { get { return Shape.Y; } protected set { Shape.Y = value; } }
        public virtual Shape Shape { get; set; }
    }
}
