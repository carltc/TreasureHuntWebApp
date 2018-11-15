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
    public class TheLabyrinthModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public TheLabyrinthModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public IList<Choice> Choice { get; set; }
        public String PreviousResult { get; set; }
        public int CurrentChoice = 0;

        public async Task OnGetAsync(int? cID, int? pR)
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("PlayerName")))
            {
                if (cID.HasValue)
                {
                    int choiceID = (int)cID;
                    var choices = from choice in _context.Choice
                                  where choice.ID == choiceID
                                  select choice;
                    Choice = await choices.ToListAsync();

                    CurrentChoice = choiceID;
                
                    if (pR.HasValue && choiceID > 1)
                    {
                        var previousResults = from choice in _context.Choice
                                              where choice.ID == choiceID - 1
                                              select choice;
                        var tempPR = await choices.ToListAsync();
                        if (pR == 1) { PreviousResult = tempPR[0].Result1; }
                        else if (pR == 2) { PreviousResult = tempPR[0].Result2; }
                        else if (pR == 3) { PreviousResult = tempPR[0].Result3; }
                        else { PreviousResult = ""; }
                    }
                    else
                    {
                        PreviousResult = "";
                    }
                }
                else
                {
                    Choice = new List<Choice> { };
                    Choice.Add(new Choice { ID = 0, Choice1 = "", Choice2 = "", Choice3 = "", CorrectAnswer = 0, Question = "", Result1 = "", Result2 = "", Result3 = ""});
                    PreviousResult = "";
                }
            }
        }

        public IActionResult OnPost(string door, int choice)
        {
            if (!String.IsNullOrEmpty(door))
            {
                choice++;
                return Redirect("./TheLabyrinth?cID=" + choice.ToString() + "&pR=" + door);
            }
            return Page();
        }
    }
}