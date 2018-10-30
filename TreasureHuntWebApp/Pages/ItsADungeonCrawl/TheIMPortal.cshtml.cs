using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TreasureHuntWebApp.Pages.ItsADungeonCrawl
{
    public class TheIMPortalModel : PageModel
    {
        public IActionResult OnPost(string portal)
        {
            if (portal == "importal1")
            {
                return RedirectToPage("./TropicalDungeon");
            }
            else if (portal == "importal2")
            {
                return RedirectToPage("./SpaceDungeon");
            }
            else if (portal == "importal3")
            {
                return Redirect("./MedievalDungeon?dungeonID=1");
                //return RedirectToPage("./MedievalDungeon","?dungeonID=1");
            }
            return Page();
        }
    }
}