using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Pages.ChoicesChoices
{
    public class DeleteModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public DeleteModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Choice Choice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Choice = await _context.Choice.FirstOrDefaultAsync(m => m.ID == id);

            if (Choice == null)
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

            Choice = await _context.Choice.FindAsync(id);

            if (Choice != null)
            {
                _context.Choice.Remove(Choice);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
