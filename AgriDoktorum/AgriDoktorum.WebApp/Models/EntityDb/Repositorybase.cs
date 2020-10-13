using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgriDoktorum.WebApp.Models.EntityDb
{
    public class RepositoryBase
    {
        protected static DatabaseContext _context;
        private static readonly object _lockSync = new object();

        protected RepositoryBase()
        {
            CreateContext();
        }

        private static void CreateContext()
        {
            if (_context == null)
            {
                lock (_lockSync)
                {
                    if (_context == null)
                    {
                        _context = new DatabaseContext();
                    }

                }
            }
        }
    }
}