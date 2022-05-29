using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    class Explosion : GameObject
    {
        private double SIZE = Tile.TileSize;
        private int duration = 35;
        public Explosion(int rowIndex, int colIndex) : base(rowIndex, colIndex) { }
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public override double Size => SIZE;
        public override void Draw()
        {
            SplashKit.FillRectangle(SplashKit.ColorGray(), X, Y, SIZE, SIZE);
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                player.Respawn();
                Console.WriteLine("Explosion collides with Player");
            }
        }
        public override void ResolveCollision(Bomb bomb)
        {
            if (IsCollidingWith(bomb))
            {
                bomb.TimeToExplosion = 0;
                Console.WriteLine("Explosion collides with Bomb");
            }

        }
/*        private bool IsCollidingWith(GameObject gameObject) //future plan: replace with movable object (for enemy)
        {
            int objectX = 0, objectY = 0;
            double objectSize = 0;
            if (gameObject is Player)
            {
                Player p = (Player)gameObject;
                objectX = p.X;
                objectY = p.Y;
                objectSize = p.Size;
            } 
            else if (gameObject is Bomb)
            {
                Bomb b = (Bomb)gameObject;
                objectX = b.RowIndex * Tile.Size;
                objectY = b.ColIndex * Tile.Size;
                objectSize = b.Size;
            }
        }*/
    }
}
