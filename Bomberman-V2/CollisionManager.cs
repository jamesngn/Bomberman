using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V2
{
    class CollisionManager
    {
        private static CollisionManager _instance;
        public static CollisionManager Instance()
        {
            if (_instance == null)
                _instance = new CollisionManager();
            return _instance;
        }
        public void HandleCollisions(List<GameObject> colliders)
        {
            foreach (ICollidable collidedObject in colliders)
            {
                if (!(collidedObject is Tile))
                {
                    List<GameObject> collidings = colliders.Where(x => x != collidedObject).ToList();
                    foreach (ICollidable colliding in collidings)
                    {
                        collidedObject.ResolveCollision(colliding);
                        /*Console.WriteLine("Collider Type: {0} - Colliding Type: {1}", collidedObject.GetType().Name, colliding.GetType().Name);*/
                    }
                }
            }
        }
    }
}
