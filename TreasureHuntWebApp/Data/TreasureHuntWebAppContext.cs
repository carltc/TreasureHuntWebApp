﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Models
{
    public class TreasureHuntWebAppContext : DbContext
    {
        public TreasureHuntWebAppContext (DbContextOptions<TreasureHuntWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<TreasureHuntWebApp.Models.Question> Question { get; set; }

        public DbSet<TreasureHuntWebApp.Models.AskResponse> AskResponse { get; set; }

        public DbSet<TreasureHuntWebApp.Models.Winner> Winner { get; set; }

        public DbSet<TreasureHuntWebApp.Models.Scoreboard> Scoreboard { get; set; }
    }
}
