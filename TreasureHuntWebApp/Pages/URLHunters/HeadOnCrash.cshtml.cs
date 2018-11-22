using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TreasureHuntWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace TreasureHuntWebApp.Pages.URLHunters
{
    public class HeadOnCrashModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public HeadOnCrashModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public int URLHuntCount { get; set; }
        public int QuestionID = 6;

        public IActionResult OnGet()
        {
            string Name = HttpContext.Session.GetString("ParticipantName");
            if (String.IsNullOrEmpty(Name))
            {
                return Redirect("./");
            }
            else
            {
                // Check if current player has completed previous question and if not then add this to database
                var currentCompletion = _context.URLHunt.Where(u => u.ParticipantName == Name && u.QuestionID == QuestionID - 1).ToList();
                if (currentCompletion.Count <= 0)
                {
                    URLHunt urlHunt = new URLHunt
                    {
                        QuestionID = QuestionID - 1,
                        ParticipantName = Name,
                        CompletedTime = DateTime.Now
                    };
                    _context.URLHunt.Add(urlHunt);
                    _context.SaveChanges();
                }

                // Check how many players have completed current question
                var URLHunts = from gg in _context.URLHunt
                               where gg.QuestionID == QuestionID
                               group gg by gg.ParticipantName into g
                               select new { Name = g.Key };
                URLHuntCount = URLHunts.Count();
            }
            return Page();
        }
    }
}