using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TreasureHuntWebApp.Models
{
    public class TreasureHuntWebAppContext : DbContext
    {
        public TreasureHuntWebAppContext (DbContextOptions<TreasureHuntWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<TreasureHuntWebApp.Models.Question> Question { get; set; }
    }
}
