using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    public interface IDownCountable
    {
        public int TimeToFinish { get; set; }
        public bool Finished { get; }
        public void CountDown();
    }
}
