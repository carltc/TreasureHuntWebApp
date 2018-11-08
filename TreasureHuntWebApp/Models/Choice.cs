using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreasureHuntWebApp.Models
{
    public class Choice
    {
        public int ID { get; set; }

        public string Question { get; set; }

        public string Choice1 { get; set; }

        public string Result1 { get; set; }

        public string Choice2 { get; set; }

        public string Result2 { get; set; }

        public string Choice3 { get; set; }

        public string Result3 { get; set; }

        public int CorrectAnswer { get; set; }
    }
}
