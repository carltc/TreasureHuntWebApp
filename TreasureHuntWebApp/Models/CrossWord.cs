using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreasureHuntWebApp.Models
{
    public class CrossWord
    {
        public int ID { get; set; }

        public char Letter { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

    }
}
