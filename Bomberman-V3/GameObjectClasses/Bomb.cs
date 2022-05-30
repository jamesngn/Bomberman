using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace Bomberman_V3
{
    class Bomb : GameObject, IObservable
    {
        private List<IObserver> observers = new List<IObserver>();
        private const int TIME = 100;
        private float timeToExplosion = TIME;
        private bool isPlayerLeft = false;
        private float BombSize = (float) 0.44 * Tile.SIZE;
        private float bombRadius = 2;
        public float TimeToExplosion 
        {
            get { return timeToExplosion; } 
            set 
            {
                timeToExplosion = value;
                if (timeToExplosion == 0)
                {
                    NotifyObserver(this);
                }
            } 
        }
        public float BombRadius { get { return bombRadius; } }
        public Bomb(float x, float y)
        {
            Shape = new Circle(BombSize, x, y, SplashKit.ColorMediumPurple());
            AddObserver(Game.Instance());
            AddObserver(ExplosionManager.Instance());
        }
        public void CountDown()
        {
            TimeToExplosion--;
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
        public override void ResolveCollision(Explosion explosion)
        {
            if (IsCollidingWith(explosion))
            {
                timeToExplosion = 1;
            }
        }
        public override void ResolveCollision(Player player)
        {
            if (IsLeftAndCollidingWith(player))
            {
                player.GoLastPosition();
                Console.WriteLine("Reached");
            }
        }
        private bool IsLeftAndCollidingWith(Player player)
        {
            if (!isPlayerLeft) { isPlayerLeft = IsLeftBy(player); }
            if (isPlayerLeft)
            {
                if (IsCollidingWith(player))
                {
                    return true;
                }
            }
            return false;
        }
        private bool IsLeftBy(Player player)
        {
            double rangeX1 = X - Tile.SIZE / 2;
            double rangeX2 = X + Tile.SIZE / 2;
            double rangeY1 = Y - Tile.SIZE / 2;
            double rangeY2 = Y + Tile.SIZE / 2;
            if (rangeX1 - player.Size < player.X && player.X < rangeX2 && rangeY1 - player.Size < player.Y && player.Y < rangeY2)
            {
                Console.WriteLine("The player has not left!");
                return false;
            }
            else
            {
                Console.WriteLine("The player has left!");
                return true;
            }
        }
    }
}
