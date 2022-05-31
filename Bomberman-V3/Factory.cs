using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Bomberman_V3
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
        public void InstantiatePlayer(string id)
        {
            
        }
        public void InstantiateTile(int rowIndex, int colIndex, FloorTile type)
        {
            float x = Conversion.Instance().GetCoordByIndex(rowIndex);
            float y = Conversion.Instance().GetCoordByIndex(colIndex);
            switch (type)
            {
                case FloorTile.GRASS:
                    new Tile(x,y, SplashKit.ColorMediumSpringGreen());
                    break;
                case FloorTile.BREAKABLEBLOCK:
                    new BreakableTile(x,y);
                    break;
                case FloorTile.UNBREAKABLEBLOCK:
                    new UnbreakableTile(x,y);
                    break;
                default:
                    break;
            }
        }
        public void InstantiateBomb(Player thePlayer)
        {
            if (thePlayer.HasBomb)
            {
                float x = Conversion.Instance().GetTileMiddleCoordByPlayerCoord(thePlayer.X);
                float y = Conversion.Instance().GetTileMiddleCoordByPlayerCoord(thePlayer.Y);
                new Bomb(x, y, thePlayer);
            }
        }
        public void InstantiateExplosion(int rowIndex, int colIndex)
        {
            float x = Conversion.Instance().GetCoordByIndex(rowIndex);
            float y = Conversion.Instance().GetCoordByIndex(colIndex);
            new Explosion(x, y);
        }
        public void InstantiateItem(int rowIndex, int colIndex)
        {
            float x = Conversion.Instance().GetCoordByIndex(rowIndex);
            float y = Conversion.Instance().GetCoordByIndex(colIndex);
            Random rnd = new Random();
            double r = rnd.NextDouble();
            if (r < ITEM_CHANCE)
            {
                new BombCounter(x, y);
            }
            else if (1 > r && r > 1 - ITEM_CHANCE * 0.3)
            {
                new BombRadius(x, y);
            }
        }
/*        public void InstantiateEnemies(Floor floor, int noOfEnemies)
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
            }*/
        
    }
}
