using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public abstract class Item : GameObject, IPickable
    {
        private const int SIZE = 30;
        private bool picked;
        public bool IsPicked { get { return picked; } }
        public Item(float x, float y, Color color)
        {
            Shape = new Rectangle(x, y, color, SIZE, SIZE);
            picked = false;
        }
        public abstract void AddToPlayer(Player player);
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                AddToPlayer(player);
                picked = true;
                Console.WriteLine("Player is colldiing with Item");
            }
        }
    }
}
