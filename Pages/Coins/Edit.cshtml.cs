using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RatesDemo.Data;
using RatesDemo.Models;

namespace RatesDemo.Pages.Coins
{
    public class EditModel : PageModel
    {
        private readonly RatesDemo.Data.RatesDemoContext _context;

        public EditModel(RatesDemo.Data.RatesDemoContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coin Coin { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Coin == null)
            {
                return NotFound();
            }

            var coin =  await _context.Coin.FirstOrDefaultAsync(m => m.Id == id);
            if (coin == null)
            {
                return NotFound();
            }
            Coin = coin;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Coin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoinExists(Coin.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CoinExists(int id)
        {
          return (_context.Coin?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
