using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// This class helps to avoid the repeated code when the player with different ids can have different default information.
    /// </summary>
    class PlayerIdentity
    {
        private string _id;
        private GameMode _gameMode;
        public PlayerIdentity(string id, GameMode gamemode)
        {
            _id = id;
            _gameMode = gamemode;
        }
        public void SetInfo(Info info)
        {
            info.RowStart = GetRowStart();
            info.ColStart = GetColStart();
            info.Color = GetPlayerColor();
            info.BombColor = GetBombColor();
            info.Speed = 5;
            info.Size = 20;
            info.Health = 5;
        }
        private int GetRowStart()
        {
            if (_id == "p1")
            {
                return 1;
            } 
            else if (_id == "p2")
            {
                if (_gameMode == GameMode.TWOPLAYERSVSBOT)
                {
                    return 2;
                }
                else if (_gameMode == GameMode.PVP)
                {
                    return 17;
                }
            }
            return 0;
        }
        private int GetColStart()
        {
            if (_id == "p1")
            {
                return 1;
            }
            else if (_id == "p2")
            {
                if (_gameMode == GameMode.TWOPLAYERSVSBOT)
                {
                    return 1;
                }
                else if (_gameMode == GameMode.PVP)
                {
                    return 17;
                }
            }
            return 0;
        }
        private Color GetPlayerColor()
        {
            switch (_id)
            {
                case "p1":
                    return SplashKit.ColorPurple();
                case "p2":
                    return SplashKit.ColorRed();
                default:
                    return SplashKit.ColorBlack();
            }
        }
        private Color GetBombColor()
        {
            switch (_id)
            {
                case "p1":
                    return SplashKit.ColorMediumPurple();
                case "p2":
                    return SplashKit.ColorPaleVioletRed();
                default:
                    return SplashKit.ColorBlack();
            }
        } 
    }
}
