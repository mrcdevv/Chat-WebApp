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
            public UserNotFoundException() : base("Usuario no enccontrado.") { }

            public UserNotFoundException(string message) : base(message) { }
        }

        public class UserAlreadyExistException : Exception
        {
            public UserAlreadyExistException() : base("El usuario ya se encuentra registrado.") { }
            public UserAlreadyExistException(string message) : base(message) { }
        }

        public class IdIsNullOrNegativeException : Exception
        {
            public IdIsNullOrNegativeException(string idName) : base($"{idName} debe ser una ID valida.") { }
        }


    }
}