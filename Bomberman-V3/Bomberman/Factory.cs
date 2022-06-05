using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Bomberman_V3
{
    /// <summary>
    /// Factory class is used to instantiate the game objects for the game.
    /// This is based on Singleton design pattern
    /// </summary>
    class Factory
    {
        private static Factory instance;
        public Factory() { }
        public static Factory Instance()
        {
            if (instance == null)
                instance = new Factory();
            return instance;
        }
        public void InstantiatePlayer(string id, GameMode mode)
        {
            new Player(id, mode);
        }
        public Tile InstantiateTile(int rowIndex, int colIndex, FloorTile type)
        {
            float x = Conversion.Instance().GetCoordByIndex(rowIndex);
            float y = Conversion.Instance().GetCoordByIndex(colIndex);
            switch (type)
            {
                case FloorTile.GRASS:
                    return new Tile(x, y, SplashKit.ColorMediumSpringGreen());
                case FloorTile.BREAKABLEBLOCK:
                    return new BreakableTile(x, y);
                case FloorTile.UNBREAKABLEBLOCK:
                    return new UnbreakableTile(x, y);
                default:
                    return null;
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
            const double ITEM_CHANCE = 0.2;
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
        public void InstantiateEnemies(Tile[,] map, int noOfEnemies)
        {
            int rowLength = map.GetLength(0);
            int colLength = map.GetLength(1);
            for (int e = 0; e < noOfEnemies; e++)
            {
                while (true)
                {
                    Random rnd = new Random();
                    double randomNumb = rnd.NextDouble();
                    int randRowId = 1 + (int)(randomNumb * (rowLength - 2));
                    randomNumb = rnd.NextDouble();
                    int randColId = 1 + (int)(randomNumb * (colLength - 2));
                    if (0 < randRowId && randRowId < 4 && 0 < randColId && randColId < 4) { continue; }
                    if (map[randRowId,randColId] is BreakableTile || map[randRowId,randColId] is UnbreakableTile) { continue; }
                    float x = Conversion.Instance().GetCoordByIndex(randRowId) + 10;
                    float y = Conversion.Instance().GetCoordByIndex(randColId) + 10;
                    new Enemy(x, y);
                    break;
                }
            }

        }
    }
}
