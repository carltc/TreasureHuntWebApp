using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TreasureHuntWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace TreasureHuntWebApp.Pages.ItsADungeonCrawl
{
    public class TheHandoverModel : PageModel
    {
        public int portalNum { get; set; }

        public IActionResult OnGet(string portal)
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Compass")) && !String.IsNullOrEmpty(HttpContext.Session.GetString("Guidebook")))
            {
                if (portal == "importal1")
                {
                    return Redirect("./TropicalDungeon?dungeonID=2");
                }
                else if (portal == "importal2")
                {
                    return Redirect("./SpaceDungeon?dungeonID=1");
                }
                else if (portal == "importal3")
                {
                    return Redirect("./MedievalDungeon?dungeonID=1");
                }
            }

            if (!String.IsNullOrEmpty(portal))
            {
                if (portal == "importal1")
                {
                    portalNum = 1;
                }
                else if (portal == "importal2")
                {
                    portalNum = 2;
                }
                else if (portal == "importal3")
                {
                    portalNum = 3;
                }
            }

            return Page();
        }

        public IActionResult OnPost(string tool, int? portNum)
        {
            if (tool == "Compass")
            {
                HttpContext.Session.SetString("Compass", "Yes");
            }
            else if (tool == "Guidebook")
            {
                HttpContext.Session.SetString("Guidebook", "Yes");
            }

            if (portNum == 1)
            {
                return Redirect("./TropicalDungeon?dungeonID=1");
            }
            else if (portNum == 2)
            {
                return Redirect("./SpaceDungeon?dungeonID=1");
            }
            else if (portNum == 3)
            {
                return Redirect("./MedievalDungeon?dungeonID=1");
            }
            return Page();
        }
    }
}