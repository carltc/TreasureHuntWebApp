using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace TreasureHuntWebApp.Pages.ItsADungeonCrawl
{
    public class MedievalDungeonModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public MedievalDungeonModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public IList<Dungeon> Dungeon { get; set; }
        public int CurrentDungeonID { get; set; }

        public async Task OnGetAsync(int? dungeonID,int? fight)
        {
            var dungeons = from dungeon in _context.Dungeon
                           where dungeon.ID == dungeonID && dungeon.WorldID == 3
                           select dungeon;

            CurrentDungeonID = dungeons.FirstOrDefault().ID;

            if (fight == 1)
            {
                dungeons.FirstOrDefault().ItemID = 0;
            }

            Dungeon = await dungeons.ToListAsync();
        }

        public IActionResult OnPost(string door)
        {
            if (!String.IsNullOrEmpty(door))
            {
                if (door == "99")
                {
                    return Redirect("./MedievalDungeon?dungeonID=" + CurrentDungeonID.ToString() + "&" + "fight=1");
                }
                return Redirect("./MedievalDungeon?dungeonID=" + door.ToString());
            }
            return Page();
        }
    }
}