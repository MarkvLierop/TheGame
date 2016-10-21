using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Game.Classes
{
    class Map
    {
        private World world;
        private Cells.Cell Cell;
        private int cellXAxisRowCount;
        private int cellYAxisRowCount;
        private Size cellSize;
        private List<PowerUp> powerUpList;

        public Cells.Cell[,] CellArray { get; }
        public List<PowerUp> PowerUpsOnMapList { get; }
        public Map(World world)
        {
            this.world = world;

            cellXAxisRowCount = 27;
            cellYAxisRowCount = 16;
            cellSize = new Size(30, 30);
            CellArray = new Cells.Cell[cellXAxisRowCount, cellYAxisRowCount];

            PowerUpsOnMapList = new List<PowerUp>();
        }
        public void CreateBlankMap()
        {
            for(int x = 0;x < cellXAxisRowCount;x++)
            {
                for (int y = 0;y < cellYAxisRowCount;y++)
                {
                    Cell = new NormalCell(new Point(x * cellSize.Width, y * cellSize.Height), cellSize);
                    CellArray[x, y] = Cell;
                }
            }
        }
        public void CreateMapFromFile()
        {
            string line;
            string randomMap = GetRandomMapName();
            try
            {
                //NormalCells
                System.IO.StreamReader srNormalCells = new System.IO.StreamReader(randomMap + @"\NormalCellList.txt");
                while ((line = srNormalCells.ReadLine()) != null)
                {
                    Cell = new NormalCell(ConvertLineToPoint(line), cellSize);
                    AddCellToCellArray(line);
                }
                srNormalCells.Close();

                //WallCells
                System.IO.StreamReader srWallCells = new System.IO.StreamReader(randomMap + @"\WallCellList.txt");
                while ((line = srWallCells.ReadLine()) != null)
                {
                    Cell = new WallCell(ConvertLineToPoint(line), cellSize);
                    AddCellToCellArray(line);
                }
                srWallCells.Close();
            }
            catch
            {
            }

            SpawnPowerUps();
        }

        public void DrawEndGameText(Graphics g, int width, int height, bool gameWon)
        {
            g.DrawString(gameWon ? "Game Won!" : "Game Over!", new Font("Arial", 100), 
                         gameWon ? Brushes.ForestGreen : Brushes.Brown, new Point(width / 15 /2, height / 3));
        }

        // Punt uit bestand toevoegen aan de array van Cells.
        private void AddCellToCellArray(string line)
        {
            CellArray[ConvertLineToPoint(line).X / cellSize.Width, ConvertLineToPoint(line).Y / cellSize.Height] = Cell;
        }

        private void SpawnPowerUps()
        {
            Random rand = new Random();

            for (int i = 0; i < 5; i++)
            {
                powerUpList = new List<PowerUp> { new PUInvisible(world), new PUHealth(world), new PowerUps.PUInvulnerable(world) };
                int randomPowerUp = rand.Next(0, powerUpList.Count);
                powerUpList[randomPowerUp].Cell = CellArray[rand.Next(0, CellArray.GetLength(0)), rand.Next(0, CellArray.GetLength(1))];
                PowerUpsOnMapList.Add(powerUpList[randomPowerUp]);
            }
        }
        // Willekeurige map selecteren in de Debug directory
        private string GetRandomMapName()
        {
            Random Rand = new Random();
            string RandomMap;
            string[] Path = Directory.GetDirectories(Directory.GetCurrentDirectory());
            RandomMap = Path[Rand.Next(Path.Count())];
            return RandomMap;
        }

        // Bestandinhoud splitten van [X = 48, Y = 0] naar 48, 0.
        private Point ConvertLineToPoint(string line)
        {
            string[] Punt = line.Split(',');
            // Integers zoeken in de gesplitte string
            string p1 = Regex.Match(Punt[0], @"\d+").Value;
            string p2 = Regex.Match(Punt[1], @"\d+").Value;
            // string omzetten naar echte ints.
            int x = Int32.Parse(p1);
            int y = Int32.Parse(p2);

            return new Point(x, y);
        }
    }
}
