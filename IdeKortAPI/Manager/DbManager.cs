using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeKortAPI.Manager
{
    public class DbManager
    {
        protected const string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=IdeKortDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
