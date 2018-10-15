using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreasureHuntWebApp.Models
{
    public class Question
    {
        public int QuestionNumber { get; set; }
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
    }
}
