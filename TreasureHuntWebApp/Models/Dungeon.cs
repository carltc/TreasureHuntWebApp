using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreasureHuntWebApp.Models
{
    public class Dungeon
    {
        public int ID { get; set; }

        public int RoomID { get; set; }

        public int WorldID { get; set; }

        public string Name { get; set; }

        public int NorthID { get; set; }
        public int EastID { get; set; }
        public int SouthID { get; set; }
        public int WestID { get; set; }

        public string Storyline { get; set; }

        public int ItemID { get; set; }

        public string Guidebook { get; set; }
    }
}
