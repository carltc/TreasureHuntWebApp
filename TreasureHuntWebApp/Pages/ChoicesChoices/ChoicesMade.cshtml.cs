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
    public class ChoicesMadeModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public ChoicesMadeModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public int HuntID = 6;
        public int PlayerScore { get; set; }

        public void OnGet()
        {
            string playerName = HttpContext.Session.GetString("PlayerName");
            if (!String.IsNullOrEmpty(playerName))
            {
                var playerScore = from pS in _context.Score
                                    where pS.Name == playerName && pS.HuntID == HuntID && pS.Points == 0
                                    select pS;

                PlayerScore = 100 - (playerScore.Count() * 10);
            }
        }
    }
}