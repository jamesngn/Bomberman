using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// abstract class, inherits from GameObject
    /// implement IRemovable to remove the items when it is picked
    /// The design of Item class follows the Strategy Design Pattern
    /// </summary>
    public abstract class Item : GameObject, IRemovable
    {
        private const int SIZE = 15;
        private bool removed;
        public bool IsRemoved { get { return removed; } }
        public Item(float x, float y, Color color)
        {
            Shape = new Rectangle(x, y, color, SIZE, SIZE);
            removed = false;
        }
        /// <summary>
        /// add the property of the item to the collector
        /// </summary>
        /// <param name="player"></param>
        protected abstract void AddToPlayer(Player player);
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                AddToPlayer(player);
                removed = true;
            }
        }
    }
}
