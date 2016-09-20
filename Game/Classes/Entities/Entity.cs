using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes
{
    class Entity
    {
        private Size size = new Size(48, 48);

        public int MovementSpeed { get; set; }
        public Point Location { get; set; }
        public Bitmap Image { get; set; }
    }
}
