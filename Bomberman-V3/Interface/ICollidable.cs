using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    public interface ICollidable
    {
        public void ResolveCollision(ICollidable collidable);
        public void ResolveCollision(BreakableTile tile);
        public void ResolveCollision(UnbreakableTile tile);
        public void ResolveCollision(Player player);
        public void ResolveCollision(Explosion explosion);
    }
}
