using Biblioteca.Core.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Services.Models
{
    public class ClientModel : BaseModel
    {
        public ClientModel()
        {
            //Loan = new HashSet<Loan>();
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Loan> Loan { get; set; }
    }
}
