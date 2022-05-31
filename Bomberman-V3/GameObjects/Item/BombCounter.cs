using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public class BombCounter : Item
    {
        public BombCounter(float x, float y) : base(x, y, SplashKit.ColorDeepPink()) { }
        public override void AddToPlayer(Player player)
        {
            player.BombCount++;
        }
    }
}
