﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    /// <summary>
    /// instantiate the bomb and specify the owner for the bomb
    /// </summary>
    class PlaceBomb : Command
    {
        Player thePlayer;
        public PlaceBomb(Player newPlayer)
        {
            thePlayer = newPlayer;
        }
        public override void Execute()
        {
            Factory.Instance().InstantiateBomb(thePlayer);
        }
    }
}
