using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bomberman_V3
{
    /// <summary>
    /// to remove the object when needed
    /// </summary>
    public interface IRemovable
    {
        public bool IsRemoved { get; }
    }
}
