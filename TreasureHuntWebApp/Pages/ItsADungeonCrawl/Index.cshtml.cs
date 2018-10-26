using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TreasureHuntWebApp.Pages.ItsADungeonCrawl
{
    public class IndexModel : PageModel
    {
        public IActionResult OnPost(string button)
        {
            if (button == "Go To Lab")
            {
                return RedirectToPage("./TheLaboratory");
            }
            return Page();
        }
    }
}