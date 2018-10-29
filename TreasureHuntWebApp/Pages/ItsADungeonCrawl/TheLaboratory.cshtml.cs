using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TreasureHuntWebApp.Pages.ItsADungeonCrawl
{
    public class TheLaboratoryModel : PageModel
    {
        public IActionResult OnPost(string button)
        {
            if (button == "Check out the IM-Portals")
            {
                return RedirectToPage("./TheIMPortal");
            }
            return Page();
        }
    }
}