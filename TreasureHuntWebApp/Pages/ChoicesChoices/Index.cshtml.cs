using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace TreasureHuntWebApp.Pages.ChoicesChoices
{
    public class IndexModel : PageModel
    {
        public IActionResult OnPost(string button, string PlayerName)
        {
            if (button == "Play Game")
            {
                HttpContext.Session.SetString("PlayerName", PlayerName);
                return Redirect("./ChoicesChoices/TheLabyrinth?cID=1");
            }
            return Page();
        }
    }
}
