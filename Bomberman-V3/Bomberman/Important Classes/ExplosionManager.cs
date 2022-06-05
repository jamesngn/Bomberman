using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    /// <summary>
    /// This class processes three consecutive events:
    /// count down bomb, check explosion to occur on which blocks and count down explosion
    /// </summary>
    public class ExplosionManager
    {
        private ExplosionHandler explosionHandler;
        /// <summary>
        /// theMap is used to for checking surrounding tiles - to decide for the explosion to occur or not
        /// </summary>
        private Tile[,] theMap;
        public ExplosionManager(Tile[,] newMap) 
        {
            explosionHandler = new ExplosionHandler();
            theMap = newMap;
        }
        public void Execute(List<Bomb> bombs, List<Explosion> explosions)
        {
            CountDownBomb(bombs);
            HandleExplosion(bombs);
            CountDownExplosion(explosions);
        }
        /// <summary>
        /// count down bomb to zero to turn IsRemoved = true
        /// </summary>
        /// <param name="bombs">
        /// each bomb has the CountDown() method
        /// </param>
        private void CountDownBomb(List<Bomb> bombs)
        {
            bombs.ForEach(x => x.CountDown());
        }
        /// <summary>
        /// after bomb is placed, each will be passed to here to check surroundings block to know whether explosion to occur or not
        /// </summary>
        /// <param name="bombs"></param>
        private void HandleExplosion(List<Bomb> bombs)
        {
            foreach (Bomb b in bombs)
            {
                if (b.IsRemoved)
                {
                    explosionHandler.Execute(theMap,b);
                }
            }
        }
        /// <summary>
        /// count down explosion to zero to turn IsRemoved = true
        /// </summary>
        /// <param name="explosions">
        /// explosion has CoutnDown() method
        /// </param>
        private void CountDownExplosion(List<Explosion> explosions)
        {
            explosions.ForEach(x => x.CountDown());
        }
    }
}
