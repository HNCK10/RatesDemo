using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RatesDemo.Data;
using RatesDemo.Models;

namespace RatesDemo.Pages.Coins
{
    public class CreateModel : PageModel
    {
        private readonly RatesDemo.Data.RatesDemoContext _context;

        public CreateModel(RatesDemo.Data.RatesDemoContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Coin Coin { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Coin == null || Coin == null)
            {
                return Page();
            }

            _context.Coin.Add(Coin);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
