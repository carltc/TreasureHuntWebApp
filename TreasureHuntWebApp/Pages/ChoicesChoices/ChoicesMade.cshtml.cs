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
        public String PreviousResult { get; set; }

        public void OnGet(int? pR)
        {
            string playerName = HttpContext.Session.GetString("PlayerName");
            if (!String.IsNullOrEmpty(playerName))
            {
                var playerScore = from pS in _context.Score
                                    where pS.Name == playerName && pS.HuntID == HuntID && pS.Points == 0
                                    select pS;

                PlayerScore = 100 - (playerScore.Count() * 10);

                if (pR.HasValue)
                {
                    var choice = from c in _context.Choice
                                 where c.ID == 10
                                 select c;
                    var Choice = choice.ToList();

                    if (pR == 1)
                    {
                        PreviousResult = Choice[0].Result1;
                    }
                    else if (pR == 2)
                    {
                        PreviousResult = Choice[0].Result2;
                    }
                    else if (pR == 3)
                    {
                        PreviousResult = Choice[0].Result3;
                    }
                    else
                    {
                        PreviousResult = "";
                    }
                }
                else
                {
                    PreviousResult = "";
                }
            }
            else
            {
                PlayerScore = 0;
                PreviousResult = "Sorry. Your session may have timed out. Restart the hunt.";
            }
        }
    }
}