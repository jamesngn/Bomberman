using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    public abstract class Item : GameObject
    {
        private const double SIZE = 30;
        public Item(int RowIndex, int ColIndex, Color color) : base(RowIndex, ColIndex)
        {
            this.Color = color;
        }
        public override int X { get { return RowIndex* (int) Tile.TileSize + 5; } }
        public override int Y { get { return ColIndex * (int) Tile.TileSize + 5; } }
        public override double Size => SIZE;
        public abstract void AddToPlayer(Player player);
        public override void Draw()
        {
            SplashKit.FillRectangle(Color, X, Y, SIZE, SIZE);
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                AddToPlayer(player);
                Game.Instance().AddRemovedObject(this);//ask about this!!!
            }
        }
    }
}
