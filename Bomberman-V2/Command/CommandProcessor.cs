using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V2
{
    public class CommandProcessor
    {
        private Player thePlayer;
        private static CommandProcessor _instance;
        public static CommandProcessor Instance()
        {
            if (_instance == null)
                _instance = new CommandProcessor();
            return _instance;
        }
        public void AddPlayer(Player newPlayer)
        {
            thePlayer = newPlayer;
        }
        private Command handleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey)) { return new PlaceBomb(thePlayer); }
            if (SplashKit.KeyDown(KeyCode.UpKey))   { return new MoveForward(thePlayer); }
            if (SplashKit.KeyDown(KeyCode.DownKey)) { return new MoveBackward(thePlayer); }
            if (SplashKit.KeyDown(KeyCode.RightKey)) { return new MoveRight(thePlayer); }
            if (SplashKit.KeyDown(KeyCode.LeftKey)) { return new MoveLeft(thePlayer); }
            return null;
        }
        public void Execute()
        {
            //Consider to place them in the update() method in Player class.
            thePlayer.LastX = thePlayer.X;
            thePlayer.LastY = thePlayer.Y;
            Command theCommand = handleInput();
            if (theCommand != null)
             theCommand.Execute();
        }
    }
}
