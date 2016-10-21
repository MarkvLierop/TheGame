using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Classes
{
    abstract class Entity
    {
        private Size size = new Size(30, 30);
        protected World world;
        protected int x, y;

        public Cells.Cell Cell { get; set; }


        public abstract void DrawEntity(Graphics g);
        
        protected void GetPosition()
        {
            x = world.map.CellArray.GetLength(0); // width
            y = world.map.CellArray.GetLength(1); // height

            // Positie opvragen van de speler in de CellArray.
            for (int Xaxis = 0; Xaxis < x; Xaxis++)
            {
                for (int Yaxis = 0; Yaxis < y; Yaxis++)
                {
                    if (world.map.CellArray[Xaxis, Yaxis] == Cell)
                    {
                        x = Xaxis;
                        y = Yaxis;
                        break;
                    }
                }
            }
        }
    }
}
