using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes.Cells
{
    abstract class Cell
    {
        protected Size size;
        protected Point Location { get; set; }

        public Cell(int x, int y)
        {
            size = new Size(48, 48);
            Location = new Point(x * size.Width, y * size.Height);
        }

        public abstract void DrawCell(Graphics g);
    }
}
