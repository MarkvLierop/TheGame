using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class WallCell : Cells.Cell
    {
        public WallCell(Point p, Size s) 
            : base(p, s)
        {

        }

        public override void DrawCell(Graphics g, int nr)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(Location, Size));
        }
    }
}
