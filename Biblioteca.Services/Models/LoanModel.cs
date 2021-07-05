using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Services.Models
{
    public class LoanModel : BaseModel
    {
        public Guid ClientId { get; set; }
        public Guid BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual BookModel Book { get; set; }
        public virtual ClientModel Client { get; set; }
    }
}
