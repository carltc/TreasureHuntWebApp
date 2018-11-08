using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Pages.ChoicesChoices
{
    public class ChangeChoiceModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public ChangeChoiceModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public IList<Choice> Choice { get;set; }

        public async Task OnGetAsync()
        {
            Choice = await _context.Choice.ToListAsync();
        }
    }
}
