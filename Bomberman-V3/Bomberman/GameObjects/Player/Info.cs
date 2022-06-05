using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// contain basic information of a player
    /// </summary>
    class Info
    {
        public Info()
        {

        }
        public int RowStart { get; set; }
        public int ColStart { get; set; }
        public Color Color { get; set; }
        public Color BombColor { get; set; }
        public float Speed { get; set; }
        public float Size { get; set; }
        public int Health { get; set; }
    }
}
