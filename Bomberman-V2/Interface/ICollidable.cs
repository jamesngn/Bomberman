using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V2
{
    public interface ICollidable
    {
        public void ResolveCollision(ICollidable collidable);
        public void ResolveCollision(Player player);
        public void ResolveCollision(Bomb bomb);
        public void ResolveCollision(Enemy enemy);
    }
}
