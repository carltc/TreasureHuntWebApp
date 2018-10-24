using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Pages.AngryTerm
{
    public class DeleteModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public DeleteModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CrossWord CrossWord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CrossWord = await _context.CrossWord.FirstOrDefaultAsync(m => m.ID == id);

            if (CrossWord == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CrossWord = await _context.CrossWord.FindAsync(id);

            if (CrossWord != null)
            {
                _context.CrossWord.Remove(CrossWord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ReplaceCharacters");
        }
    }
}
