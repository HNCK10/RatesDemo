using RatesDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace RatesDemo.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RatesDemoContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RatesDemoContext>>()))
            {
                if (context == null || context.Coin == null)
                {
                    throw new ArgumentNullException("Null RatesDemoContext");
                }

                if (context.Coin.Any())
                {
                    return;
                }
                context.Coin.AddRange(
                    new Coin
                    {
                        Name = "BTC",
                        Price = 21482
                    },
                    new Coin
                    {
                        Name = "ETH",
                        Price = 1649
                    },
                    new Coin
                    {
                        Name = "IOTA",
                        Price = 0.296M
                    },
                    new Coin
                    {
                        Name = "ADA",
                        Price = 0.46M
                    });
                    context.SaveChanges();
            }
        }
    }
}
