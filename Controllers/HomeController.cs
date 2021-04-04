using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuoteAssignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private QuoteDbContext _context;
        private IQuoteRepository _repository;


        public HomeController(ILogger<HomeController> logger, QuoteDbContext context, IQuoteRepository repository)
        {
            _logger = logger;
            _context = context;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterQuote()
        {
            return View();
        }
        //returns the current quotes in the database (there is only 1 by default)
        public IActionResult QuoteList()
        {
            IEnumerable<Quotes> quotes;

            quotes = _context.Quotes.OrderBy(q => q.QuoteText);

            return View("QuoteList", quotes);
        }

        //This view takes the data entered into the form, saves it to the database, and then displays the confirmation page
        [HttpPost]
        public IActionResult enterQuote(Quotes quotes)
        {
            if (ModelState.IsValid)
            {
                _context.Quotes.Add(quotes);
                _context.SaveChanges();
            }

            return View("Confirmation", quotes);
        }


        //Returns a form with all the info from the current database in it
        [HttpPost]
        public IActionResult EditForm(int QuoteID)
        {
            IEnumerable<Quotes> quotes;
            quotes = _repository.Quotes.Where(q => q.QuoteID == QuoteID);

            return View("EditForm", quotes.First());
        }

        //Updates the quote
        [HttpPost]
        public IActionResult QuoteUpdate(Quotes quotes)
        {
            IEnumerable<Quotes> Quotes;

            _context.Quotes.Update(quotes);
            _context.SaveChanges();



            Quotes = _context.Quotes.OrderBy(q => q.QuoteText);

            return View("QuoteList", Quotes);
        }

        //Deletes the quote
        [HttpPost]
        public IActionResult DeleteQuote(int QuoteID)
        {
            IEnumerable<Quotes> quote;

            quote = _repository.Quotes.Where(q => q.QuoteID == QuoteID);

            _context.Remove(quote.First());
            _context.SaveChanges();

            IEnumerable<Quotes> quotes;

            quotes = _context.Quotes.OrderBy(q => q.QuoteText);

            return View("QuoteList", quotes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
