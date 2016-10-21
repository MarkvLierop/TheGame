using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class PUHealth : PowerUp
    {
        public PUHealth(World world) :base(world)
        {
            Effect = "Health";
        }

        public override void DrawPowerUp(Graphics g)
        {
            g.FillEllipse(Brushes.DarkRed, new Rectangle(Cell.Location, Cell.Size));
        }
    }
}
