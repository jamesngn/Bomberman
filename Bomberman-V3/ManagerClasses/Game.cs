using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    class Game : IObserver
    {
        private List<GameObject> gameobjects = new List<GameObject>();
        private List<Bomb> bombs = new List<Bomb>();
        private List<Explosion> explosions = new List<Explosion>();
        private List<GameObject> removedObjects = new List<GameObject>();
        private List<Player> players = new List<Player>();
        /*private List<Enemy> enemies = new List<Enemy>();*/
        private static Game _instance;
        public static Game Instance()
        {
            if (_instance == null)
                _instance = new Game();
            return _instance;
        }
        public void AddNewObject(GameObject newGO)
        {
            if (newGO != null)
            {
                gameobjects.Add(newGO);
                if (newGO is Bomb) { bombs.Add((Bomb)newGO); }
                if (newGO is Explosion) { explosions.Add((Explosion)newGO); }
                if (newGO is Player) { players.Add((Player)newGO); }
                /*if (newGO is Enemy) { enemies.Add((Enemy)newGO); }*/
            }
        }
        public void AddRemovedObject(GameObject removedGO)
        {
            removedObjects.Add(removedGO);
        }
        private void RemoveObject(GameObject removedGO)
        {
            if (removedGO != null)
            {
                gameobjects.Remove(removedGO);
                if (removedGO is Bomb) { bombs.Remove((Bomb)removedGO); }
                if (removedGO is Explosion) { explosions.Remove((Explosion)removedGO); }
               /* if (removedGO is Enemy) { enemies.Remove((Enemy)removedGO); }*/
            }
        }
        public void RemoveTile(int row, int col)
        {
            Tile removedTile = null;
            foreach (GameObject gameObject in gameobjects)
            {
                if (gameObject is Tile)
                {
                    removedTile = (Tile)gameObject;
                    if (removedTile.RowIndex == row && removedTile.ColIndex == col)
                    {
                        break;
                    }
                }
            }
            RemoveObject(removedTile);
        }
        private void RemoveObjectList()
        {
            foreach (GameObject removedObject in removedObjects)
            {
                RemoveObject(removedObject);
            }
            removedObjects.Clear();
        }
        public void UpdateFromSubject(IObservable subject)
        {
            if (subject is Bomb)
            {
                AddRemovedObject((Bomb)subject);
                Console.WriteLine("Remove exploded bomb!");
            }
            else if (subject is Explosion)
            {
                AddRemovedObject((Explosion)subject);
                Console.WriteLine("Remove explosion!");
            }
        }
        public void Initialise(Window w)
        {
            new Player("p1");
            new Floor(w);
        }
        public void Draw()
        {
            DrawManager.Instance().Execute(gameobjects, players);
        }
        public void Update()
        {
            CollisionManager.Instance().HandleCollisions(gameobjects);
            /* ExplosionManager.Instance().Execute(bombs, explosions);*/
            CountDown.Instance().BombCountDown(bombs);
            CountDown.Instance().ExplosionCountDown(explosions);
            RemoveObjectList();
        }
        public void Control()
        {
            CommandProcessor.Instance().Execute();
        }
    }
}
