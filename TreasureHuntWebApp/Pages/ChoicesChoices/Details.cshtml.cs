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
    public class DetailsModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public DetailsModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

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
    }
}
