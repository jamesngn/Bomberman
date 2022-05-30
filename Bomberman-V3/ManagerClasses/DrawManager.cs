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
        public void Execute(List<GameObject> drawableObjects, List<Player> players)
        {
            DrawGameBlocks(drawableObjects);
            DrawPlayers(players);
        }
        private void DrawGameBlocks(List<GameObject> drawableObjects)
        {
            foreach (GameObject d in drawableObjects)
            {
                if (!(d is Player))
                {
                    d.Shape.Draw();
                }
            }
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
