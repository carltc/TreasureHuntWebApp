using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace TreasureHuntWebApp.Pages.URLHunters
{
    public class IndexModel : PageModel
    {
        public IActionResult OnPost(string button, string PlayerName)
        {
            if (button == "Continue")
            {
                if (PlayerName.Count() > 1)
                {
                    HttpContext.Session.SetString("ParticipantName", PlayerName);
                    string currentURL = Url.ActionContext.HttpContext.Request.Path;
                    if (currentURL[currentURL.Length-1].ToString() == "/")
                    {
                        return Redirect("./unt");
                    }
                    else
                    {
                        return Redirect("./urlhunters/unt");
                    }
                }
            }
            return Page();
        }
    }
}