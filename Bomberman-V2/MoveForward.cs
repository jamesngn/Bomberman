using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V2
{
    public class MoveForward : Command
    {
        Player thePlayer;
        public MoveForward(Player newPlayer)
        {
            thePlayer = newPlayer;
        }
        public override void Execute()
        {
            thePlayer.Y-=thePlayer.Speed;
        }
    }
}
