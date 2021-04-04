using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteAssignment.Models
{
    public class EFQuoteRepository : IQuoteRepository
    {
        private QuoteDbContext _context;

        //Constructor
        public EFQuoteRepository(QuoteDbContext context)
        {
            _context = context;
        }
        public IQueryable<Quotes> Quotes => _context.Quotes;
    }
}
