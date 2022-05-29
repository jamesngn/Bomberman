using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    public class Enemy : GameObject
    {
        private const int SIZE = 20;
        private const int SPEED = 1;
        private int x;
        private int y;
        private string Direction = "East";
        public override int RowIndex
        {
            get { return ((x + (int) Tile.TileSize - 1) / (int) Tile.TileSize) - 1; }
        }
        public override int ColIndex
        {
            get { return ((y + (int) Tile.TileSize - 1) / (int) Tile.TileSize) - 1; }
        }
        public override int X { get { return x; } set { x = value; } }
        public override int Y { get { return y; } set { y = value; } }
        public Enemy(int rowIndex, int colIndex) : base(rowIndex, colIndex)
        {
            Color = SplashKit.ColorLavender();
            x = rowIndex * (int) Tile.TileSize;
            y = colIndex * (int) Tile.TileSize;
        }
        public void Move()
        {
            x -= SPEED;
           /* y -= SPEED;*/
            Console.WriteLine("X = {0}; Y = {1} ", X, Y);
        }
        public void ChangeDirection()
        {
            switch (Direction)
            {
                case "East":
                    Direction = "West";
                    break;
                case "West":
                    Direction = "East";
                    break;
                case "North":
                    Direction = "South";
                    break;
                case "South":
                    Direction = "North";
                    break;
                default:
                    break;
            }
        }
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, SIZE, SIZE);
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
    }
}
