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

        public int HuntID = 6;
        public IList<Choice> Choice { get; set; }
        public String PreviousResult { get; set; }
        public int CurrentChoice = 0;
        public int PlayerScore { get; set; }

        public async Task<IActionResult> OnGetAsync(int? cID, int? pR)
        {
            string playerName = HttpContext.Session.GetString("PlayerName");
            if (!String.IsNullOrEmpty(playerName))
            {
                if (cID.HasValue && cID > 0 && cID <= 10)
                {
                    int choiceID = (int)cID;

                    var scores = from score in _context.Score
                                 where score.Name == playerName && score.HuntID == HuntID && score.QuestionID == choiceID
                                 select score;
                    if (scores.Count() > 0)
                    {
                        choiceID++;
                        return Redirect("./TheLabyrinth?cID=" + choiceID.ToString());
                    }
                    else
                    {
                        var choices = from choice in _context.Choice
                                      where choice.ID == choiceID
                                      select choice;
                        Choice = await choices.ToListAsync();

                        CurrentChoice = choiceID;

                        var playerScore = from pS in _context.Score
                                          where pS.Name == playerName && pS.HuntID == HuntID && pS.Points == 0
                                          select pS;

                        PlayerScore = 100 - (playerScore.Count() * 10);
                
                        if (pR.HasValue && choiceID > 1)
                        {
                            var previousResults = from choice in _context.Choice
                                                  where choice.ID == choiceID - 1
                                                  select choice;
                            var tempPR = await previousResults.ToListAsync();
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

                }
                else if (cID > 10)
                {
                    return Redirect("./ChoicesMade");
                }
                else
                {
                    Choice = new List<Choice> { };
                    Choice.Add(new Choice { ID = 0, Choice1 = "", Choice2 = "", Choice3 = "", CorrectAnswer = 0, Question = "", Result1 = "", Result2 = "", Result3 = ""});
                    PreviousResult = "";
                }
            }

            return null;
        }

        public IActionResult OnPost(string door, int choice)
        {
            if (!String.IsNullOrEmpty(door) && choice > 0)
            {
                var choices = from choiceTable in _context.Choice
                              where choiceTable.ID == choice
                              select choiceTable;
                Choice = choices.ToList();
                if (Choice[0].CorrectAnswer == int.Parse(door))
                {
                    _context.Score.AddRange(
                        new Score
                        {
                            Name = HttpContext.Session.GetString("PlayerName"),
                            EntryTime = DateTime.Now,
                            HuntID = 6,
                            QuestionID = choice,
                            ScoreType = 0,
                            Points = 10
                        }
                    );
                }
                else
                {
                    _context.Score.AddRange(
                        new Score
                        {
                            Name = HttpContext.Session.GetString("PlayerName"),
                            EntryTime = DateTime.Now,
                            HuntID = 6,
                            QuestionID = choice,
                            ScoreType = 0,
                            Points = 0
                        }
                    );
                }
                _context.SaveChanges();

                choice++;
                return Redirect("./TheLabyrinth?cID=" + choice.ToString() + "&pR=" + door);
            }
            return Page();
        }
    }
}