using System;
using SplashKitSDK;

namespace Bomberman_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            Window w = new Window("Bomberman", 500, 500);
            Game.Instance().Initialise(w);
            do
            {
                //----
                SplashKit.ClearScreen();
                Game.Instance().Draw();
                //----
                SplashKit.RefreshScreen(60);
                Game.Instance().Update();
                //----
                SplashKit.ProcessEvents();
                Game.Instance().Control();
            }
            while (!SplashKit.WindowCloseRequested("Bomberman"));
        }
    }
}
