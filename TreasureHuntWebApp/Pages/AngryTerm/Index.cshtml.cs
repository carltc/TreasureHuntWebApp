using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;
using Microsoft.AspNetCore.Http;

namespace TreasureHuntWebApp.Pages.AngryTerm
{
    public class IndexModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public IndexModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Temp { get; set; }
            //= "          "
            //+ "          "
            //+ "          "
            //+ "          "
            //+ "          ";

        [BindProperty]
        public CrossWord CrossWord { get; set; }

        //public void OnGet()
        //{
            //var rMax = (from max in _context.CrossWord.OrderByDescending(i => i.Row)
            //            select new { max }).First();
            //var cMax = (from max in _context.CrossWord.OrderByDescending(i => i.Column)
            //            select new { max }).First();

            //for (int i = 0; i < cMax.max.Column; i++)
            //{
            //    for (int j = 0; j < rMax.max.Row; j++)
            //    {
            //        string cellID = "r" + (j + 1).ToString() + "c" + (i + 1).ToString();
            //        var word = HttpContext.Session.GetString(cellID);
            //    }
            //}

            //if (_context.Temp == null)
            //{
            //    Temp = "          "
            //    + "          "
            //    + "          "
            //    + "          "
            //    + "          ";
            //}
            //else
            //{
            //    Temp = _context.Temp;
            //}
        //}

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool wrong = false;

            //_context.Temp = Temp;
            //_context.SaveChanges();

            var rMax = (from max in _context.CrossWord.OrderByDescending(i => i.Row)
                    select new { max }).First();
            var cMax = (from max in _context.CrossWord.OrderByDescending(i => i.Column)
                     select new { max }).First();

            for (int i = 0; i < cMax.max.Column; i++)
            {
                for (int j = 0; j < rMax.max.Row; j++)
                {
                    string cellID = "r" + (j + 1).ToString() + "c" + (i + 1).ToString();
                    var cell = Request.Form[cellID];
                    if (cell.Count() > 0)
                    {
                        var word = cell.ToString();
                        HttpContext.Session.SetString(cellID, word);

                        char letter = word.FirstOrDefault();
                        var checkLetter = (from lRow in _context.CrossWord.Where(r => r.Row == j+1 && r.Column == i+1)
                                           select lRow.Letter).FirstOrDefault();
                        if (Char.ToLowerInvariant(checkLetter) == Char.ToLowerInvariant(letter))
                        {
                            wrong = false;
                        }
                        else
                        {
                            wrong = true;
                        }
                    }
                }
            }

            if (wrong)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("./YayouDidIt");
            }
        }
    }
}
