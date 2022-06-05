using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    class EnemyMovementHandler
    {
        public EnemyMovementHandler() { }
        /// <summary>
        /// make enemies move in a certain direction and randomise the enemies' direction
        /// </summary>
        /// <param name="enemies"></param>
        public void Execute(List<Enemy> enemies)
        {
            foreach(Enemy e in enemies)
            {
                e.RandomiseDirection();
                e.Move();
            }
        }
    }
}
