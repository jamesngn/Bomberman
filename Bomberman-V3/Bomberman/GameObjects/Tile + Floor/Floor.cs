using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// create the floor for tile map.
    /// </summary>
    public class Floor
    {
        private static int rowN;
        private static int colN;
        private double BREAKABLE_TILE_CHANCE;
        /// <summary>
        /// this is just a draft before instantiating Tile for each element in 2D array
        /// </summary>
        private FloorTile[,] draft;
        private Tile[,] map;
        public Floor(Window w, GameMode gameMode)
        {
            rowN = w.Width / (int)Tile.SIZE;
            colN = w.Height / (int)Tile.SIZE;
            draft = new FloorTile[rowN, colN];
            map = new Tile[rowN, colN];
            if (gameMode == GameMode.ONEPLAYERVSBOT)
            {
                BREAKABLE_TILE_CHANCE = 0.4;
            }
            else if (gameMode == GameMode.TWOPLAYERSVSBOT)
            {
                BREAKABLE_TILE_CHANCE = 0.2;
            }
            else if (gameMode == GameMode.PVP)
            {
                BREAKABLE_TILE_CHANCE = 0.5;
            }
            InstantiateMap();
        }
        public static int RowTotal { get { return rowN; } }
        public static int ColTotal { get { return colN; } }
        public Tile[,] Map { get { return map; } }
        private void InstantiateMap()
        {
            AddBreakable();
            AddUnBreakableAndGrass();
            ClearUpForSpawn();
            InstantiateTilesFromFloorTile();
        }
        /// <summary>
        /// add breakable tile
        /// </summary>
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
                        draft[i, j] = FloorTile.BREAKABLEBLOCK;
                    }
                }
            }
        }
        /// <summary>
        /// add unbreakable and grass tile
        /// </summary>
        private void AddUnBreakableAndGrass()
        {
            for (int i = 0; i < rowN; i++)
            {
                for (int j = 0; j < colN; j++)
                {
                    if (i == 0 || j == 0 || i == rowN - 1 || j == colN - 1 || i % 2 == 0 && j % 3 == 0)
                    {
                        draft[i, j] = FloorTile.UNBREAKABLEBLOCK;
                    }
                    else if (draft[i, j] != FloorTile.BREAKABLEBLOCK)
                    {
                        draft[i, j] = FloorTile.GRASS;
                    }
                }
            }
        }
        /// <summary>
        /// after tiles are added, then clear up for spawn by changing into FloorTile.GRASS
        /// </summary>
        private void ClearUpForSpawn()
        {
            draft[1,1] = FloorTile.GRASS;
            draft[1,2] = FloorTile.GRASS;
            draft[2,1] = FloorTile.GRASS;
            draft[rowN-3, colN-3] = FloorTile.GRASS;
            draft[rowN-3, colN-2] = FloorTile.GRASS;
            draft[rowN-2, colN-3] = FloorTile.GRASS;
        }
        private void InstantiateTilesFromFloorTile()
        {
            int rowN = draft.GetLength(0);
            int colN = draft.GetLength(1);
            for (int i = 0; i < rowN; i++)
            {
                for (int j = 0; j < colN; j++)
                {
                    Tile newTile = Factory.Instance().InstantiateTile(i, j, draft[i, j]);
                    map[i,j] = newTile;
                }
            }
        }
    }
}
