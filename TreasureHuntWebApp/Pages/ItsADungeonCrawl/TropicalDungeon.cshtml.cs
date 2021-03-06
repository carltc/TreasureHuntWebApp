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
    public class TropicalDungeonModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public TropicalDungeonModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public IList<Dungeon> Dungeon { get; set; }
        public int CurrentDungeonID { get; set; }

        public IActionResult OnGet(int? dungeonID,int? fight)
        {
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("Reset")))
            {
                HttpContext.Session.Remove("Reset");
                return Redirect("./TropicalDungeon?dungeonID=2");
            }

            var dungeons = from dungeon in _context.Dungeon
                           where dungeon.RoomID == dungeonID && dungeon.WorldID == 1
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
                dungeons.FirstOrDefault().Storyline = "On the ground lays your vanquished foe. You step over the monster towards some caves, and hopefully, you think, a way out.";
            }
            
            if (dungeonID == 29 && !String.IsNullOrEmpty(HttpContext.Session.GetString("Fish"))) // Entice Korg out with fish
            {
                dungeons.FirstOrDefault().Storyline = "As soon as you emerge into the bay you are pounced upon by a little creature. The Korg pup was enticed out by the smell of the fish you are carrying. You see the Korg pup has a collar with a flashing light on it...";
            }

            Dungeon = dungeons.ToList();

            if (Dungeon[0].Name == "Quicksand" || Dungeon[0].RoomID == 37)
            {
                if (String.IsNullOrEmpty(HttpContext.Session.GetString("Quicksand")))
                {
                    HttpContext.Session.SetString("Quicksand", "1");
                }
                else
                {
                    int quicksandCount = int.Parse(HttpContext.Session.GetString("Quicksand"));
                    try
                    {
                        quicksandCount++;
                    }
                    catch
                    {
                        quicksandCount = 1;
                    }
                    if (quicksandCount >= 3)
                    {
                        HttpContext.Session.Remove("Quicksand");
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
                        HttpContext.Session.SetString("Quicksand", quicksandCount.ToString());
                    }
                }
            }

            return Page();
        }

        public IActionResult OnPost(string door,int? sword, int? rod)
        {
            if (!String.IsNullOrEmpty(door))
            {
                if (sword.HasValue)
                {
                    HttpContext.Session.Remove("Reset");
                    return Redirect("./TropicalDungeon?dungeonID=" + door.ToString() + "&" + "fight=1");
                }
                else if (door == "0") // Return to IM-Portals
                {
                    HttpContext.Session.Remove("Reset");
                    HttpContext.Session.SetString("Klorg1", "1");
                    return RedirectToPage("./TheLaboratory");
                }
                else if (door == "27") // Map room
                {
                    HttpContext.Session.Remove("Reset");
                    HttpContext.Session.SetString("Map", "Yes");
                }
                else if (door == "13") // Sword room
                {
                    HttpContext.Session.Remove("Reset");
                    HttpContext.Session.SetString("Sword", "Yes");
                }
                else if (door == "19") // Rod room
                {
                    HttpContext.Session.Remove("Reset");
                    HttpContext.Session.SetString("Rod", "Yes");
                }
                else if (rod.HasValue) // Fishing catch
                {
                    HttpContext.Session.Remove("Reset");
                    HttpContext.Session.SetString("Fish", "Yes");
                }
                HttpContext.Session.Remove("Reset");
                return Redirect("./TropicalDungeon?dungeonID=" + door.ToString());
            }
            return Page();
        }
    }
}