using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IdeKortLib.Models;

namespace IdeKortAPIEF.Data
{
    public class IdeKortAPIEFContext : DbContext
    {
        public IdeKortAPIEFContext (DbContextOptions<IdeKortAPIEFContext> options)
            : base(options)
        {
        }

        public DbSet<IdeKortLib.Models.User> User { get; set; }
    }
}
