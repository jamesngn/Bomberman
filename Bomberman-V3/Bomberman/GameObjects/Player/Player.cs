using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public class Player : GameObject, IMovable, IRemovable
    {
        /// <summary>
        /// Info stores basic information of the player, such as Color, Bomb Color, Size,...
        /// </summary>
        private Info info = new Info();
        //--Bomberman player:
        private string theID;
        private int bombCount = 1;
        private int bombRadius = 1;
        private int bombRemaining = 1;
        private bool hasBomb = true;
        private bool dead;
        //--IMovable interface:
        public string ID { get { return theID; } }
        public Color BombColor { get { return info.BombColor; } }
        private float lastX, lastY;
        public float Size { get { return info.Size; } }
        public int BombCount 
        {
            get { return bombCount; }
            set 
            {
                bombCount = value;
                bombRemaining++;
            }
        }
        public int BombRadius { get { return bombRadius; } set { bombRadius = value; } }
        public bool HasBomb { get { return hasBomb; } set { hasBomb = value; } }
        public bool IsRemoved { get { return dead; } }
        /// <summary>
        /// used PlayerIdentity class to set the Player's Info.
        /// </summary>
        /// <param name="id"></param>
        public Player(string newID, GameMode gameMode)
        {
            PlayerIdentity playerIdentity = new PlayerIdentity(newID, gameMode);
            playerIdentity.SetInfo(info);
            theID = newID;
            dead = false; 

            float xStart = Conversion.Instance().GetCoordByIndex(info.RowStart);
            float yStart = Conversion.Instance().GetCoordByIndex(info.ColStart);
            Shape = new Rectangle(xStart, yStart, info.Color,info.Size,info.Size);

            CommandProcessor.Instance().AddPlayer(this);
        }
        /// <summary>
        /// ResetBomb() is called when the previously placed bomb is exploded
        /// to increase the remaining bomb
        /// </summary>
        public void ResetBomb()
        {
            bombRemaining++;
            hasBomb = true;
        }
        /// <summary>
        /// is called when the new bomb is placed
        /// to decrease the remaining bomb
        /// </summary>
        public void LoseOneBomb()
        {
            bombRemaining--;
            if (bombRemaining == 0)
            {
                hasBomb = false;
            }
        }
        public void Move(int horizontalDir, int verticalDir)
        {
            X += info.Speed * horizontalDir;
            Y += info.Speed * verticalDir;
        }
        /// <summary>
        /// store the previous position to move the player positon back in case of the player being collided with other objects
        /// </summary>
        public void StoreLastPosition()
        {
            lastX = X;
            lastY = Y;
        }
        /// <summary>
        /// move back the player to previous position to enable the collision logic
        /// </summary>
        private void ChangeOppositeDirection()
        {
            X = lastX;
            Y = lastY;
        }
        /// <summary>
        /// move back to the initial position when colldiing with explosion, enemies
        /// </summary>
        private void Respawn()
        {
            X = Conversion.Instance().GetCoordByIndex(info.RowStart);
            Y = Conversion.Instance().GetCoordByIndex(info.ColStart);
        }
        private void LoseHealth()
        {
            info.Health--;
            Console.WriteLine("The player " + theID + "'s current HP = " + info.Health);
            if (info.Health == 0)
            {
                dead = true;
                Console.WriteLine("The player " + theID + " died");
            }
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                ChangeOppositeDirection();
            }
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
        public override void ResolveCollision(Enemy enemy)
        {
            if (IsCollidingWith(enemy))
            {
                LoseHealth();
                Respawn();
            }
        }
        public override void ResolveCollision(Explosion explosion)
        {
            if (IsCollidingWith(explosion))
            {
                LoseHealth();
                Respawn();
            }
        }
        public override void ResolveCollision(Bomb bomb)
        {
            if (bomb.IsPlayerLeft(this))
            {
                ChangeOppositeDirection();
            }
        }
    }
}
