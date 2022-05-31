using System;
using SplashKitSDK;

namespace Bomberman_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            Window w = new Window("Bomberman", 500, 500);
            Bomberman game = new Bomberman(w);
            game.Initialise();
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
