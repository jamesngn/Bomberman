using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// implements IRemovable to remove the tile when it collides with explosion
    /// </summary>
    public class BreakableTile : Tile, IRemovable
    {
        private bool destroyed;
        public BreakableTile(float x, float y) : base(x, y, SplashKit.ColorBrown()) 
        {
            destroyed = false;
        }
        public bool IsRemoved 
        { 
            get { return destroyed; } 
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Explosion explosion)
        {
            if (IsCollidingWith(explosion))
            {
                destroyed = true;
            }
        }
    }
}
