using Biblioteca.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Core.DomainModels
{
    public class Loan : BaseEntity
    {
        public Guid ClientId { get; set; }
        public Guid BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual Client Client { get; set; }
    }
}
