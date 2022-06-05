using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// inherit from GameObject
    /// implement IRemovable to remove the object when finishing the explosion (finish count down method)
    /// this explosion is created during the explosion handler class
    /// </summary>
    public class Explosion : GameObject, IRemovable
    {
        private const int DURATION = 20;
        private int timeToFinish;
        private float size;
        private bool finished;
        public bool IsRemoved { get { return finished; }}
        public Explosion(float x, float y)
        {
            size = Tile.SIZE;
            Shape = new Rectangle(x, y,SplashKit.ColorGray(), size, size);
            timeToFinish = DURATION;
            finished = false;
        }
        public void CountDown()
        {
            timeToFinish--;
            if (timeToFinish == 0)
            {
                finished = true;
            }
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
    }
}
