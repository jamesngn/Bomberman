using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    public class UnbreakableTile : Tile
    {
        public UnbreakableTile(int RowIndex, int ColIndex) : base(RowIndex, ColIndex, SplashKit.ColorBlack()) { }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                player.MoveBack();
                Console.WriteLine("Detect collision! with Unbreakable");
            }
        }
        public override void ResolveCollision(Enemy enemy)
        {
            if (IsCollidingWith(enemy))
            {
               /* enemy.ChangeDirection();*/
                Console.WriteLine("Enemy collides with Unbreakable ");
            }
        }
    }
}
