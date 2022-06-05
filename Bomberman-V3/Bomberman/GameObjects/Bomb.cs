using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Bomberman_V3
{
    /// <summary>
    /// Bomb class, inherit from GameObject
    /// can be removed when it finishes count down
    /// </summary>
    public class Bomb : GameObject, IRemovable
    {
        private const int TIME = 100;
        private Player player;
        private int timeToFinish = TIME;
        private readonly float BombSize;
        private bool isPlayerLeft;
        private bool finished;

        public float BombRadius { get { return player.BombRadius; } }
        public bool IsRemoved { get { return finished; } }
        public Bomb(float x, float y, Player owner)
        {
            isPlayerLeft = false;
            player = owner;

            finished = false;

            BombSize = (float) 0.44 * Tile.SIZE;
            Shape = new Circle(BombSize, x, y, owner.BombColor);

            player.LoseOneBomb();
        }
        public void CountDown()
        {
            timeToFinish--;
            if (timeToFinish == 0)
            {
                finished = true;
                player.ResetBomb();
            }
        }
        public bool IsPlayerLeft(Player player) { return IsLeftAndCollidingWith(player); }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        /// <summary>
        /// When the bomb collides with explosion, the bomb will explode immediately by decreasing its TimeToFinished = 1
        /// </summary>
        /// <param name="explosion"></param>
        public override void ResolveCollision(Explosion explosion)
        {
            if (IsCollidingWith(explosion))
            {
                timeToFinish = 1;
            }
        }
        /// <summary>
        /// After the player leaves, the collision algorithm starts
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
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
        /// <summary>
        /// allow the owner to leave first
        /// otherwise, it will cause the bug during the collision handle
        /// </summary>
        /// <returns></returns>
        private bool IsLeftByOwner()
        {
            double rangeX1 = X - Tile.SIZE / 2;
            double rangeX2 = X + Tile.SIZE / 2;
            double rangeY1 = Y - Tile.SIZE / 2;
            double rangeY2 = Y + Tile.SIZE / 2;
            if (rangeX1 - player.Size < player.X && player.X < rangeX2 && rangeY1 - player.Size < player.Y && player.Y < rangeY2)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
