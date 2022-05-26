using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    class Enemy : GameObject
    {
        private const int SIZE = 20;
        private const int SPEED = 1;
        private int x;
        private int y;
        public override int RowIndex
        {
            get { return ((x + Tile.TileSize - 1) / Tile.TileSize) - 1; }
        }
        public override int ColIndex
        {
            get { return ((y + Tile.TileSize - 1) / Tile.TileSize) - 1; }
        }
        public Enemy(int rowIndex, int colIndex) : base(rowIndex, colIndex)
        {
            Color = SplashKit.ColorLavender();
        }
        public void Move()
        {
            X += SPEED;
            Y += SPEED;
        }
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, SIZE, SIZE);
        }
    }
}
