using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    class Conversion
    {
        private static Conversion _instance;
        public static Conversion Instance()
        {
            if (_instance == null)
                _instance = new Conversion();
            return _instance;
        }
        public float GetTileMiddleCoordByPlayerCoord(float coord)
        {
            return GetTileCornerCoordByPlayerCoord(coord) + Tile.SIZE / 2;
        }
        public float GetTileCornerCoordByPlayerCoord(float coord)
        {
            return ConvertCoordIntoIndex(coord+1) * Tile.SIZE;
        }
        public int GetIndexByCoord(float coord)
        {
            return ConvertCoordIntoIndex(coord);
        }
        public float GetCoordByIndex(int index)
        {
            return ConvertIndexIntoCoord(index);
        }
        private int ConvertCoordIntoIndex(float coord)
        {
            int index = (int) ((coord + Tile.SIZE - 1) / Tile.SIZE) - 1;
            return index;
        }
        private float ConvertIndexIntoCoord(int index)
        {
            float coord = index * Tile.SIZE;
            return coord;
        }
    }
}
