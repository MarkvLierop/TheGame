using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    public class Enemy : Entity
    {
        // Fields
        private int richting;
        List<int> mogelijkeRichtingen = new List<int> { 0, 1, 2, 3 };

        // ---        
        public Enemy(World world, Cells.Cell cell)
        {
            this.world = world;
            LocationOnCell = cell;
        }
        public void MoveEnemy(Random rand)
        {
            GetPosition();

            // Enemy verplaatsen
            switch (CheckForWalls(rand))
            {
                case 0:
                    // Up
                    LocationOnCell = world.Map.CellArray[x, y - 1];
                    break;
                case 1:
                    // Down
                    LocationOnCell = world.Map.CellArray[x, y + 1];
                    break;
                case 2:
                    // Right
                    LocationOnCell = world.Map.CellArray[x + 1, y];
                    break;
                case 3:
                    // Left
                    LocationOnCell = world.Map.CellArray[x - 1, y];
                    break;
            }
        }
        public override void DrawEntity(Graphics g)
        {
            g.FillEllipse(Brushes.Red, new Rectangle(LocationOnCell.Location, world.Map.CellArray[0, 0].Size));
        }
        private int CheckForWalls(Random rand)
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
                    // Up -- Checken of er niet buiten de map (CellArray) verplaatst gaat worden
                    if ((y - 1) >= 0)
                    {
                        // Kijken of er een wall boven is. Zo ja, dan UP als mogelijke richting verwijderen
                        if (world.Map.CellArray[x, y - 1].GetType() == typeof(WallCell))
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
                    if (y + 1 != world.Map.CellArray.GetLength(1))
                    {
                        if (world.Map.CellArray[x, y + 1].GetType() == typeof(WallCell))
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
                    if (x + 1 != world.Map.CellArray.GetLength(0))
                    {
                        if (world.Map.CellArray[x + 1, y].GetType() == typeof(WallCell))
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
                        if (world.Map.CellArray[x - 1, y].GetType() == typeof(WallCell))
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
                    CheckForWalls(rand);
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
        public int LookForPlayer(int richting)
        {
            int aggroDistanceToPlayer = 6;

            // Als de speler niet gevonden wordt. De gewone richting volgen.
            for (int x = 0; x < aggroDistanceToPlayer; x++)
            {
                for (int y= 0; y < aggroDistanceToPlayer; y++)
                {
                        if (base.x + x < world.Map.CellArray.GetLength(0) && 
                            world.Map.CellArray[base.x + x, base.y] == world.Player.LocationOnCell)
                        {
                            // Rechts opgaan als daar de speler bevindt
                            return 2;
                        }
                        if (base.x - x >= 0 && 
                            world.Map.CellArray[base.x - x, base.y] == world.Player.LocationOnCell)
                        {
                            // Links
                            return 3;
                        }
                        if (base.y + y < world.Map.CellArray.GetLength(1) && 
                            world.Map.CellArray[base.x, base.y + y] == world.Player.LocationOnCell)
                        {
                            // Down
                            return 1;
                        }
                        if (base.y - y >= 0 && 
                            world.Map.CellArray[base.x, base.y - y] == world.Player.LocationOnCell)
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
