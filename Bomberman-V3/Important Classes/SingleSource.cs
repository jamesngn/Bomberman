using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    public class SingleSource
    {
        private List<GameObject> gameobjects = new List<GameObject>();
        private List<GameObject> toRemove = new List<GameObject>();
        /*private List<Enemy> enemies = new List<Enemy>();*/
        private static SingleSource _instance;
        public static SingleSource Instance() 
        {
            if (_instance == null)
                _instance = new SingleSource();
            return _instance;
        }
        public void Add(GameObject newGO)
        {
            gameobjects.Add(newGO);
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
        public void AddToRemove(GameObject removedGO)
        {
            if (removedGO != null) 
                toRemove.Add(removedGO);
        }
        public void RemoveTileByIndices(int row, int col)
        {
            Tile removedTile = null;
            foreach (Tile t in TilesList)
            {
                if (t.RowIndex == row && t.ColIndex == col)
                {
                    removedTile = t;
                    break;
                }
            }

            AddToRemove(removedTile);
        }
        public void RefreshObjectList()
        {
            RemoveFinishedCountDown();
            RemovePickedItem();
            ClearUpRemovedList();
        }
        private void RemoveFinishedCountDown()
        {
            foreach(GameObject g in gameobjects)
            {
                bool isGCountDownable = g as IDownCountable != null;
                if (isGCountDownable)
                {
                    IDownCountable CD = g as IDownCountable;
                    if (CD.Finished)
                        AddToRemove(CD as GameObject);
                }
            }
        }
        private void RemovePickedItem()
        {
            foreach(IPickable i in ItemsList)
            {
                if (i.IsPicked)
                    AddToRemove(i as GameObject);
            }
        }
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
