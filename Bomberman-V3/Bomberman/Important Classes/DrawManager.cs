using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    class DrawManager
    {
        public DrawManager() { }
        public void Execute(List<GameObject> gameObjects)
        {
            DrawAllObjects(gameObjects);
        }
        /// <summary>
        /// Prioritise to draw IMovable object.
        /// </summary>
        /// <param name="gameObjects"></param>
        private void DrawAllObjects(List<GameObject> gameObjects)
        {
            List<IMovable> movableObjects = new List<IMovable>();
            foreach (GameObject d in gameObjects)
            {
                if (!(d is IMovable))
                {
                    d.Shape.Draw();
                }
                else
                {
                    movableObjects.Add(d as IMovable);
                }
            }
            DrawMovableObjects(movableObjects);
        }
        /// <summary>
        /// draw movable objects
        /// </summary>
        /// <param name="movableObjects"></param>
        private void DrawMovableObjects(List<IMovable> movableObjects)
        {
            foreach (IMovable m in movableObjects)
            {
                GameObject g = m as GameObject;
                g.Shape.Draw();
            }
        }
    }
}
