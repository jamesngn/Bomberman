using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// implements IMovable and IRemovable interface
    /// </summary>
    public class Enemy : GameObject, IMovable, IRemovable
    {
        private int size;
        private static float speed = 1;
        private Direction Direction;
        private bool dead;
        public bool IsRemoved 
        { 
            get { return dead; }
        }
        public Enemy(float x, float y) 
        {
            size = 20;
            Shape = new Rectangle(x, y, SplashKit.ColorChocolate(), size, size);
            dead = false;
        }
        /// <summary>
        /// Move in the direction by changing the X or Y value
        /// </summary>
        public void Move()
        {
            switch (Direction)
            {
                case Direction.RIGHT:
                    X += speed;
                    break;
                case Direction.LEFT:
                    X -= speed;
                    break;
                case Direction.UP:
                    Y += speed;
                    break;
                case Direction.DOWN:
                    Y -= speed;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// Randomise direction for enemy's moving
        /// </summary>
        public void RandomiseDirection()
        {
            Random rnd = new Random();
            double randomNumb = rnd.NextDouble();
            float RANDOMISE_DIRECTION_CHANCE = (float)0.0001;
            if (randomNumb <= RANDOMISE_DIRECTION_CHANCE)
            {
                if (Direction == Direction.UP || Direction == Direction.DOWN)
                {
                    if (0 <= randomNumb && randomNumb <= RANDOMISE_DIRECTION_CHANCE / 2)
                    {
                        Direction = Direction.RIGHT;
                    }
                    else if (RANDOMISE_DIRECTION_CHANCE / 2 < randomNumb && randomNumb <= RANDOMISE_DIRECTION_CHANCE)
                    {
                        Direction = Direction.LEFT;
                    }
                }
                else if (Direction == Direction.RIGHT || Direction == Direction.LEFT)
                {
                    if (0 <= randomNumb && randomNumb <= RANDOMISE_DIRECTION_CHANCE / 2)
                    {
                        Direction = Direction.UP;
                    }
                    else if (RANDOMISE_DIRECTION_CHANCE / 2 < randomNumb && randomNumb <= RANDOMISE_DIRECTION_CHANCE)
                    {
                        Direction = Direction.DOWN;
                    }
                }
            }
        }
        /// <summary>
        /// This is called when the enemy collides with the Tile or Player or bomb
        /// </summary>
        private void ChangeOppositeDirection()
        {
            switch (Direction)
            {
                case Direction.RIGHT:
                    Direction = Direction.LEFT;
                    break;
                case Direction.LEFT:
                    Direction = Direction.RIGHT;
                    break;
                case Direction.UP:
                    Direction = Direction.DOWN;
                    break;
                case Direction.DOWN:
                    Direction = Direction.UP;
                    break;
                default:
                    break;
            }
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(BreakableTile tile)
        {
            if (IsCollidingWith(tile))
            {
                ChangeOppositeDirection();
            }
        }
        public override void ResolveCollision(UnbreakableTile tile)
        {
            if (IsCollidingWith(tile))
            {
                ChangeOppositeDirection();
            }
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                ChangeOppositeDirection();
            }
        }
        /// <summary>
        /// being removed when collding with explosion
        /// </summary>
        /// <param name="explosion"></param>
        public override void ResolveCollision(Explosion explosion)
        {
            if (IsCollidingWith(explosion))
            {
                dead = true;
                speed += (float) 0.25;
            }
        }
        public override void ResolveCollision(Bomb bomb)
        {
            if (IsCollidingWith(bomb))
            {
                ChangeOppositeDirection();
            }
        }
    }
}
