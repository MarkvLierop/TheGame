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

namespace Game
{
    partial class GameForm : Form
    {
        private Map map;
        private List<Enemy> enemylist = new List<Enemy>();

        public GameForm(Map map)
        {
            InitializeComponent();
            this.map = map;

            map.CreateMap();            
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
            foreach (WallCell wc in map.WallCellList())
            {
                wc.DrawCell(g);
            }
            foreach (NormalCell c in map.NormalCellList())
            {
                c.DrawCell(g);
            }
        }
    }
}
