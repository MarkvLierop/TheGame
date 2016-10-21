using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    abstract class PowerUp
    {
        protected World world;
        public Cells.Cell Cell { get; set; }        
        public string Effect { get; protected set; }

        public PowerUp(World world)
        {
            this.world = world;
        }

        public abstract void DrawPowerUp(Graphics g);
    }
}
