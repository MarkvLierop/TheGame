using Game.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes.Repositories
{
    class MapRepository
    {
        private IMap iMap;

        public MapRepository(IMap iMap)
        {
            this.iMap = iMap;
        }

        public string GetRandomMapName()
        {
            return iMap.GetRandomMap();
        }

        public bool CheckIfMapnameExists(string mapname)
        {
            return iMap.CheckIfMapNameExists(mapname);
        }

        public List<NormalCell> GetNormalCells(string mapname, Size cellSize)
        {
            return iMap.GetNormalCells(mapname, cellSize);
        }

        public List<WallCell> GetWallCells(string mapname, Size cellSize)
        {
            return iMap.GetWallCells(mapname, cellSize);
        }

        public void SaveMapToDatabase(string mapName, List<Point> normalCellList, List<Point> wallCellList)
        {
            iMap.InsertMap(mapName, normalCellList, wallCellList);
        }
    }
}
