using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public class Explosion : GameObject, IDownCountable
    {
        private const int DURATION = 35;
        private int timeToFinish = DURATION;
        private float size;
        private bool finished;
        public int TimeToFinish 
        {
            get { return timeToFinish; } 
            set 
            {
                timeToFinish = value; 
                if (timeToFinish == 0)
                {
                    finished = true;
                }
            }
        }
        public bool Finished { get { return finished; }}
        public Explosion(float x, float y)
        {
            size = Tile.SIZE;
            Shape = new Rectangle(x, y,SplashKit.ColorGray(), size, size);
            finished = false;
        }
        public void CountDown()
        {
            TimeToFinish--;
        }
        public override void ResolveCollision(ICollidable collidable)
        {
            collidable.ResolveCollision(this);
        }
        public override void ResolveCollision(Player player)
        {
            if (IsCollidingWith(player))
            {
                player.Respawn();
            }
        }
    }
}
