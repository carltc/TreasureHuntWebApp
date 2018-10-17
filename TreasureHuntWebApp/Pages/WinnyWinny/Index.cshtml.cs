using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Pages.WinnyWinny
{
    public class IndexModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public IndexModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public IList<Winner> Winner { get; set; }

        public async Task<IActionResult> OnGetAsync(string winnerName)
        {
            var winners = from w in _context.Winner
                          select w;

            if (!String.IsNullOrEmpty(winnerName))
            {
                winners = winners.Where(r => r.Name.Contains(winnerName));
            }
            else
            {
                winners = winners.Where(r => r.Name.Contains("asfasgsgdfdavADSVavsa"));
            }
            Winner = await winners.ToListAsync();

            if (Winner == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string winnerName)
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
                        WinTime = DateTime.Now
                    }
                );
                await _context.SaveChangesAsync();

                //return RedirectToPage("./WinnyWinny/WinnerResponsePage" + "?winnerName=" + winnerName);
                return RedirectToAction("./", new { winnerName = winnerName });
            }
        }
    }
}
