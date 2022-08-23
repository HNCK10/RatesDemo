using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RatesDemo.Data;
using RatesDemo.Models;

namespace RatesDemo.Pages.Coins
{
    public class IndexModel : PageModel
    {
        private readonly RatesDemo.Data.RatesDemoContext _context;

        public IndexModel(RatesDemo.Data.RatesDemoContext context)
        {
            _context = context;
        }

        public IList<Coin> Coin { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Coin != null)
            {
                Coin = await _context.Coin.ToListAsync();
            }
        }
    }
}
