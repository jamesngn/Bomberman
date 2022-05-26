using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    class BombRadius : Item
    {
        public BombRadius(int RowIndex, int ColIndex) : base(RowIndex, ColIndex, SplashKit.ColorDarkBlue()) { }
        public override void AddToPlayer(Player player)
        {
            player.BombRadius++;
        }
    }
}
