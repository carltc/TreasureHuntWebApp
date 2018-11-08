using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreasureHuntWebApp.Models
{
    public class Score
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public int HuntID { get; set; }

        public int QuestionID { get; set; } // 0=no specific question

        public int ScoreType { get; set; } // 0=Normal, 1=Bonus

        public int Points { get; set; }

        public DateTime EntryTime { get; set; }

        public Score(string newName, int newPoints)
        {
            ID = 0;
            Name = newName;
            HuntID = 0;
            QuestionID = 0;
            ScoreType = 0;
            Points = newPoints;
            EntryTime = DateTime.Now;
        }
    }
}
