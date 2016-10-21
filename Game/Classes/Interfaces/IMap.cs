using System.Collections.Generic;
using System.Drawing;

namespace Game.Classes.Interfaces
{
    interface IMap
    {
        string GetRandomMap();
        bool CheckIfMapNameExists(string mapName);
        List<WallCell> GetWallCells(string mapName, Size cellSize);
        List<NormalCell> GetNormalCells(string mapName, Size cellSize);
        void InsertMap(string mapName, List<Point> normalCellLocationList, List<Point> wallCellLocationList);
    }
}
