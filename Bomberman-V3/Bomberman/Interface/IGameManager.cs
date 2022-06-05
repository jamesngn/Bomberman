using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    interface IGameManager
    {
        public void Draw();
        public void Update();
        public void Control();
    }
}
