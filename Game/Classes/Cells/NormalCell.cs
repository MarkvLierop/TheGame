using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class NormalCell : Cells.Cell
    {

        public NormalCell(int x, int y) 
            : base(x, y)
        {

        }

        public override void DrawCell(Graphics g)
        {
            g.FillRectangle(Brushes.Blue, new Rectangle(Location, size));
        }
    }
}
