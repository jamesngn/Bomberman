using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    class CountDown
    {
        private static CountDown _instance;
        public static CountDown Instance()
        {
            if (_instance == null)
                _instance = new CountDown();
            return _instance;
        }
        public void BombCountDown(List<Bomb> bombs)
        {
            foreach(Bomb b in bombs)
            {
                b.CountDown();
            }
        }
        public void ExplosionCountDown(List<Explosion> explosions)
        {
            foreach (Explosion e in explosions)
            {
                e.CountDown();
            }
        }
    }
}
