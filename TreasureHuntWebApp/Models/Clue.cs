using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreasureHuntWebApp.Models
{
    public class Clue
    {
        public int ID { get; set; }

        public int HuntID { get; set; }

        public int ClueType { get; set; }

        public string ClueText { get; set; }

        public int Cost { get; set; }
    }
}
