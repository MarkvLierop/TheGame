using Game;
using Game.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    partial class MainMenuForm : Form
    {
        private World world = new World();
        public MainMenuForm()
        {
            InitializeComponent();
        }
        private void ShowGameForm(GameForm gForm)
        {
            Hide();
            gForm.ShowDialog();

            if (gForm.DialogResult == DialogResult.OK)
            {
                this.Show();
                gForm = null;
                world = new World();
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            GameForm gForm = new GameForm(world);
            ShowGameForm(gForm);
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnQuitGame_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreateMap_Click(object sender, EventArgs e)
        {
            GameForm gForm = new GameForm(world, true);
            ShowGameForm(gForm);
        }
    }
}
