using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    class PlayerIdentity
    {
        private string _id;
        public PlayerIdentity(string id)
        {
            _id = id;
        }
        public void SetInfo(Info info)
        {
            info.RowStart = GetRowStart();
            info.ColStart = GetColStart();
            info.Color = GetPlayerColor();
            info.BombColor = GetBombColor();
            info.Speed = 5;
            info.Size = 20;
        }
        private int GetRowStart()
        {
            switch (_id)
            {
                case "p1":
                    return 1;
                case "p2":
                    return 2;
                default:
                    return 0;
            }
        }
        private int GetColStart()
        {
            switch (_id)
            {
                case "p1":
                    return 1;
                case "p2":
                    return 1;
                default:
                    return 0;
            }
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
