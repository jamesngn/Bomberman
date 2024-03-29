﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace Bomberman_V3
{
    /// <summary>
    /// inherits from Item class
    /// increase the Player's bomb explosion radius
    /// </summary>
    public class BombRadius : Item
    {
        public BombRadius(float x, float y) : base(x, y, SplashKit.ColorDarkBlue()) { }
        protected override void AddToPlayer(Player player)
        {
            player.BombRadius++;
        }
    }
}
