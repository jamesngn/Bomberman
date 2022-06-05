using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    class CollisionManager
    {
        public CollisionManager() { }
        /// <summary>
        /// the collision manager applies the visitor pattern. 
        /// </summary>
        /// <param name="colliders"></param>
        public void Execute(List<GameObject> colliders)
        {
            foreach (ICollidable collidedObject in colliders)
            {
                List<GameObject> collidings = colliders.Where(x => x != collidedObject).ToList();
                foreach (ICollidable colliding in collidings)
                {
                    collidedObject.ResolveCollision(colliding);
                }
            }
        }
    }
}
