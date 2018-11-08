using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Pages.ChoicesChoices
{
    public class CreateModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public CreateModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Choice Choice { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Choice.Add(Choice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}