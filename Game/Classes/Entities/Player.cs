using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class Player : Entity
    {
        public int HealthPoints { get; set; }
        public string ActivePowerUp { get; set; }
    }
}
