using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Bomberman_V2
{
    class Factory
    {
        private const double ITEM_CHANCE = 0.5;
        private static Factory instance;
        public Factory() { }
        public static Factory Instance()
        {
            if (instance == null)
                instance = new Factory();
            return instance;
        }
        public void InstantiateGrassTile(int rowIndex, int colIndex)
        {
            new Tile(rowIndex, colIndex, SplashKit.ColorMediumSpringGreen());
        }
        public void InstantiateBreakableTile(int rowIndex, int colIndex)
        {
            new BreakableTile(rowIndex, colIndex);
        }
        public void InstantiateUnbreakableTile(int rowIndex, int colIndex)
        {
            new UnbreakableTile(rowIndex, colIndex);
        }
        public void InstantiateBomb(Player thePlayer)
        {
            new Bomb(thePlayer.RowIndex, thePlayer.ColIndex, thePlayer.BombRadius, SplashKit.ColorMediumPurple());
        }
        public void InstantiateExplosion(int rowIndex, int colIndex)
        {
            new Explosion(rowIndex, colIndex);
        }
        public void InstantiateItem(int rowIndex, int colIndex)
        {
            Random rnd = new Random();
            double r = rnd.NextDouble();
            if (r < ITEM_CHANCE)
            {
                new BombCounter(rowIndex, colIndex);
            }
            else if (1 > r && r > 1 - ITEM_CHANCE * 0.3)
            {
                new BombRadius(rowIndex, colIndex);
            }
        }
        public void InstantiateEnemies(Floor floor, int noOfEnemies)
        {
            FloorTile[,] floorTile = floor.GetFloorTile;
            int rowLength = floor.RowLength;
            int colLength = floor.ColLength;
            for (int e = 0; e < noOfEnemies; e++)
            {
                while (true)
                {
                    Random rnd = new Random();
                    double randomNumb = rnd.NextDouble();
                    int randRowId = 1 + (int)(randomNumb * (rowLength - 2));
                    randomNumb = rnd.NextDouble();
                    int randColId = 1 + (int)(randomNumb * (colLength - 2));
                    if (floorTile[randRowId, randColId] != FloorTile.GRASS) { continue; }
                    new Enemy(randRowId, randColId);
                    break;
                }
            }
        }

    }
}
