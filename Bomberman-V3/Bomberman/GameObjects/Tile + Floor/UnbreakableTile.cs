using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// cannot destroy and cannot move through this block
    /// </summary>
    public class UnbreakableTile : Tile
    {
        public UnbreakableTile(float x, float y) : base(x, y, SplashKit.ColorBlack()) { }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
    }
}
