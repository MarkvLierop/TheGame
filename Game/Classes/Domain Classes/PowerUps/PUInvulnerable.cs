using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes.PowerUps
{
    public class PUInvulnerable : PowerUp
    {
        public PUInvulnerable(World world) 
            : base(world)
        {
            Effect = "Invulnerable";
        }

        public override void DrawPowerUp(Graphics g)
        {
            g.FillEllipse(Brushes.Yellow, new Rectangle(Cell.Location, Cell.Size));
        }
    }
}
