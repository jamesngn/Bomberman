using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// inherits from GameObject
    /// This is Grass Tile, therefore, there is no collsion checker here
    /// </summary>
    public class Tile : GameObject
    {
        public static float SIZE = 50;
        public Tile(float x, float y, Color color)
        {
            Shape = new Rectangle(x, y, color, SIZE, SIZE);
        }
        public override void ResolveCollision(ICollidable collidable) { }
    }
}
