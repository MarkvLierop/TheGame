using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    public class PUHealth : PowerUp
    {
        public PUHealth(World world) :base(world)
        {
            Effect = "Health";
        }

        public override void DrawPowerUp(Graphics g)
        {
            g.FillEllipse(Brushes.DarkRed, new Rectangle(Cell.Location, Cell.Size));
            g.DrawString("HP", new Font("Arial", Cell.Size.Width / 2), Brushes.Black, 
                new Point(Cell.Location.X + (Cell.Size.Width / 10), Cell.Location.Y + (Cell.Size.Height / 10)));
        }
    }
}
