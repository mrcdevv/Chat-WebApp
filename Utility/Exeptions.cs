using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.Utility
{
    public class Exceptions
    {
        public class UserNotFoundException : Exception
        {
            public UserNotFoundException() : base("Usuario no enccontrado") { }

            public UserNotFoundException(string message) : base(message) { }
        }


    }
}