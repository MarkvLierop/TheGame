using Game.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class TestEnemy
    {
        [TestMethod]
        public void TestLookForPlayer()
        {
            Random rand = new Random();
            World world = new World();
            Map map = new Map(world);
            Player player = new Player(world);

            // Enemy gaat naar links - speler is links van enemy
            player.LocationOnCell = map.CellArray[0, 0];
            Enemy enemy = new Enemy(world, map.CellArray[5, 0]);            
            Assert.Equals(3, enemy.LookForPlayer(0));
            Assert.Equals(3, enemy.LookForPlayer(1));
            Assert.Equals(3, enemy.LookForPlayer(2));
            Assert.Equals(3, enemy.LookForPlayer(3));
            
            // Enemy gaat naar rechts. speler is rechts van enemy
            player.LocationOnCell = map.CellArray[10, 0];
            enemy.LocationOnCell = map.CellArray[5, 0];
            Assert.Equals(2, enemy.LookForPlayer(0));
            Assert.Equals(2, enemy.LookForPlayer(1));
            Assert.Equals(2, enemy.LookForPlayer(2));
            Assert.Equals(2, enemy.LookForPlayer(3));

            // Enemy gaat naar onder
            player.LocationOnCell = map.CellArray[0, 10];
            enemy.LocationOnCell = map.CellArray[0, 5];
            Assert.Equals(1, enemy.LookForPlayer(0));
            Assert.Equals(1, enemy.LookForPlayer(1));
            Assert.Equals(1, enemy.LookForPlayer(2));
            Assert.Equals(1, enemy.LookForPlayer(3));

            // Enemy gaat naar boven
            player.LocationOnCell = map.CellArray[0, 5];
            enemy.LocationOnCell = map.CellArray[0, 10];
            Assert.Equals(0, enemy.LookForPlayer(0));
            Assert.Equals(0, enemy.LookForPlayer(1));
            Assert.Equals(0, enemy.LookForPlayer(2));
            Assert.Equals(0, enemy.LookForPlayer(3));
        }
    }
}
