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
    public class IndexModel : PageModel
    {
        public IActionResult OnPost(string button)
        {
            if (button == "Play Game")
            {
                return RedirectToPage("./TheLabyrinth");
            }
            return Page();
        }
    }
}
