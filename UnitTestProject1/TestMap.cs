using Game.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject
{
    [TestClass]
    public class TestMap
    {
        [TestMethod]
        public void TestCreateMap()
        {
            World world = new World();
            Map map = new Map(world);
            map.CreateMapFromFile();

            for(int x = 0; x< map.CellArray.GetLength(0);x++)
            {
                for(int y = 0; y < map.CellArray.GetLength(1);x++)
                {
                    Assert.IsNotNull(map.CellArray[x,y]);
                }
            }
        }
        [TestMethod]
        public void TestCreateBlankMap()
        {
            World world = new World();
            Map map = new Map(world);
            map.CreateBlankMap();

            for (int x = 0; x < map.CellArray.GetLength(0); x++)
            {
                for (int y = 0; y < map.CellArray.GetLength(1); x++)
                {
                    Assert.IsNotNull(map.CellArray[x, y]);
                }
            }

        }
    }
}
