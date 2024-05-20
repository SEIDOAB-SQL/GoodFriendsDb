using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class csQuote
    {
        [Key]
        public Guid QuoteId { get; set; }

        public string Quote { get; set; }
        public string Author { get; set; }

        //Navigation props
        public List<csFriend> Friends { get; set; }

        //constructor
        public csQuote()
        {
            QuoteId = Guid.NewGuid();
        }
    }
}
