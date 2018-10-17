using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Pages.AskResponses
{
    public class DeleteModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public DeleteModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AskResponse AskResponse { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AskResponse = await _context.AskResponse.FirstOrDefaultAsync(m => m.ID == id);

            if (AskResponse == null)
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

            AskResponse = await _context.AskResponse.FindAsync(id);

            if (AskResponse != null)
            {
                _context.AskResponse.Remove(AskResponse);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./ChangeResponses");
        }
    }
}
