using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class Map
    {
        private Random rand = new Random();
        private int randInt = 0;

        private NormalCell normalCell;
        private WallCell wallCell;
        private int xFieldLength;
        private int yFieldLength;


        private List<NormalCell> normalCellList = new List<NormalCell>();
        private List<WallCell> wallCellList = new List<WallCell>();
        public Map(World world)
        {
            // Defines speelveld grootte.
            xFieldLength = 30;
            yFieldLength = 40;
        }
        public void CreateMap()
        {
            // Cellen aanmaken met de aangegeven positie.
            for(int x = 0;x < xFieldLength;x++)
            {
                for(int y = 0; y < yFieldLength;y++)
                {
                    randInt = rand.Next(0, xFieldLength);
                    if(randInt > 8)
                    {
                        normalCell = new NormalCell(x, y);
                        NormalCellList().Add(normalCell);
                    }
                    else
                    {
                        wallCell = new WallCell(x, y);
                        WallCellList().Add(wallCell);
                    }
                }
            }
        }
        public List<NormalCell> NormalCellList()
        {
            return normalCellList;
        }
        public List<WallCell> WallCellList()
        {
            return wallCellList;
        }
    }
}
