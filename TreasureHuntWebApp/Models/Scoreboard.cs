using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TreasureHuntWebApp.Models
{
    public class Scoreboard : DbContext
    {
        public System.Int64 ID { get; set; }

        public string Name { get; set; }

        public System.Int64 Score { get; set; }

    }
}
