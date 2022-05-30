using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    public interface IObserver
    {
        public void UpdateFromSubject(IObservable subject);
    }
}
