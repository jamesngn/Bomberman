using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public class Player : GameObject
    {
        public static int ROW_START = 1;
        public static int COL_START = 1;
        private float speed = 5;
        private float size = 20;
        private float lastX, lastY;
        public float Speed { get { return speed; } private set { speed = value; } }
        public float Size { get { return size; } }
        public float LastX { get { return lastX; } set { lastX = value; } }
        public float LastY { get { return lastY; } set { lastY = value; } }
        public Player(string id)
        {
            if (id == "p1")
            {
                Shape = new Rectangle(ROW_START*Tile.SIZE, COL_START*Tile.SIZE, SplashKit.ColorPurple(),20,20);
            } 
            else if (id == "p2")
            {
                Shape = new Rectangle(10, 20, SplashKit.ColorRed(), size, size);
            }
            CommandProcessor.Instance().AddPlayer(this);
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public void StoreLastPosition()
        {
            LastX = X;
            LastY = Y;
        }
        public void GoLastPosition()
        {
            X = LastX;
            Y = LastY;
        }
        public void Respawn()
        {
            X = Conversion.Instance().GetCoordByIndex(ROW_START);
            Y = Conversion.Instance().GetCoordByIndex(COL_START);
        }
    }
}
