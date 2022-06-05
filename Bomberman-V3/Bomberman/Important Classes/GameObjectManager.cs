using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    /// <summary>
    /// This class acts as a single source for the game
    /// Responsible for adding and removing game objects
    /// </summary>
    public class GameObjectManager
    {
        private List<GameObject> gameobjects = new List<GameObject>();
        private List<GameObject> toRemove = new List<GameObject>();
        private static GameObjectManager _instance;
        /// <summary>
        /// Singleton design pattern because it helps to add game objects easily when it is constructed.
        /// </summary>
        /// <returns></returns>
        public static GameObjectManager Instance() 
        {
            if (_instance == null)
                _instance = new GameObjectManager();
            return _instance;
        }
        public List<GameObject> GameObjectsList { get { return gameobjects; } }
        public List<Bomb> BombsList
        {
            get
            {
                List<Bomb> result = new List<Bomb>();
                foreach(GameObject g in gameobjects)
                {
                    if (g is Bomb)
                        result.Add(g as Bomb);
                }
                return result;
            }
        }
        public List<Explosion> ExplosionsList
        {
            get
            {
                List<Explosion> result = new List<Explosion>();
                foreach (GameObject g in gameobjects)
                {
                    if (g is Explosion)
                        result.Add(g as Explosion);
                }
                return result;
            }
        }
        public List<Player> PlayersList
        {
            get
            {
                List<Player> result = new List<Player>();
                foreach (GameObject g in gameobjects)
                {
                    if (g is Player)
                        result.Add(g as Player);
                }
                return result;
            }
        }
        public List<Item> ItemsList
        {
            get
            {
                List<Item> result = new List<Item>();
                foreach (GameObject g in gameobjects)
                {
                    if (g is Item)
                        result.Add(g as Item);
                }
                return result;
            }
        }
        public List<Tile> TilesList
        {
            get
            {
                List<Tile> result = new List<Tile>();
                foreach (GameObject g in gameobjects)
                {
                    if (g is Tile)
                        result.Add(g as Tile);
                }
                return result;
            }
        }
        public List<Enemy> EnemiesList
        {
            get
            {
                List<Enemy> result = new List<Enemy>();
                foreach (GameObject g in gameobjects)
                {
                    if (g is Enemy)
                        result.Add(g as Enemy);
                }
                return result;
            }
        }
        /// <summary>
        /// Add new game object to the list
        /// </summary>
        /// <param name="newGO"></param>
        public void Add(GameObject newGO)
        {
            gameobjects.Add(newGO);
        }
        /// <summary>
        /// this method is used to remove the removable object
        /// </summary>
        public void RefreshObjectList()
        {
            RemoveRemovableObject();
            ClearUpRemovedList();
        }
        /// <summary>
        /// removable object includes: bomb, explosion, item and enemy
        /// </summary>
        private void RemoveRemovableObject()
        {
            foreach (GameObject g in gameobjects)
            {
                bool isObjectRemovable = g as IRemovable != null;
                if (isObjectRemovable)
                {
                    IRemovable removedObject = g as IRemovable;
                    if (removedObject.IsRemoved)
                    {
                        AddToRemove(removedObject as GameObject);
                    }
                }
            }
        }
        /// <summary>
        /// add game object to remove
        /// </summary>
        /// <param name="removedGO"></param>
        private void AddToRemove(GameObject removedGO)
        {
            if (removedGO != null)
                toRemove.Add(removedGO);
        }
        /// <summary>
        /// clear the list ToRemove
        /// </summary>
        private void ClearUpRemovedList()
        {
            if (toRemove.Count > 0)
            {
                foreach (GameObject r in toRemove)
                {
                    gameobjects.Remove(r);
                }
                toRemove.Clear();
            }
        }

    }
}
