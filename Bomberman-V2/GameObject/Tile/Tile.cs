using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    public class Tile : GameObject
    {
        private const double SIZE = 50;
        public static double TileSize => SIZE;
        public override double Size => SIZE;
        public Tile(int RowIndex, int ColIndex, Color color) : base(RowIndex, ColIndex)
        {
            Color = color;
        }
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, SIZE, SIZE);
        }
    }
}
