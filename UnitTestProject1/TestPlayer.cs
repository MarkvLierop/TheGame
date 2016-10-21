using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Classes;

namespace UnitTestProject
{
    [TestClass]
    public class TestPlayer
    {        
        [TestMethod]
        public void TestMovePlayer()
        {
            World world = new World();
            Map map = new Map(world);
            Player player = new Player(world);
            map.CreateMapFromFile();

            for (int x = 0; x < map.CellArray.GetLength(0);x++)
            {
                for (int y = 0; y < map.CellArray.GetLength(1);y++)
                {
                    if (map.CellArray[x,y] == player.LocationOnCell)
                    {
                        player.MovePlayer(System.Windows.Forms.Keys.Right);
                        Assert.AreEqual(map.CellArray[0, 0], map.CellArray[1,0]);
                    }
                }
            }
        }
    }
}
