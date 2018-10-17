using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreasureHuntWebApp.Models
{
    public class AskResponse
    {
        public int ID { get; set; }

        public string Question { get; set; }

        public string Response { get; set; }

        public DateTime AskDate { get; set; }

        public int AskType { get; set; }

    }
}
