using System;
using System.Collections.Generic;

namespace VisistorPatternTest
{
    public interface ICollideable //Visitor
    {
        public void resolveCollision(Tile tile);
        //public void resolveCollision(Boomb boom);
        //public void resolveCollision(Explosion explosion);
        //public void resolveCollision(UltrasonicWave ultrasonicWave);
        public void resolveCollision(Player player);
    }
    public abstract class GameObject : ICollideable
    {
        public abstract void resolveCollision(ICollideable collideable); //accept
        public virtual void resolveCollision(Tile tile) { } 
        //public virtual void resolveCollision(Boomb boom) { }
        //public virtual void resolveCollision(Explosion explosion) { }
        //public virtual void resolveCollision(UltrasonicWave ultrasonicWave) { }
        public virtual void resolveCollision(Player player) { }

    }
    public class Player : GameObject
    {
        public override void resolveCollision(ICollideable collideable)
        {
            collideable.resolveCollision(this);
        }
        public override void resolveCollision(Tile tile)
        {
            Console.WriteLine("Player is colliding with Tile");
        }
        public override void resolveCollision(Player player)
        {
            Console.WriteLine("Player is colliding with Player");
        }
    }
    public class Tile : GameObject
    {
        public override void resolveCollision(ICollideable collideable)
        {
            collideable.resolveCollision(this);
        }
        public override void resolveCollision(Player player)
        {
            Console.WriteLine("Player moves back ");
        }
    }
    class Program   
    {
        static void Main(string[] args)
        {
            //visitor : For the Player class, the visitors are kind of other objects like Tiles, ...
            //accept : ~ resolveCollision(ICollideable collidable). If Player class accept visitor as Tile, the method in the Tile | resolveCollision(Player player) | will be executed.

            Player player = new Player();
            CollisionManager.Instance(player).Operate();
        }
    }
}
