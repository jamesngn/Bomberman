using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// use the command pattern to control the commands for the player.
    /// </summary>
    public class CommandProcessor
    {
        private const int noOfCommands = 5;
        /// <summary>
        /// add the player 1 and 2 into this list to execute their commands
        /// </summary>
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
        /// <summary>
        /// create the corresponding command based on the input for player 1
        /// </summary>
        /// <returns> Command is the parrent class that is returned, will be used in execute (polymorphism) </returns>
        private Command handleInputPlayer1()
        {
            if (SplashKit.KeyTyped(buttons[0])){ return new PlaceBomb(thePlayer[0]); }
            if (SplashKit.KeyDown(buttons[1])) { return new Move(thePlayer[0], Direction.UP); }
            if (SplashKit.KeyDown(buttons[2])) { return new Move(thePlayer[0], Direction.DOWN); }
            if (SplashKit.KeyDown(buttons[3])) { return new Move(thePlayer[0], Direction.RIGHT); }
            if (SplashKit.KeyDown(buttons[4])) { return new Move(thePlayer[0], Direction.LEFT); }
            return null;
        }
        /// <summary>
        /// create the corresponding command based on the input for player 2
        /// </summary>
        /// <returns> Command is the parrent class that is returned, will be used in execute (polymorphism) </returns>
        private Command handleInputPlayer2()
        {
            if (thePlayer.Count > 1) 
            {
                if (SplashKit.KeyTyped(buttons[0 + noOfCommands])) { return new PlaceBomb(thePlayer[1]); }
                if (SplashKit.KeyDown(buttons[1 + noOfCommands])) { return new Move(thePlayer[1], Direction.UP); }
                if (SplashKit.KeyDown(buttons[2 + noOfCommands])) { return new Move(thePlayer[1], Direction.DOWN); }
                if (SplashKit.KeyDown(buttons[3 + noOfCommands])) { return new Move(thePlayer[1], Direction.RIGHT); }
                if (SplashKit.KeyDown(buttons[4 + noOfCommands])) { return new Move(thePlayer[1], Direction.LEFT); }
            }
            return null;
        }
        /// <summary>
        /// use polymorphism here
        /// store last position for the player
        /// </summary>
        public void Execute()
        {
            for (int i = 0; i < thePlayer.Count; i++)
            {
                thePlayer[i].StoreLastPosition();
            }
            //Consider to place them in the update() method in Player class.
            Command theCommand1 = handleInputPlayer1();
            Command theCommand2 = handleInputPlayer2();
            if (theCommand1 != null)
                theCommand1.Execute();
            if (theCommand2 != null)
                theCommand2.Execute();
        }
    }
}
