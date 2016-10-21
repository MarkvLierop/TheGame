using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes.Exceptions
{
    class NoMapFoundException : Exception
    {
        public NoMapFoundException(string message) 
            : base("No map has been found. Create a map before starting the game")
        {
        }
    }
}
