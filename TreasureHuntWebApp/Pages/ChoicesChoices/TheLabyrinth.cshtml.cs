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

        public async Task OnGetAsync(int? choiceID, int? fight)
        {
            var choices = from choice in _context.Choice
                           where choice.ID == choiceID
                           select choice;
            Choice = await choices.ToListAsync();
        }

        public IActionResult OnPost(string door)
        {
            if (!String.IsNullOrEmpty(door))
            {
                return Redirect("./TheLabyrinth?choiceID=" + door.ToString());
            }
            return Page();
        }
    }
}