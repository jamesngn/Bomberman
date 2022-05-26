using System;
using System.Collections.Generic;

public interface IObserver
{
    public void UpdateFromSubject(IEntity entity);
}
public class CollisionManager : IObserver
{
    public void UpdateFromSubject(IEntity entity)
    {
        bool isEntityPlayer = (entity as Player) != null; //if entity is not player --> null; leading null != null is FALSE
        if (isEntityPlayer)
        {
            Console.WriteLine("The Player is sending a messing to Obsever");
        }
    }
}
public interface IEntity
{
    void PhysicsUpdate();
}
public interface IObservable ///ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObserver(IEntity entity);
}
public class Player : IEntity, IObservable
{
    private List<IObserver> observers = new List<IObserver>();
    public Player(IObserver observer)
    {
        AddObserver(observer);
    }
    public void PhysicsUpdate()
    {
        NotifyObserver(this);
    }
    public void AddObserver(IObserver observer)
    {
        observers.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
    public void NotifyObserver(IEntity entity)
    {
        foreach (IObserver observer in observers)
        {
            observer.UpdateFromSubject(entity);
        }
    }
}

namespace ObserverPatternTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IObserver cm = new CollisionManager();
            IEntity player = new Player(cm);

            player.PhysicsUpdate();
        }
    }
}
