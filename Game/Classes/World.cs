using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class World
    {
        public Map map;
        public Player player;
        public Enemy enemy;

        private int enemyCount;
        public List<Entity> enemyList { get; }
        public World()
        {
            enemyCount = 15;

            enemyList = new List<Entity>();
        }

        public void SpawnEnemies()
        {
            Random rand = new Random();
            for(int i = 0; i < enemyCount; i++)
            {
                enemy = new Enemy(this, map.CellArray[rand.Next(0, map.CellArray.GetLength(0)), 
                                                       rand.Next(0, map.CellArray.GetLength(1))]);
                enemyList.Add(enemy);
            }
        }
    }
}
