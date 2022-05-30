using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    public interface IObservable
    {
        public void AddObserver(IObserver observer);
        public void RemoveObserver(IObserver observer);
        public void NotifyObserver(IObservable subject);
    }
}
