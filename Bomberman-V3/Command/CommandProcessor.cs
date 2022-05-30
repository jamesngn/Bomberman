using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    public class CommandProcessor
    {
        private List<Player> thePlayer = new List<Player>();
        private List<KeyCode> buttons = new List<KeyCode>() {   KeyCode.SpaceKey, KeyCode.WKey, KeyCode.SKey, KeyCode.DKey, KeyCode.AKey, 
                                                                KeyCode.KeypadEnter, KeyCode.WKey, KeyCode.SKey, KeyCode.DKey, KeyCode.AKey};
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
            if (SplashKit.KeyTyped(buttons[0])){ return new PlaceBomb(thePlayer[0]); }
            if (SplashKit.KeyDown(buttons[1])) { return new Move(thePlayer[0],Direction.UP); }
            if (SplashKit.KeyDown(buttons[2])) { return new Move(thePlayer[0], Direction.DOWN); }
            if (SplashKit.KeyDown(buttons[3])) { return new Move(thePlayer[0], Direction.RIGHT); }
            if (SplashKit.KeyDown(buttons[4])) { return new Move(thePlayer[0], Direction.LEFT); }
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
            thePlayer[0].StoreLastPosition();
            //Consider to place them in the update() method in Player class.
            Command theCommand = handleInput();
            if (theCommand != null)
                theCommand.Execute();
            
        }
    }
}
