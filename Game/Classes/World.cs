using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class World
    {
        public Map map;
        public World()
        {
            map = new Map(this);
        }
    }
}
