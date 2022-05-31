using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    class BombCounter : Item
    {
        public BombCounter(int RowIndex, int ColIndex) : base(RowIndex, ColIndex, SplashKit.ColorDeepPink()) { }
        public override void AddToPlayer(Player player)
        {
            player.BombCount++;
        }
    }
}
