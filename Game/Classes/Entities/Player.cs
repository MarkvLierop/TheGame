﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Classes
{
    class Player : Entity
    {
        public int HealthPoints { get; set; }
        public int Points { get; set; }
        public string ActivePowerUp { get; set; }
        
        public Player(World world)
        {
            this.world = world;

            Cell = world.map.CellArray[0, 0];
            HealthPoints = 4;
            Points = 0;
        }

        private bool CheckForWallCollision(Keys pressedKey)
        {
            switch (pressedKey)
            {
                case Keys.Up:
                    if ((y - 1) >= 0)
                    {
                        if (world.map.CellArray[x, y - 1].GetType() == typeof(WallCell))
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Keys.Down:
                    if (y + 1 != world.map.CellArray.GetLength(1))
                    {
                        if (world.map.CellArray[x, y + 1].GetType() == typeof(WallCell))
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Keys.Right:
                    if (x + 1 != world.map.CellArray.GetLength(0))
                    {
                        if (world.map.CellArray[x + 1, y].GetType() == typeof(WallCell))
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Keys.Left:
                    if ((x - 1) >= 0)
                    {
                        if (world.map.CellArray[x - 1, y].GetType() == typeof(WallCell))
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        public void MovePlayer(Keys pressedKey)
        {
            GetPosition();

            // Als er geen Wall is op de positie waarnaar de speler will verplaatsen, doorgaan.
            if (CheckForWallCollision(pressedKey))
            {
                // Speler verplaatsen
                switch (pressedKey)
                {
                    case Keys.Up:
                        Cell = world.map.CellArray[x, y - 1];
                        break;
                    case Keys.Down:
                        Cell = world.map.CellArray[x, y + 1];
                        break;
                    case Keys.Right:
                        Cell = world.map.CellArray[x + 1, y];
                        break;
                    case Keys.Left:
                        Cell = world.map.CellArray[x - 1, y];
                        break;
                }
            }
        }
        
        public bool CheckForDamage()
        {
            foreach (Enemy e in world.enemyList)
            {
                if (Cell == e.Cell)
                {
                    HealthPoints -= 1;
                    return true;
                }
            }
            return false;
        }

        public bool CheckIfGameWon()
        {
            if (Cell == world.map.CellArray[world.map.CellArray.GetLength(0)-1, world.map.CellArray.GetLength(1)-1])
            {
                Points++;
                return true;
            }
            return false;
        }

        public bool CheckIfGameOver()
        {
            if (HealthPoints <= 0)
            {
                return true;
            }
            return false;
        }

        public override void DrawEntity(Graphics g)
        {
            g.FillEllipse(Brushes.Green, new Rectangle(Cell.Location, world.map.CellArray[0, 0].Size));
        }

    }
}
