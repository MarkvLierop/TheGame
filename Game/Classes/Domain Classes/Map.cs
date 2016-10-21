using Game.Classes.Repositories;
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
    public class Map
    {
        private World world;
        private Cells.Cell Cell;
        private int cellXAxisRowCount;
        private int cellYAxisRowCount;
        private List<PowerUp> powerUpList;

        public Cells.Cell[,] CellArray { get; private set; }
        public Size CellSize { get; private set; }
        public List<PowerUp> PowerUpsOnMapList { get; private set; }
        public Map(World world)
        {
            this.world = world;

            cellXAxisRowCount = 27;
            cellYAxisRowCount = 16;
            CellSize = new Size(30, 30);
            CellArray = new Cells.Cell[cellXAxisRowCount, cellYAxisRowCount];

            PowerUpsOnMapList = new List<PowerUp>();
        }
        public void CreateBlankMap()
        {
            for(int x = 0;x < cellXAxisRowCount;x++)
            {
                for (int y = 0;y < cellYAxisRowCount;y++)
                {
                    Cell = new NormalCell(new Point(x * CellSize.Width, y * CellSize.Height), CellSize);
                    CellArray[x, y] = Cell;
                }
            }
        }
        public void CreateMapFromDatabase()
        {
            MapRepository maprepo = new MapRepository(new Persistencies.MSSQL_Server());

            string randomMap = maprepo.GetRandomMapName();
            List<NormalCell> normalcellList = maprepo.GetNormalCells(randomMap, CellSize);
            for (int i = 0; i< normalcellList.Count;i++)
            {
                CellArray[normalcellList[i].Location.X / CellSize.Width, normalcellList[i].Location.Y / CellSize.Height] = normalcellList[i];
            }

            List<WallCell> wallcellList = maprepo.GetWallCells(randomMap, CellSize);
            for(int i = 0;i < wallcellList.Count;i++)
            {
                CellArray[wallcellList[i].Location.X / CellSize.Width, wallcellList[i].Location.Y / CellSize.Height] = wallcellList[i];
            }
            SpawnPowerUps();
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
                    Cell = new NormalCell(ConvertLineToPoint(line), CellSize);
                    AddCellToCellArray(line);
                }
                srNormalCells.Close();

                //WallCells
                System.IO.StreamReader srWallCells = new System.IO.StreamReader(randomMap + @"\WallCellList.txt");
                while ((line = srWallCells.ReadLine()) != null)
                {
                    Cell = new WallCell(ConvertLineToPoint(line), CellSize);
                    AddCellToCellArray(line);
                }
                srWallCells.Close();
            }
            catch (FileNotFoundException e)
            {
                throw new Exceptions.CreateMapException(e.Message);
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
            CellArray[ConvertLineToPoint(line).X / CellSize.Width, ConvertLineToPoint(line).Y / CellSize.Height] = Cell;
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
            try
            {
                Random Rand = new Random();
                string RandomMap;
                string[] Path = Directory.GetDirectories(Directory.GetCurrentDirectory());
                RandomMap = Path[Rand.Next(Path.Count())];
                return RandomMap;
            }
            catch(Exception e)
            {
                throw new Exceptions.NoMapFoundException(e.Message);
            }
        }

        // Bestandinhoud splitten van [X = 48, Y = 0] naar 48 & 0.
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
