using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RatesDemo.Models;

namespace RatesDemo.Data
{
    public class RatesDemoContext : DbContext
    {
        public RatesDemoContext (DbContextOptions<RatesDemoContext> options)
            : base(options)
        {
        }

        public DbSet<RatesDemo.Models.Coin> Coin { get; set; } = default!;
    }
}
