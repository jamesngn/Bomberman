﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    interface IMovable
    {
        public float Speed { get; }
        public void StoreLastPosition();
        public void GoLastPosition();
        public void Respawn();
    }
}
