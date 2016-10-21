using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class PUInvisible : PowerUp
    {
        public PUInvisible(World world) 
            :  base(world)
        {
            Effect = "Invisible";
        }

        public override void DrawPowerUp(Graphics g)
        {
            g.FillEllipse(Brushes.White, new Rectangle(Cell.Location, Cell.Size));
        }
    }
}
