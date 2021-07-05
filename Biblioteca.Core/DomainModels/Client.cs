using Biblioteca.Core.Data;
using System.Collections.Generic;

namespace Biblioteca.Core.DomainModels
{
    public class Client : BaseEntity
    {
        public Client()
        {
            Loan = new HashSet<Loan>();
        }

        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Loan> Loan { get; set; }
    }
}
