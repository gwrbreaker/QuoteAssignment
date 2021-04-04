using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteAssignment.Models
{
    public class Quotes
    {
        [Key]
        public int QuoteID { get; set; }
        [Required]
        public string QuoteText { get; set; }
        [Required]
        public string AuthorSpeaker { get; set; }
        [Required]
        public string Date { get; set; }

        public string Subject { get; set; }

        public string Citation { get; set; }

    }

}