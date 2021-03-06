﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes.Cells
{
    public abstract class Cell
    {
        public Size Size { get; protected set; }
        public Point Location { get; set; }

        public Cell(Point p, Size s)
        {
            Location = p;
            Size = s;
        }

        public abstract void DrawCell(Graphics g, int nr);
    }
}
