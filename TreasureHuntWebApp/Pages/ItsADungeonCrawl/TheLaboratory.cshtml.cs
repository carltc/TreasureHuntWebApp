using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Pages.ItsADungeonCrawl
{
    public class TheLaboratoryModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public TheLaboratoryModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public IList<Winner> Winner { get; set; }
        private int HuntID = 7;

        public async Task<IActionResult> OnGetAsync(string winnerName)
        {
            if (String.IsNullOrEmpty(winnerName))
            {
                return Page();
            }

            var winners = from w in _context.Winner
                          select w;

            winners = winners.Where(r => r.Name.Contains(winnerName));
            Winner = await winners.ToListAsync();

            if (Winner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string button, string winnerName)
        {
            if (button == "Go to the IM-Portals")
            {
                return RedirectToPage("./TheIMPortal");
            }
            else if (button == "Enter")
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }
                else
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

                    await _context.SaveChangesAsync();

                    return RedirectToAction("./", new { winnerName = winnerName });
                }
            }
            return Page();
        }
    }
}