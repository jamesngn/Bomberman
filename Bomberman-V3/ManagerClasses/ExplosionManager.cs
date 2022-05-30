using System;
using System.Collections.Generic;
using SplashKitSDK;

namespace Bomberman_V3
{
    class ExplosionManager : IObserver
    {
        private FloorTile[,] tile;
        private List<Bomb> _explosionCoordinates = new List<Bomb>();
        private static ExplosionManager _instance;
        public static ExplosionManager Instance()
        {
            if (_instance == null)
                _instance = new ExplosionManager();
            return _instance;
        }
        public void AddFloorTile(FloorTile[,] theFloorTile)
        {
            tile = theFloorTile;
        }
        public void Execute(List<Bomb> _bombs)
        {
            /*BombCountDown(_bombs);
            ExplosionCountDown(_explosions);
            ExplosionHandler();*/
        }
        public void UpdateFromSubject(IObservable subject)
        {
            bool isSubjectBomb = (subject as Bomb) != null;
            if (isSubjectBomb)
            {
                Bomb eCoord = subject as Bomb;
                int eRow = Conversion.Instance().GetIndexByCoord(eCoord.X);
                int eCol = Conversion.Instance().GetIndexByCoord(eCoord.Y);
                Factory.Instance().InstantiateExplosion(eRow, eCol);
                //extend the bomb explosion based on the radius
                bool northOpen = true;
                bool southOpen = true;
                bool westOpen = true;
                bool eastOpen = true;
                for (int i = 1; i <= eCoord.BombRadius; i++)
                {
                    if (eRow - i >= 0 && northOpen)
                        northOpen = IsExplosableAt(eRow - i, eCol, northOpen); //check north
                    if (eRow - i <= 10 && southOpen)
                        southOpen = IsExplosableAt(eRow + i, eCol, southOpen); //check south
                    if (eCol - i >= 0 && westOpen)
                        westOpen = IsExplosableAt(eRow, eCol - i, westOpen); //check west
                    if (eCol + i <= 10 && eastOpen)
                        eastOpen = IsExplosableAt(eRow, eCol + i, eastOpen); //check east
                }
            }
        }
/*        private void BombCountDown(List<Bomb> _bombs)
        {
            List<Bomb> _removedBombs = new List<Bomb>();
            foreach (Bomb bomb in _bombs)
            {
                if (bomb is Bomb)
                {
                    if (bomb.TimeToExplosion == 0)
                    {
                        Console.WriteLine("Explosion!!!");
                        Game.Instance().AddRemovedObject(bomb);
                        _explosionCoordinates.Add(bomb);
                    }
                    bomb.TimeToExplosion--;
                }
            }
        }*/
/*        private void ExplosionCountDown(List<Explosion> _explosions)
        {
            List<Explosion> _removedExplosions = new List<Explosion>();
            foreach (Explosion explosion in _explosions)
            {
                explosion.Duration--;
                if (explosion.Duration == 0)
                {
                    Game.Instance().AddRemovedObject(explosion);
                }
            }
        }*/
/*        private void ExplosionHandler()
        {
            List<Bomb> _removedExplosionCoord = new List<Bomb>();
            foreach (Bomb eCoord in _explosionCoordinates)
            {
                int eRow = Conversion.Instance().GetIndexByCoord(eCoord.X);
                int eCol = Conversion.Instance().GetIndexByCoord(eCoord.Y);
                Factory.Instance().InstantiateExplosion(eRow, eCol);
                //extend the bomb explosion based on the radius
                bool northOpen = true;
                bool southOpen = true;
                bool westOpen = true;
                bool eastOpen = true;
                for (int i = 1; i <= eCoord.BombRadius; i++)
                {
                    if (eRow - i >= 0 && northOpen)
                        northOpen = IsExplosableAt(eRow - i, eCol, northOpen); //check north
                    if (eRow - i <= 10 && southOpen)
                        southOpen = IsExplosableAt(eRow + i, eCol, southOpen); //check south
                    if (eCol - i >= 0 && westOpen)
                        westOpen = IsExplosableAt(eRow, eCol - i, westOpen); //check west
                    if (eCol + i <= 10 && eastOpen)
                        eastOpen = IsExplosableAt(eRow, eCol + i, eastOpen); //check east
                }
                _removedExplosionCoord.Add(eCoord);
            }
            foreach (Bomb e in _removedExplosionCoord)
            {
                _explosionCoordinates.Remove(e);
            }
            _removedExplosionCoord.Clear();
        }*/
        private bool IsExplosableAt(int explosionRow, int explosionCol, bool continueExplosion)
        {
            if (tile[explosionRow, explosionCol] != FloorTile.GRASS) { continueExplosion = false; }
            if (tile[explosionRow, explosionCol] == FloorTile.BREAKABLEBLOCK)
            {
                tile[explosionRow, explosionCol] = FloorTile.GRASS;
                //ask about this: (this class is only responsible for handling explosion, not creating new block);
                Game.Instance().RemoveTile(explosionRow, explosionCol);
                Factory.Instance().InstantiateTile(explosionRow, explosionCol, FloorTile.GRASS);
                /*Factory.Instance().InstantiateItem(explosionRow, explosionCol);*/
            }
            if (tile[explosionRow, explosionCol] != FloorTile.UNBREAKABLEBLOCK)
            {
                Factory.Instance().InstantiateExplosion(explosionRow, explosionCol);
            }
            return continueExplosion;
        }
    }
}
