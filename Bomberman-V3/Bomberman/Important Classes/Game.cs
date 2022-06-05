using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    class Game
    {
        /// <summary>
        /// Implement IGameManager interface to give this code reusability for other games
        /// </summary>
        private IGameManager game;
        public Game()
        {
            GameMode mode = GameMode.ONEPLAYERVSBOT; //Change game mode here
            Window w = new Window("Bomberman", 1000, 1000);
            game = new Bomberman(w, mode);
        }
        /// <summary>
        /// Load game by using three methods in IGameManager interface.
        /// </summary>
        public void Load()
        {
            do
            {
                //----
                SplashKit.ClearScreen();
                game.Draw();
                //---- 
                SplashKit.RefreshScreen(60);
                game.Update();
                //----
                SplashKit.ProcessEvents();
                game.Control();
            }
            while (!SplashKit.WindowCloseRequested("Bomberman"));
        }
    }
}
