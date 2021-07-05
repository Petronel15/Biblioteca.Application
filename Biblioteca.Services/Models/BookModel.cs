using Biblioteca.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Services.Models
{
    public class BookModel : BaseModel
    {
        public BookModel()
        {
            //Loan = new HashSet<Loan>();
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Loan> Loan { get; set; }
    }
}
