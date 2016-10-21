using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    public class World
    {
        // Fields
        private int enemyCount;

        // --- 
        public Map Map { get; private set; }
        public Player Player { get; private set; }
        public Enemy Enemy { get; private set; }
        public List<Entity> EnemyList { get; private set; }
        // ---
        public World()
        {
            enemyCount = 10;
            EnemyList = new List<Entity>();
        }

        public void CreateMapFromFile()
        {
            Map = new Map(this);
            Map.CreateMapFromFile();
        }
        public void CreateMapFromDatabase()
        {
            Map = new Map(this);
            Map.CreateMapFromDatabase();
        }
        public void CreateBlankMap()
        {
            Map = new Map(this);
            Map.CreateBlankMap();
        }
        public void SpawnPlayer()
        {
            Player = new Player(this);
        }
        public void SpawnEnemies()
        {
            Random rand = new Random();
            for(int i = 0; i < enemyCount; i++)
            {
                Enemy = new Enemy(this, Map.CellArray[rand.Next(0, Map.CellArray.GetLength(0)), 
                                                       rand.Next(0, Map.CellArray.GetLength(1))]);
                EnemyList.Add(Enemy);
            }
        }
    }
}
