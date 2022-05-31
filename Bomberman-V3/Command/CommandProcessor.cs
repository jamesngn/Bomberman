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
        private const int noOfCommands = 5;
        private List<Player> thePlayer = new List<Player>();
        private List<KeyCode> buttons = new List<KeyCode>() {   KeyCode.SpaceKey, KeyCode.WKey, KeyCode.SKey, KeyCode.DKey, KeyCode.AKey, 
                                                                KeyCode.LKey, KeyCode.UpKey, KeyCode.DownKey, KeyCode.RightKey, KeyCode.LeftKey};
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
            for (int i = 0; i < thePlayer.Count; i++)
            {
                if (SplashKit.KeyTyped(buttons[0 +noOfCommands * i])) { return new PlaceBomb(thePlayer[i]); }
                if (SplashKit.KeyDown(buttons[1 + noOfCommands * i])) { return new Move(thePlayer[i], Direction.UP); }
                if (SplashKit.KeyDown(buttons[2 + noOfCommands * i])) { return new Move(thePlayer[i], Direction.DOWN); }
                if (SplashKit.KeyDown(buttons[3 + noOfCommands * i])) { return new Move(thePlayer[i], Direction.RIGHT); }
                if (SplashKit.KeyDown(buttons[4 + noOfCommands * i])) { return new Move(thePlayer[i], Direction.LEFT); }
            }
            return null;
        }
        public void Execute()
        {
            for (int i = 0; i < thePlayer.Count; i++)
            {
                thePlayer[i].StoreLastPosition();
            }
            //Consider to place them in the update() method in Player class.
            Command theCommand = handleInput();
            if (theCommand != null)
                theCommand.Execute();
            
        }
    }
}
