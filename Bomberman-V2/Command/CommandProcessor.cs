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
        private List<Player> thePlayer = new List<Player>();
        private static CommandProcessor _instance;
        public static CommandProcessor Instance()
        {
            if (_instance == null)
                _instance = new CommandProcessor();
            return _instance;
        }
        public void AddPlayer(Player newPlayer)
        {
            thePlayer.Add(newPlayer);
        }
        private Command handleInput()
        {
            if (SplashKit.KeyTyped(KeyCode.SpaceKey))   { return new PlaceBomb(thePlayer[0]); }
            if (SplashKit.KeyDown(KeyCode.WKey))        { return new MoveForward(thePlayer[0]); }
            if (SplashKit.KeyDown(KeyCode.SKey))        { return new MoveBackward(thePlayer[0]); }
            if (SplashKit.KeyDown(KeyCode.DKey))        { return new MoveRight(thePlayer[0]); }
            if (SplashKit.KeyDown(KeyCode.AKey))        { return new MoveLeft(thePlayer[0]); }
/*            if (thePlayer.Count > 1)
            {
                if (SplashKit.KeyTyped(KeyCode.KeypadEnter)) { return new PlaceBomb(thePlayer[1]); }
                if (SplashKit.KeyDown(KeyCode.UpKey)) { return new MoveForward(thePlayer[1]); }
                if (SplashKit.KeyDown(KeyCode.DownKey)) { return new MoveBackward(thePlayer[1]); }
                if (SplashKit.KeyDown(KeyCode.RightKey)) { return new MoveRight(thePlayer[1]); }
                if (SplashKit.KeyDown(KeyCode.LeftKey)) { return new MoveLeft(thePlayer[1]); }
            }*/
            return null;
        }
        public void Execute()
        {
            //Consider to place them in the update() method in Player class.
            thePlayer[0].StoreOldPosition();
            Command theCommand = handleInput();
            if (theCommand != null)
             theCommand.Execute();
        }
    }
}
