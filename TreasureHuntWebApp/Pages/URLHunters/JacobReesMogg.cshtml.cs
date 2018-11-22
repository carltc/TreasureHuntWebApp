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
    public class JacobReesMoggModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public JacobReesMoggModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public int URLHuntCount { get; set; }
        public int QuestionID = 12;

        public IList<Winner> Winner { get; set; }
        private int HuntID = 7;
        
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
                               where gg.QuestionID == QuestionID - 1
                               group gg by gg.ParticipantName into g
                               select new { Name = g.Key };
                URLHuntCount = URLHunts.Count();

                // Add current player as winner
                AddWinner(Name);
                
                string winnerName = HttpContext.Session.GetString("ParticipantName");
                var winners = from w in _context.Winner
                              select w;
                winners = winners.Where(r => r.Name == winnerName);
                Winner = winners.ToList();
            }
            return Page();
        }

        public void AddWinner(string winnerName)
        {
            _context.Winner.AddRange(
                new Winner
                {
                    Name = winnerName,
                    WinTime = DateTime.Now,
                    HuntID = HuntID
                }
            );

            if (!_context.Score.Where(field => field.Name == winnerName && field.HuntID == HuntID && field.QuestionID == 0).Any())
            {
                int currentEntries = _context.Score.Where(field => field.HuntID == HuntID && field.QuestionID == 0).Count();

                int points = 0;
                if (currentEntries <= 0) { points = 100; }
                else if (currentEntries == 1) { points = 50; }
                else if (currentEntries == 2) { points = 25; }
                else if (currentEntries == 3) { points = 12; }
                else { points = 10; }

                _context.Score.AddRange(
                    new Score
                    {
                        Name = winnerName,
                        EntryTime = DateTime.Now,
                        HuntID = HuntID,
                        QuestionID = 0,
                        ScoreType = 0,
                        Points = points
                    }
                );
            }

            _context.SaveChanges();
        }
    }
}