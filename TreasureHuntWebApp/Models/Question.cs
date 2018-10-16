using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreasureHuntWebApp.Models
{
    public class Question
    {
        public int ID { get; set; }

        //[RegularExpression(@"^\d+$"), StringLength(2, MinimumLength = 1), Required, Display(Name = "Question Number")]
        public int QuestionNumber { get; set; }

        //[StringLength(60), Display(Name = "Question Title")]
        public string Title { get; set; }

        //[Display(Name = "Added Date")]
        public DateTime ReleaseDate { get; set; }
        
        //[Required, Display(Name = "Question")]
        public string Content { get; set; }

        //[StringLength(60, MinimumLength = 1), Required]
        public string Answer { get; set; }

        public int AnswerIndex { get; set; }

        public int ClueIndex { get; set; }
    }
}
