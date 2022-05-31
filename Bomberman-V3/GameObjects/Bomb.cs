using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Bomberman_V3
{
    public class Bomb : GameObject,IDownCountable
    {
        private const int TIME = 100;
        private int timeToFinish = TIME;
        private readonly float BombSize;
        private Player player;
        private bool isPlayerLeft;
        private bool finished;
        public int TimeToFinish 
        {
            get { return timeToFinish; } 
            set 
            {
                timeToFinish = value;
                if (timeToFinish == 0)
                {
                    finished = true;
                    player.ResetBomb();
                }
            } 
        }
        public float BombRadius { get { return player.BombRadius; } }
        public bool Finished { get { return finished; } }
        public Bomb(float x, float y, Player owner)
        {
            isPlayerLeft = false;
            player = owner;

            finished = false;

            BombSize = (float) 0.44 * Tile.SIZE;
            Shape = new Circle(BombSize, x, y, owner.BombColor);

            player.LoseOneBomb();
            Console.WriteLine("player has bomb: " + player.BombRemaining);
        }
        public void CountDown()
        {
            TimeToFinish--;
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Explosion explosion)
        {
            if (IsCollidingWith(explosion))
            {
                TimeToFinish = 1;
            }
        }
        public override void ResolveCollision(Player player)
        {
            if (IsLeftAndCollidingWith(player))
            {
                player.GoLastPosition();
                Console.WriteLine("Reached");
            }
        }
        private bool IsLeftAndCollidingWith(Player player)
        {
            if (!isPlayerLeft) { isPlayerLeft = IsLeftByOwner(); }
            if (isPlayerLeft)
            {
                if (IsCollidingWith(player))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsLeftByOwner()
        {
            double rangeX1 = X - Tile.SIZE / 2;
            double rangeX2 = X + Tile.SIZE / 2;
            double rangeY1 = Y - Tile.SIZE / 2;
            double rangeY2 = Y + Tile.SIZE / 2;
            if (rangeX1 - player.Size < player.X && player.X < rangeX2 && rangeY1 - player.Size < player.Y && player.Y < rangeY2)
            {
/*                Console.WriteLine("The player has not left!");
*/                return false;
            }
            else
            {
/*                Console.WriteLine("The player has left!");
*/                return true;
            }
        }
    }
}
