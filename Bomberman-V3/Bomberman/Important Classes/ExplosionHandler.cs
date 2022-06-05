using System;

namespace Bomberman_V3
{
    class ExplosionHandler
    {
        /// <summary>
        ///  check north, south, east and west for explosion to occur
        /// </summary>
        /// <param name="map"> give knowledge about surrounding tiles for explosion to occur </param>
        /// <param name="explodedBomb"> the bomb by the player, passed here to know the location of explosion on the map accurately </param>
        public void Execute(Tile[,] map, Bomb explodedBomb)
        {
            int eRow = Conversion.Instance().GetIndexByCoord(explodedBomb.X);
            int eCol = Conversion.Instance().GetIndexByCoord(explodedBomb.Y);
            Factory.Instance().InstantiateExplosion(eRow, eCol);
            //extend the bomb explosion based on the radius
            bool northOpen = true;
            bool southOpen = true;
            bool westOpen = true;
            bool eastOpen = true;
            for (int i = 1; i <= explodedBomb.BombRadius; i++)
            {
                if (eRow - i >= 0 && northOpen)
                    northOpen = IsExplosableAt(map, eRow - i, eCol, northOpen); //check north
                if (eRow - i <= map.GetLength(0) && southOpen)
                    southOpen = IsExplosableAt(map, eRow + i, eCol, southOpen); //check south
                if (eCol - i >= 0 && westOpen)
                    westOpen = IsExplosableAt(map, eRow, eCol - i, westOpen);  //check west
                if (eCol + i <= map.GetLength(1) && eastOpen)
                    eastOpen = IsExplosableAt(map, eRow, eCol + i, eastOpen);  //check east
            }
        }
        /// <summary>
        /// This class checks for continue explosion or not 
        /// also Instantiate Tile, Instantiate Item, Instantiate Explosion
        /// </summary>
        /// <param name="map"> give knowledge about surrounding tiles for explosion to occur </param>
        /// <param name="explosionRow"> row in the map for checking explosion </param>
        /// <param name="explosionCol"> column in the map for checking explosion </param>
        /// <param name="continueExplosion"> variable to check whether the explosion continues in that way </param>
        /// <returns></returns>
        private bool IsExplosableAt(Tile[,] map, int explosionRow, int explosionCol, bool continueExplosion)
        {
            if (map[explosionRow, explosionCol] is BreakableTile || map[explosionRow, explosionCol] is UnbreakableTile) { continueExplosion = false; }
            if (map[explosionRow, explosionCol] is BreakableTile)
            {
                map[explosionRow, explosionCol] = Factory.Instance().InstantiateTile(explosionRow, explosionCol, FloorTile.GRASS);
                Factory.Instance().InstantiateItem(explosionRow,explosionCol);
            }
            if (map[explosionRow, explosionCol] is not UnbreakableTile)
            {
                Factory.Instance().InstantiateExplosion(explosionRow, explosionCol);
            }
            return continueExplosion;
        }
    }
}