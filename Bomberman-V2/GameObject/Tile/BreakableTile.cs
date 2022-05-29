using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    class BreakableTile : Tile
    {
        public BreakableTile(int RowIndex, int ColIndex) : base(RowIndex, ColIndex, SplashKit.ColorBrown()) { }
        public override void ResolveCollision(ICollidable collidable)
        {
            /*collidable.ResolveCollision(this);*/
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                player.MoveBack();
                Console.WriteLine("Detect collision! with Breakble ");
            }
        }
        public override void ResolveCollision(Enemy enemy)
        {
            if (IsCollidingWith(enemy))
            {
                Console.WriteLine("Enemy collides with Breakable ");
            }
        }
    }
}
