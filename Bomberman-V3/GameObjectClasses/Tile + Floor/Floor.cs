using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    //Responsibility: create the floor for tile map.
    public class Floor
    {
        private const double BREAKABLE_TILE_CHANCE = 0.3;
        private int rowN;
        private int colN;
        private FloorTile[,] floorTile;
        public Floor (Window w)
        {
            rowN = w.Width  / (int) Tile.SIZE;
            colN = w.Height / (int) Tile.SIZE;
            floorTile = new FloorTile[rowN, colN];
            ExplosionManager.Instance().AddFloorTile(floorTile);
            InstantiateMap();
        }
        public FloorTile[,] GetFloorTile { get { return floorTile; } }
        public int RowLength { get { return rowN; } }
        public int ColLength { get { return colN; } }
        private void InstantiateMap()
        {
            AddBreakable();
            AddUnBreakableAndGrass();
            ClearUpForSpawn();
            InstantiateFromFloorTile();
        }
        private void AddBreakable()
        {
            Random rnd = new Random();
            for (int i = 0; i < rowN; i++)
            {
                for (int j = 0; j < colN; j++)
                {
                    double r = rnd.NextDouble();
                    if (r < BREAKABLE_TILE_CHANCE)
                    {
                        floorTile[i, j] = FloorTile.BREAKABLEBLOCK;
                    }
                }
            }
        }
        private void AddUnBreakableAndGrass()
        {
            for (int i = 0; i < rowN; i++)
            {
                for (int j = 0; j < colN; j++)
                {
                    if (i == 0 || j == 0 || i == rowN - 1 || j == colN - 1 || i % 2 == 0 && j % 3 == 0)
                    {
                        floorTile[i, j] = FloorTile.UNBREAKABLEBLOCK;
                    }
                    else if (floorTile[i, j] != FloorTile.BREAKABLEBLOCK)
                    {
                        floorTile[i, j] = FloorTile.GRASS;
                    }
                }
            }
        }
        private void ClearUpForSpawn()
        {
            floorTile[Player.ROW_START, Player.COL_START] = FloorTile.GRASS;
            floorTile[Player.ROW_START, Player.COL_START + 1] = FloorTile.GRASS;
            floorTile[Player.ROW_START + 1, Player.COL_START] = FloorTile.GRASS;
        }
        private void InstantiateFromFloorTile()
        {
            int rowN = floorTile.GetLength(0);
            int colN = floorTile.GetLength(1);
            for (int i = 0; i < rowN; i++)
            {
                for (int j = 0; j < colN; j++)
                {
                    Factory.Instance().InstantiateTile(i, j, floorTile[i, j]);
                }
            }
        }
    }
}
