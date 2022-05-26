using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V2
{
    class MoveLeft : Command
    {
        Player thePlayer;
        public MoveLeft(Player newPlayer)
        {
            thePlayer = newPlayer;
        }
        public override void Execute()
        {
            thePlayer.X -= thePlayer.Speed;
        }
    }
}
