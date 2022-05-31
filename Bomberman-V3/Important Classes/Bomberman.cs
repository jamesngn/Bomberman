using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    class Bomberman 
    {
        private Window window;
        public Bomberman(Window w)
        {
            window = w;
        }
        public void Initialise()
        {
            new Player("p1");
            new Player("p2");
            new Floor(window);
        }
        public void Draw()
        {
            List<GameObject> gameObjects = SingleSource.Instance().GameObjectsList;
            DrawManager.Instance().Execute(gameObjects);
        }
        public void Update()
        {
            List<GameObject> gameObjects = SingleSource.Instance().GameObjectsList;
            CollisionManager.Instance().HandleCollisions(gameObjects);
            //---
            List<Bomb> bombs = SingleSource.Instance().BombsList;
            List<Explosion> explosions = SingleSource.Instance().ExplosionsList;
            ExplosionManager.Instance().Execute(bombs, explosions);
            //--
            SingleSource.Instance().RefreshObjectList();
        }
        public void Control()
        {
            CommandProcessor.Instance().Execute();
        }
    }
}
