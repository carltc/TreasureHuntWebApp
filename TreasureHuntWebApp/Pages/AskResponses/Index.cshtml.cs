using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TreasureHuntWebApp.Models;
using System.Globalization;

namespace TreasureHuntWebApp.Pages.AskResponses
{
    public class IndexModel : PageModel
    {
        private readonly TreasureHuntWebApp.Models.TreasureHuntWebAppContext _context;

        public IndexModel(TreasureHuntWebApp.Models.TreasureHuntWebAppContext context)
        {
            _context = context;
        }

        public string Question { get; set; }

        public IList<AskResponse> AskResponse { get;set; }

        public async Task OnGetAsync(string ask)
        {
            Question = ask;

            var responses = from r in _context.AskResponse
                         select r;

            CultureInfo culture = new CultureInfo("en-GB");

            if (!String.IsNullOrEmpty(ask))
            {
                responses = responses.Where(r => r.AskType != 3);
                responses = responses.Where(r => r.Question.Contains(ask));

                if (!responses.Any())
                {
                    responses = from r in _context.AskResponse
                                select r;
                    responses = responses.Where(r => r.AskType == 1);
                    responses = responses.Where(r => culture.CompareInfo.IndexOf(ask, r.Question, CompareOptions.IgnoreCase) >= 0);

                    if (!responses.Any())
                    {
                        _context.AskResponse.AddRange(
                            new AskResponse
                            {
                                Question = ask,
                                Response = "",
                                AskDate = DateTime.Now,
                                AskType = 3
                            }
                        );
                        _context.SaveChanges();

                        responses = from r in _context.AskResponse
                                        select r;
                        responses = responses.Where(r => r.AskType == 2);
                    }
                }
            }
            else
            {
                responses = responses.Where(r => r.Question.Contains("sfjahflasugdfieafhlaKBFsiegfiabsfABFIAgfs"));
            }

            AskResponse = await responses.ToListAsync();

            //AskResponse = await _context.AskResponse.ToListAsync();
        }
    }
}
