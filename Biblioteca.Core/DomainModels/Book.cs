using Biblioteca.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Core.DomainModels
{
    public class Book : BaseEntity
    {
        public Book()
        {
            Loan = new HashSet<Loan>();
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Loan> Loan { get; set; }
    }
}
