using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Classes
{
    public class Player : Entity
    {
        public int HealthPoints { get; set; }
        public int Points { get; set; }
        public string ActivePowerUp { get; set; }
        
        public Player(World world)
        {
            this.world = world;

            LocationOnCell = world.GetMapCellArray()[0, 0];
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
                        if (world.GetMapCellArray()[x, y - 1].GetType() == typeof(WallCell))
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Keys.Down:
                    if (y + 1 != world.GetMapCellArray().GetLength(1))
                    {
                        if (world.GetMapCellArray()[x, y + 1].GetType() == typeof(WallCell))
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case Keys.Right:
                    if (x + 1 != world.GetMapCellArray().GetLength(0))
                    {
                        if (world.GetMapCellArray()[x + 1, y].GetType() == typeof(WallCell))
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
                        if (world.GetMapCellArray()[x - 1, y].GetType() == typeof(WallCell))
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

        public bool PickUpPowerUp()
        {
            // Kijken of er een powerup aangeraakt wordt
            foreach (PowerUp pu in world.Map.PowerUpsOnMapList)
            {
                if (LocationOnCell == pu.Cell)
                {
                    ActivePowerUp = pu.Effect;
                    if (pu.Effect == "Health")
                        HealthPoints += 1;
                    world.Map.PowerUpsOnMapList.Remove(pu);
                    return true;
                }
            }
            return false;
        }
        // Positie opvragen, speler bewegen als er geen wall bevindt op die locatie.
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
                        LocationOnCell = world.GetMapCellArray()[x, y - 1];
                        break;
                    case Keys.Down:
                        LocationOnCell = world.GetMapCellArray()[x, y + 1];
                        break;
                    case Keys.Right:
                        LocationOnCell = world.GetMapCellArray()[x + 1, y];
                        break;
                    case Keys.Left:
                        LocationOnCell = world.GetMapCellArray()[x - 1, y];
                        break;
                }
            }
        }
        
        public bool CheckForDamage()
        {
            if(ActivePowerUp != "Invulnerable")
            {
                foreach (Enemy e in world.EnemyList)
                {
                    // Kijken of de speler zich op dezelfde cell bevindt als een enemy
                    if (LocationOnCell == e.LocationOnCell)
                    {
                        HealthPoints -= 1;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckIfGameWon()
        {
            if (LocationOnCell == world.GetMapCellArray()[world.GetMapCellArray().GetLength(0)-1, world.GetMapCellArray().GetLength(1)-1])
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
            g.FillEllipse(Brushes.Green, new Rectangle(LocationOnCell.Location, world.GetMapCellArray()[0, 0].Size));
        }

    }
}
