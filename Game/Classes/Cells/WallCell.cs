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
        public WallCell(int x, int y) : base(x,y)
        {

        }

        public override void DrawCell(Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(Location, size));
        }
    }
}
