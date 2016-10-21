using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Classes.Exceptions
{
    class QueryFailedException : Exception
    {
        public QueryFailedException(string message) 
            : base("Database query could not be executed: " +message)
        {
        }
    }
}
