﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes.Exceptions
{
    class CreateMapException : Exception
    {
        public CreateMapException(string message)
            : base("No map could be created: " + message)
        {
        }
    }
}
