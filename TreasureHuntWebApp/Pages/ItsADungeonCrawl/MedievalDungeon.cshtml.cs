﻿using System;
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

        public IActionResult OnGet(int? dungeonID, int? fight)
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Reset")))
            {
                HttpContext.Session.Remove("Reset");
                return Redirect("./MedievalDungeon?dungeonID=1");
            }

            var dungeons = from dungeon in _context.Dungeon
                           where dungeon.RoomID == dungeonID && dungeon.WorldID == 3
                           select dungeon;

            CurrentDungeonID = dungeons.FirstOrDefault().RoomID;

            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Monster" + dungeons.FirstOrDefault().RoomID.ToString())))
            {
                dungeons.FirstOrDefault().ItemID = 0;
                dungeons.FirstOrDefault().Storyline = "A slain monster lies on the cold floor, oozing bile and monster juices. You remember slaying this not long ago as you passed through.";
            }

            if (fight == 1) // Resolve successful fight
            {
                HttpContext.Session.SetString("Monster" + dungeons.FirstOrDefault().RoomID.ToString(),"Slain");
                dungeons.FirstOrDefault().ItemID = 0;
                dungeons.FirstOrDefault().Storyline = "On the floor lays your vanquished foe. You step over the monster towards the wooden doors, and hopefully, you think, a way out.";
            }

            Dungeon = dungeons.ToList();

            if (Dungeon[0].Name == "Pit" || Dungeon[0].RoomID == 37)
            {
                if (String.IsNullOrEmpty(HttpContext.Session.GetString("Pit")))
                {
                    HttpContext.Session.SetString("Pit", "1");
                }
                else
                {
                    int pitCount = int.Parse(HttpContext.Session.GetString("Pit"));
                    try
                    {
                        pitCount++;
                    }
                    catch
                    {
                        pitCount = 1;
                    }
                    if (pitCount >= 3)
                    {
                        HttpContext.Session.Remove("Pit");
                        if (String.IsNullOrEmpty(HttpContext.Session.GetString("Compass")))
                        {
                            HttpContext.Session.SetString("Compass", "Yes");
                            Dungeon[0].Storyline = Dungeon[0].Storyline + " But just before you see a glinting compass and snag it, just managing to get it into your pocket.";
                        }
                        else if (String.IsNullOrEmpty(HttpContext.Session.GetString("Map")))
                        {
                            HttpContext.Session.SetString("Map", "Yes");
                            Dungeon[0].Storyline = Dungeon[0].Storyline + " But just before you see a scrap of paper and snag it, just managing to get it into your pocket.";
                        }
                        else if (String.IsNullOrEmpty(HttpContext.Session.GetString("Guidebook")))
                        {
                            HttpContext.Session.SetString("Guidebook", "Yes");
                            Dungeon[0].Storyline = Dungeon[0].Storyline + " But just before you see a small book and snag it, just managing to get it into your pocket.";
                        }
                    }
                    else
                    {
                        HttpContext.Session.SetString("Pit", pitCount.ToString());
                    }
                }
            }

            return Page();
        }

        public IActionResult OnPost(string door,int? sword)
        {
            if (!String.IsNullOrEmpty(door))
            {
                if (sword.HasValue)
                {
                    HttpContext.Session.Remove("Reset");
                    return Redirect("./MedievalDungeon?dungeonID=" + door.ToString() + "&" + "fight=1");
                }
                else if (door == "0") // Return to IM-Portals
                {
                    HttpContext.Session.Remove("Reset");
                    HttpContext.Session.SetString("Klorg3", "1");
                    return RedirectToPage("./TheLaboratory");
                }
                else if (door == "31") // Map room
                {
                    HttpContext.Session.Remove("Reset");
                    HttpContext.Session.SetString("Map", "Yes");
                }
                else if (door == "33") // Sword room
                {
                    HttpContext.Session.Remove("Reset");
                    HttpContext.Session.SetString("Sword", "Yes");
                }
                HttpContext.Session.Remove("Reset");
                return Redirect("./MedievalDungeon?dungeonID=" + door.ToString());
            }
            return Page();
        }
    }
}