using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteAssignment.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            QuoteDbContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<QuoteDbContext>();
            //If there are any migrations that were not done yet this will execute them
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Quotes.Any())
            {
                context.Quotes.AddRange(
                    //This is the seed data for the first quote in the database
                    new Quotes
                    {

                        QuoteText = "The Greatest Glory of living lies not in never falling, but in rising every time we fall",
                        AuthorSpeaker = "Ralph Waldo Emerson",
                        Date = "1900",
                        Subject = "Inspirational",
                        Citation = "1900, Gems of Literature: Liberty and Patriotism, Selected and arranged by Paul DeVere, Quote Page 83, " +
                        "Gem Publishing Company, Highmore, South Dakota.",

                    }




                    );

                context.SaveChanges();
            }
        }
    }
}
