using Biblioteca.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Services.Services.LoanService
{
    public interface ILoanService
    {
        IEnumerable<LoanModel> GetLoans();
        LoanModel GetLoanByID(Guid loanId);
        LoanModel InsertLoan(LoanModel loan);

        LoanModel UpdateLoan(Guid loanId, LoanModel loan);

        void DeleteLoan(Guid loanId);
    }
}
