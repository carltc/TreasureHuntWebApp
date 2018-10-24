using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Pages.AngryTerm
{
    public class ReplaceCharactersModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public ReplaceCharactersModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public IList<CrossWord> CrossWord { get;set; }

        public async Task OnGetAsync()
        {
            CrossWord = await _context.CrossWord.ToListAsync();
        }
    }
}
