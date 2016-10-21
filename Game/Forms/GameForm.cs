using Game.Classes;
using Game.Classes.Cells;
using Game.Classes.Exceptions;
using Game.Classes.Persistencies;
using Game.Classes.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private int powerUpTimeCounter = 10;

        // Voor Map creator
        public GameForm(World world, bool createMap)
        {
            InitializeComponent();
            this.world = world;
            this.createMap = createMap;

            world.CreateBlankMap();

            btnSaveToFile.Visible = true;
            btnSaveToDatabase.Visible = true;
            txtMapName.Visible = true;
            foreach (Cell c in world.Map.CellArray)
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
        public GameForm(World world, string from)
        {
            InitializeComponent();
            this.world = world;

            if(from == "File")
            {
                try
                {
                    world.CreateMapFromFile();
                }
                catch (CreateMapException e)
                {
                    MessageBox.Show(e.Message);
                    Application.Exit();
                }
            }
            else if (from == "Database")
            {
                // Connectie naar vdi.FHICT.nl Benodigd.
                world.CreateMapFromDatabase();
            }
            world.SpawnPlayer();         
            world.SpawnEnemies();

            tmrGameTimer.Enabled = true;
            lblHealth.Text = "Health Points: " +world.Player.HealthPoints.ToString();
            lblPoints.Text = "Points: " + world.Player.Points.ToString();  
        }
        // MouseDown event voor Map creator. 
        private void p_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (e.Button == MouseButtons.Right)
            {
                p.BackColor = Color.Blue;
            }
            if (e.Button == MouseButtons.Left)
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
            // Alleen uitvoeren als de gebruiker niet in de create map mode zit
            if(!createMap)
            {
                // Cells tekenen
                foreach (Cell c in world.Map.CellArray)
                {
                    c.DrawCell(g, count);
                    count++;
                }
                // Powerups tekenen
                foreach (PowerUp p in world.Map.PowerUpsOnMapList)
                {
                    p.DrawPowerUp(g);
                }
                // Enemies tekenen
                foreach (Enemy enemy in world.EnemyList)
                {
                    enemy.DrawEntity(g);
                }
                // Player tekenen
                world.Player.DrawEntity(g);

                // Game over tekenen
                if (gameLost)
                {
                    world.Map.DrawEndGameText(g, pbGameField.Width, pbGameField.Height, false);
                }
                // Game won tekenen
                if (gameWon)
                {
                    world.Map.DrawEndGameText(g, pbGameField.Width, pbGameField.Height, true);
                }
            }
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMapName.Text))
            {
                try
                {
                    SaveMapToFile();   
                    MessageBox.Show("Map opgeslagen.");
                }
                catch
                {
                    MessageBox.Show("Er is iets foutgegaan bij het opslaan van de map. \n Mogelijk bestaat de mapnaam al");
                }
            }
        }

        // Speler bewegen
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            world.Player.MovePlayer(e.KeyCode);

            if(world.Player.PickUpPowerUp())
            {
                lblHealth.Text = "Health Points: " + world.Player.HealthPoints.ToString();
                tmrPowerUp.Enabled = true;
            }
            Refresh();
        }

        private void tmrGameTimer_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            // Enemies bewegen
            foreach (Enemy enemy in world.EnemyList)
            {
                enemy.MoveEnemy(rand);
            }
            // Kijken of een enemy een speler raakt
            if (world.Player.CheckForDamage())
            {
                lblHealth.Text = "Health Points: " + world.Player.HealthPoints.ToString();
                if (world.Player.CheckIfGameOver())
                {
                    gameLost = true;
                    EndGame();
                }
            }
            // Checken of het spel gewonnen is
            if (world.Player.CheckIfGameWon())
            {
                lblPoints.Text = "Points: " + world.Player.Points.ToString();
                gameWon = true;
                EndGame();
            }
            Refresh();
        }

        private void btnSaveToDatabase_Click(object sender, EventArgs e)
        {
            MapRepository maprepo = new MapRepository(new MSSQL_Server());
            List<Point> normallCellPointList = new List<Point>();
            List<Point> wallCelLPointList = new List<Point>();

            foreach (PictureBox pb in pbGameField.Controls)
            {
                if (pb.BackColor == Color.Blue)
                {
                    normallCellPointList.Add(pb.Location);
                }
            }
            foreach (PictureBox pb in pbGameField.Controls)
            {
                if (pb.BackColor == Color.Black)
                {
                    wallCelLPointList.Add(pb.Location);
                }
            }
            maprepo.SaveMapToDatabase(txtMapName.Text, normallCellPointList, wallCelLPointList);
            MessageBox.Show("Map Opgeslagen");
        }
        // Gametimer & eventhandler voor keypress stoppen
        private void EndGame()
        {
            this.KeyDown -= new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            tmrGameTimer.Enabled = false;
        }
        private void SaveMapToFile()
        {
            DirectoryInfo newDir = new DirectoryInfo(txtMapName.Text);

            if (newDir.Exists)
            {
                MessageBox.Show("Map already exists.");
            }
            else
            {
                newDir.Create();

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
            }
        }

        private void tmrPowerUp_Tick(object sender, EventArgs e)
        {
            if(powerUpTimeCounter == 10)
            {
                tmrPowerUp.Enabled = false;
                powerUpTimeCounter = 0;
            }
        }
    }
}
