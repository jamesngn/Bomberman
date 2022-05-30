using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public class Explosion : GameObject, IObservable
    {
        private List<IObserver> observers = new List<IObserver>();
        private float size = Tile.SIZE;
        private int duration = 35;
        public int Duration 
        {
            get { return duration; } 
            set 
            {
                duration = value; 
                if (duration == 0)
                {
                    NotifyObserver(this);
                }
            }
        }
        public Explosion(float x, float y)
        {
            Shape = new Rectangle(x, y,SplashKit.ColorGray(), size, size);
            AddObserver(Game.Instance());
        }
        public void CountDown()
        {
            Duration--;
        }
        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }
        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }
        public void NotifyObserver(IObservable subject)
        {
            foreach (IObserver observer in observers)
            {
                observer.UpdateFromSubject(subject);
            }
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
