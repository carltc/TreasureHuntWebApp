using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreasureHuntWebApp.Models
{
    public class URLHunt
    {
        public int ID { get; set; }

        public int QuestionID { get; set; }

        public string ParticipantName { get; set; }

        public DateTime CompletedTime { get; set; }
    }
}
