using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteAssignment.Models
{
    public interface IQuoteRepository
    {
        //Creates an Iqueryable of type quotes for the repository
        IQueryable<Quotes> Quotes { get; }
    }
}