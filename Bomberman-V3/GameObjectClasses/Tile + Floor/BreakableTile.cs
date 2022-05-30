using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public class BreakableTile : Tile
    {
        public BreakableTile(float x, float y) : base(x, y, SplashKit.ColorBrown()) { }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                player.GoLastPosition();
                Console.WriteLine("Colliding with Breakable Tile");
            }
        }
    }
}
