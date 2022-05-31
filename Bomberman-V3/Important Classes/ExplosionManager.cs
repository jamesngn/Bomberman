using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    public class ExplosionManager
    {
        private static ExplosionManager _instance;
        public static ExplosionManager Instance()
        {
            if (_instance == null)
                _instance = new ExplosionManager();
            return _instance;
        }
        public ExplosionManager() { }
        public void Execute(List<Bomb> bombs, List<Explosion> explosions)
        {
            CountDownBomb(bombs);
            HandleExplosion(bombs);
            CountExplosionDown(explosions);
        }
        private void CountDownBomb(List<Bomb> bombs)
        {
            bombs.ForEach(x => x.CountDown());
        }
        private void HandleExplosion(List<Bomb> bombs)
        {
            foreach (Bomb b in bombs)
            {
                if (b.Finished)
                {
                    ExplosionHandler.Instance().Execute(b);
                }
            }
        }
        private void CountExplosionDown(List<Explosion> explosions)
        {
            explosions.ForEach(x => x.CountDown());
        }
    }
}
