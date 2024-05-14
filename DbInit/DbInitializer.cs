using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWebApp.Context;

namespace ChatWebApp.DbInit
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ChatContext _context;

        public DbInitializer(ChatContext context)
        {
            _context = context;
        }

        public void Initilize()
        {
            throw new NotImplementedException();
        }
    }
}