using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisistorPatternTest
{
    class CollisionManager //Use Singleton Pattern
    {
        private static CollisionManager _instance;
        private Player player;
        private CollisionManager(Player p)
        {
            player = p;
        }
        public static CollisionManager Instance(Player p)
        {
            if (_instance == null)
                _instance = new CollisionManager(p);
            return _instance; 
        }
        public void Operate()
        {
            ICollideable tiles = new Tile();
            player.resolveCollision(tiles);
        }
    }
}
