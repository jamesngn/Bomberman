using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public class Tile : GameObject
    {
        public static float SIZE = 50;
        public Tile(float x, float y, Color color)
        {
            Shape = new Rectangle(x, y, color, SIZE, SIZE);
        }
        public int RowIndex { get { return Conversion.Instance().GetIndexByCoord(X + 1); } }
        public int ColIndex { get { return Conversion.Instance().GetIndexByCoord(Y + 1); } }
    }
}
