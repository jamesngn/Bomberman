using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    //move the player position based on Direction enum
    public class Move : Command
    {
        private Player thePlayer;
        private Direction _direction;
        public Move(Player newPlayer, Direction direction)
        {
            thePlayer = newPlayer;
            _direction = direction;
        }
        public override void Execute()
        {
            switch (_direction)
            {
                case Direction.UP:
                    thePlayer.Move(0,-1);
                    break;
                case Direction.DOWN:
                    thePlayer.Move(0,1);
                    break;
                case Direction.RIGHT:
                    thePlayer.Move(1,0);
                    break;
                case Direction.LEFT:
                    thePlayer.Move(-1,0);
                    break;
                default:
                    break;
            }
        }
    }
}
