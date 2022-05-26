using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V2
{
    class MoveRight : Command
    {
        Player thePlayer;
        public MoveRight(Player newPlayer)
        {
            thePlayer = newPlayer;
        }
        public override void Execute()
        {
            thePlayer.X += thePlayer.Speed;
        }
    }
}
