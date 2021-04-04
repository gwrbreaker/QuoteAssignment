using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteAssignment.Models
{
    public class QuoteDbContext : DbContext
    {
        //This is where the database context of type database context is passed to the base
        public QuoteDbContext(DbContextOptions<QuoteDbContext> options) : base(options)
        {

        }
        //Get and set the Database set of type quotes
        public DbSet<Quotes> Quotes { get; set; }
    }
}
