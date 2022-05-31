using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    class DrawManager
    {
        private static DrawManager instance;
        public static DrawManager Instance()
        {
            if (instance == null)
                instance = new DrawManager();
            return instance;
        }
        public void Execute(List<GameObject> gameObjects)
        {
            DrawAllObjects(gameObjects);
        }
        private void DrawAllObjects(List<GameObject> gameObjects)
        {
            List<Player> playerToDraw = new List<Player>();
            foreach (GameObject d in gameObjects)
            {
                if (!(d is Player))
                {
                    d.Shape.Draw();
                }
                else
                {
                    playerToDraw.Add(d as Player);
                }
            }
            DrawPlayers(playerToDraw);
        }
        private void DrawPlayers(List<Player> players)
        {
            foreach (Player p in players)
            {
                p.Shape.Draw();
            }
        }
    }
}
