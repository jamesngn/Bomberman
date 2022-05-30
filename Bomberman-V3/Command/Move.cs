using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
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
                    thePlayer.Y -= thePlayer.Speed;
                    break;
                case Direction.DOWN:
                    thePlayer.Y += thePlayer.Speed;
                    break;
                case Direction.RIGHT:
                    thePlayer.X += thePlayer.Speed;
                    break;
                case Direction.LEFT:
                    thePlayer.X -= thePlayer.Speed;
                    break;
                default:
                    break;
            }
        }
    }
}
