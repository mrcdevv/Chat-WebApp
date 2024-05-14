using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWebApp.DbInit
{
    public interface IDbInitializer
    {
        public void Initilize();
    }
}