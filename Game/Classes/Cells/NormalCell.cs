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

        public NormalCell(Point p, Size z) 
            : base(p, z)
        {

        }

        public override void DrawCell(Graphics g, int nr)
        {
            g.FillRectangle(Brushes.Blue, new Rectangle(Location, Size));
            //g.DrawString(nr.ToString(), new Font("Arial",14),Brushes.Black,Location);
        }
    }
}
