using System;
using SplashKitSDK;

namespace Bomberman_V3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Use WASD keys to move and SPACE key to place bomb");
            Console.WriteLine("Item: Pink - increase bom numbers; Blue - increase bomb radius");
            Console.WriteLine("Enemy: white - when one enemy dies, the others move faster");

            Game game = new Game();
            game.Load();
            
        }
    }
}

