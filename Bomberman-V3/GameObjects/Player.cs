using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public class Player : GameObject,IMovable
    {
        private Info info = new Info();
        //--Bomberman player:
        private int bombCount = 1;
        private int bombRadius = 1;
        private int bombRemaining = 1;
        private bool hasBomb = true;
        //--IMovable interface:
        private float lastX, lastY;
        public Color BombColor { get { return info.BombColor; } }
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
        public int BombRemaining 
        {
            get { return bombRemaining; } 
            set 
            { 
                bombRemaining = value;
                if (bombRemaining == 0)
                    hasBomb = false;
            } 
        }
        public bool HasBomb { get { return hasBomb; } set { hasBomb = value; } }
        public float Speed { get { return info.Speed; } }
        public float Size { get { return info.Size; } }
        public Player(string id)
        {
            PlayerIdentity playerIdentity = new PlayerIdentity(id);
            playerIdentity.SetInfo(info);
            Shape = new Rectangle(info.RowStart*Tile.SIZE, info.ColStart*Tile.SIZE, info.Color,20,20);
            CommandProcessor.Instance().AddPlayer(this);
        }
        public void ResetBomb()
        {
            BombRemaining++;
            hasBomb = true;
        }
        public void LoseOneBomb()
        {
            BombRemaining--;
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                GoLastPosition();
            }
        }
        public void StoreLastPosition()
        {
            lastX = X;
            lastY = Y;
        }
        public void GoLastPosition()
        {
            X = lastX;
            Y = lastY;
        }
        public void Respawn()
        {
            X = Conversion.Instance().GetCoordByIndex(info.RowStart);
            Y = Conversion.Instance().GetCoordByIndex(info.ColStart);
        }
    }
}
