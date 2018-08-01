using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace SeniorProjectWebApplication.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SeniorProjectWebApplicationContext(
                serviceProvider.GetRequiredService<DbContextOptions<SeniorProjectWebApplicationContext>>()))
            {
                // Look for any movies.
                if (context.Measurement.Any())
                {
                    return;   // DB has been seeded
                }

                context.Measurement.AddRange(
                    new Measurement
                    {
                        UserName = "Johnny",
                        SessionNumber = 1234,
                        Date = DateTime.Parse("1989-2-12"),
                        Pressure = 7.99F
                    },

                    new Measurement
                    {
                        UserName = "Johnny",
                        SessionNumber = 1234,
                        Date = DateTime.Parse("1989-2-12"),
                        Pressure = 7.3544F
                    },

                    new Measurement
                    {
                        UserName = "Johnny",
                        SessionNumber = 1234,
                        Date = DateTime.Parse("1989-2-12"),
                        Pressure = 8.1611F
                    },

                    new Measurement
                    {
                        UserName = "Becky",
                        SessionNumber = 4466,
                        Date = DateTime.Parse("1989-2-12"),
                        Pressure = 5354F
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
