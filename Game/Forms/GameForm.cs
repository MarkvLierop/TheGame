using Game.Classes;
using Game.Classes.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    partial class GameForm : Form
    {
        private World world;

        private bool createMap;
        private bool gameWon;
        private bool gameLost;

        // Voor Map creator
        public GameForm(World world, bool createMap)
        {
            InitializeComponent();
            this.world = world;
            this.createMap = createMap;

            world.map = new Map(world);
            world.map.CreateBlankMap();

            btnSave.Visible = true;
            txtMapName.Visible = true;
            foreach (Cell c in world.map.CellArray)
            {
                PictureBox p = new PictureBox();
                p.Location = c.Location;
                p.Size = c.Size;
                p.MouseDown += new System.Windows.Forms.MouseEventHandler(p_MouseDown);
                p.BackColor = Color.Blue;
                pbGameField.Controls.Add(p);
            }
        }
        // Voor normal game.
        public GameForm(World world)
        {
            InitializeComponent();
            this.world = world;

            world.map = new Map(world);
            world.map.CreateMapFromFile();
            world.player = new Player(world);            
            world.SpawnEnemies();

            tmrGameTimer.Enabled = true;
            lblHealth.Text = "Health Points: " +world.player.HealthPoints.ToString();
            lblPoints.Text = "Points: " + world.player.Points.ToString();  
        }
        // MouseDown event voor Map creator. 
        private void p_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (e.Button == MouseButtons.Left)
            {
                p.BackColor = Color.Blue;
            }
            if (e.Button == MouseButtons.Right)
            {
                p.BackColor = Color.Black;
            }
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void tmrPUSpeed_Tick(object sender, EventArgs e)
        {
        }

        private void pbGameField_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int count = 0;
            if(!createMap)
            {
                foreach (Cell c in world.map.CellArray)
                {
                    c.DrawCell(g, count);
                    count++;
                }
                foreach (PowerUp p in world.map.PowerUpsOnMapList)
                {
                    p.DrawPowerUp(g);
                }

                foreach (Enemy enemy in world.enemyList)
                {
                    enemy.DrawEntity(g);
                }
                world.player.DrawEntity(g);

                if (gameLost)
                {
                    world.map.DrawEndGameText(g, pbGameField.Width, pbGameField.Height, false);
                }
                if (gameWon)
                {
                    world.map.DrawEndGameText(g, pbGameField.Width, pbGameField.Height, true);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMapName.Text))
            {
                try
                {
                    // Mapnaam toevoegen aan lijst met mapnamen.
                    using (System.IO.TextWriter swMapName = new System.IO.StreamWriter("MapNameList.txt", true))
                    {
                        swMapName.WriteLine(txtMapName.Text);
                        swMapName.Close();
                    }

                    // Create Subfolder met ingegeven naam
                    System.IO.Directory.CreateDirectory(txtMapName.Text);


                    // Opslaan van WallCells in bestand
                    using (System.IO.TextWriter swSaveCells = new System.IO.StreamWriter(txtMapName.Text + @"\WallCellList.txt"))
                    {
                        foreach (PictureBox pb in pbGameField.Controls)
                        {
                            if (pb.BackColor == Color.Black)
                            {
                                swSaveCells.WriteLine(pb.Location);
                            }
                        }
                        swSaveCells.Close();
                    }

                    // Opslaan van Normallcells in bestand
                    using (System.IO.TextWriter swSaveCells = new System.IO.StreamWriter(txtMapName.Text + @"\NormalCellList.txt"))
                    {
                        foreach (PictureBox pb in pbGameField.Controls)
                        {
                            if (pb.BackColor == Color.Blue)
                            {
                                swSaveCells.WriteLine(pb.Location);
                            }
                        }
                        swSaveCells.Close();
                    }
                    MessageBox.Show("Map opgeslagen.");
                }
                catch
                {
                    MessageBox.Show("Er is iets foutgegaan bij het opslaan van de map. \n Mogelijk bestaat de mapnaam al");
                }
            }
        }
        
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            world.player.MovePlayer(e.KeyCode);
            Refresh();
        }

        private void tmrGameTimer_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            foreach (Enemy enemy in world.enemyList)
            {
                enemy.MoveEnemy(rand);
            }
            if (world.player.CheckForDamage())
            {
                lblHealth.Text = "Health Points: " + world.player.HealthPoints.ToString();
                if (world.player.CheckIfGameOver())
                {
                    gameLost = true;
                    EndGame();
                }
            }
            if (world.player.CheckIfGameWon())
            {
                lblPoints.Text = "Points: " + world.player.Points.ToString();
                gameWon = true;
                EndGame();
            }
            Refresh();
        }
        private void EndGame()
        {
            this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            tmrGameTimer.Enabled = false;
        }
    }
}
