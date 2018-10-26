using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;

namespace TreasureHuntWebApp.Pages
{
    public class winnersModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public winnersModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public IList<Winner> Winner { get;set; }
        public int huntID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                huntID = (int)id;

                // fix for hunt 1 and 2 having swapped id's
                if (id == 1){id++;}
                else if (id == 2){id--;}

                Winner = await _context.Winner.Where(field => field.HuntID == id)
                    .GroupBy(item => item.Name)
                    .Select(grouping => grouping.FirstOrDefault())
                    .OrderBy(item => item.WinTime)
                    .ToListAsync();
            }
        }
    }
}
