using System;
using SplashKitSDK;

namespace Bomberman_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            Window w = new Window("Bomberman", 500, 500);
            do
            {
                //----
                SplashKit.ClearScreen();
                
                //----
                SplashKit.RefreshScreen(60);
                
                //----
                SplashKit.ProcessEvents();
                
            }
            while (!SplashKit.WindowCloseRequested("Bomberman"));
        }
    }
}
