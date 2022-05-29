using SplashKitSDK;
using System;

namespace Bomberman_V2
{
    public class Bomb : GameObject
    {
        private double BOMBSIZE = 0.44 * Tile.TileSize; //bomb radius dimension
        private const int TIME = 100;
        private int timeToExplosion = TIME;
        private int radius; // radius of explosion
        private Color color;
        private bool isPlayerLeft;
        public Bomb(int rowIndex, int colIndex, int radius, Color color) : base(rowIndex, colIndex)
        {
            this.radius = radius;
            this.color = color;
        }
        public override double Size { get { return Tile.TileSize; }}
        public int TimeToExplosion
        {
            get { return timeToExplosion; }
            set { timeToExplosion = value; }
        }
        public int BombRadius
        {
            get { return radius; }
        }
        public override void ResolveCollision(ICollidable collidable) 
        { 
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Player player) 
        {
            if (IsLeftAndCollidingWith(player))
            {
                player.MoveBack();
                /*Console.WriteLine("Reached!");*/
            }
        }
        private bool IsLeftAndCollidingWith(Player player)
        {
            if (!isPlayerLeft) { isPlayerLeft = IsLeftBy(player); }
            if (isPlayerLeft)
            {
                Console.WriteLine("The player collides with Bomb!: " + IsCollidingWith(player));
                if (IsCollidingWith(player))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsLeftBy(Player player)
        {
            double rangeX1 = X;
            double rangeX2 = X + Tile.TileSize;
            double rangeY1 = Y;
            double rangeY2 = Y + Tile.TileSize;
            if (rangeX1 - player.Size < player.X && player.X < rangeX2 && rangeY1 - player.Size < player.Y && player.Y < rangeY2)
            {
                Console.WriteLine("The player has not left!");
                return false;
            }
            else
            {
                Console.WriteLine("The player has left!");
                return true;
            }
        }
        public override void Draw()
        {
            double x = X + Tile.TileSize / 2;
            double y = Y + Tile.TileSize / 2;
            SplashKit.FillCircle(color, x, y, BOMBSIZE);
        }
    }
}
