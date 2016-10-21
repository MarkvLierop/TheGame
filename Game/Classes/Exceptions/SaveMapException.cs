using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes.Exceptions
{
    class SaveMapException : Exception
    {
        public SaveMapException(string message) 
            : base("Map could not be saved: " + message)
        {
        }
    }
}
