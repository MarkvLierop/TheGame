using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class Enemy : Entity
    {
        // Fields
        private int richting;
        List<int> mogelijkeRichtingen = new List<int> { 0, 1, 2, 3 };

        // ---        
        public Enemy(World world, Cells.Cell cell)
        {
            this.world = world;
            Cell = cell;
        }
        public void MoveEnemy(Random rand)
        {
            GetPosition();

            // Enemy verplaatsen
            switch (CheckForNearbyWalls(rand))
            {
                case 0:
                    // Up
                    Cell = world.map.CellArray[x, y - 1];
                    break;
                case 1:
                    // Down
                    Cell = world.map.CellArray[x, y + 1];
                    break;
                case 2:
                    // Right
                    Cell = world.map.CellArray[x + 1, y];
                    break;
                case 3:
                    // Left
                    Cell = world.map.CellArray[x - 1, y];
                    break;
            }
        }
        public override void DrawEntity(Graphics g)
        {
            g.FillEllipse(Brushes.Red, new Rectangle(Cell.Location, world.map.CellArray[0, 0].Size));
        }
        private int CheckForNearbyWalls(Random rand)
        {
            // Checken of enemy naar de player mag bewegen.
            if (!mogelijkeRichtingen.Contains(LookForPlayer(mogelijkeRichtingen[rand.Next(0, mogelijkeRichtingen.Count)])))
            {
                // Zo niet dan willekeurige kant op gaan.
                richting = mogelijkeRichtingen[rand.Next(0, mogelijkeRichtingen.Count)];
            }
            else
            {
                // Zo wel dan richting speler bewegen.
                richting = LookForPlayer(mogelijkeRichtingen[rand.Next(0, mogelijkeRichtingen.Count)]);
            }

            // Check voor walls. Als er geen speler gevonden wordt. de gewone richting volgen.
            switch (richting)
            {
                case 0:
                    // Up
                    if ((y - 1) >= 0)
                    {
                        if (world.map.CellArray[x, y - 1].GetType() == typeof(WallCell))
                            goto case 4;
                    }
                    else
                    {
                        goto case 4;
                    }
                    richting = 0;
                    break;
                case 1:
                    // Down
                    if (y + 1 != world.map.CellArray.GetLength(1))
                    {
                        if (world.map.CellArray[x, y + 1].GetType() == typeof(WallCell))
                            goto case 4;
                    }
                    else
                    {
                        goto case 4;
                    }
                    richting = 1;
                    break;
                case 2:
                    // Right
                    if (x + 1 != world.map.CellArray.GetLength(0))
                    {
                        if (world.map.CellArray[x + 1, y].GetType() == typeof(WallCell))
                            goto case 4;
                    }
                    else
                    {
                        goto case 4;
                    }
                    richting = 2;
                    break;
                case 3:
                    // Left
                    if ((x - 1) >= 0)
                    {
                        if (world.map.CellArray[x - 1, y].GetType() == typeof(WallCell))
                            goto case 4;
                    }
                    else
                    {
                        goto case 4;
                    }
                    richting = 3;
                    break;
                case 4:
                    mogelijkeRichtingen.Remove(richting);
                    CheckForNearbyWalls(rand);
                    break;
            }
            RefillList();
            return richting;
        }
        // Lijst met mogelijke richtingen vullen;
        private void RefillList()
        {
            mogelijkeRichtingen = new List<int> { 0, 1, 2, 3 };
        }
        private int LookForPlayer(int richting)
        {
            int distanceToPlayer = 6;

            // Als de speler niet gevonden wordt. De gewone richting volgen.
            for (int x = 0; x < distanceToPlayer; x++)
            {
                for (int y= 0; y < distanceToPlayer; y++)
                {
                        if (base.x + x < world.map.CellArray.GetLength(0) && 
                            world.map.CellArray[base.x + x, base.y] == world.player.Cell)
                        {
                            // Rechts opgaan als daar de speler bevindt
                            return 2;
                        }
                        if (base.x - x >= 0 && 
                            world.map.CellArray[base.x - x, base.y] == world.player.Cell)
                        {
                            // Links
                            return 3;
                        }
                        if (base.y + y < world.map.CellArray.GetLength(1) && 
                            world.map.CellArray[base.x, base.y + y] == world.player.Cell)
                        {
                            // Down
                            return 1;
                        }
                        if (base.y - y >= 0 && 
                            world.map.CellArray[base.x, base.y - y] == world.player.Cell)
                        {
                            // Up
                            return 0;
                        }
                }
            }

            return richting;
        }
    }
}
