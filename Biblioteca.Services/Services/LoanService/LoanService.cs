using Biblioteca.Core.Data;
using Biblioteca.Core.DomainModels;
using Biblioteca.Services.Automapper;
using Biblioteca.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Services.Services.LoanService
{
    public class LoanService : ILoanService
    {
        private readonly IRepository<Loan> loanRepository;
        public LoanService(IRepository<Loan> loanRepository)
        {
            this.loanRepository = loanRepository;
        }

        public void DeleteLoan(Guid loanId)
        {
            try
            {
                var loan = loanRepository.GetById(loanId);
                if (loan == null)
                {
                    throw new ArgumentException("Client ID is not found!");
                }
                loanRepository.Delete(loan);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public LoanModel GetLoanByID(Guid loanId)
        {
            var loan = loanRepository.Table.Where(x => x.Id == loanId).FirstOrDefault();
            return loan.ToModel();
        }

        public IEnumerable<LoanModel> GetLoans()
        {
            var loans = loanRepository.Table.ToList();

            return loans.Select(c => c.ToModel()).ToList();
        }

        public LoanModel InsertLoan(LoanModel loan)
        {
            try
            {
                var entity = loan.ToEntity();
                loanRepository.Insert(entity);
                return entity.ToModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public LoanModel UpdateLoan(Guid loanId, LoanModel loan)
        {
            try
            {
                var entity = loan.ToEntity();
                var dbEntity = loanRepository.Table.FirstOrDefault(x => x.Id == loanId);
                if (dbEntity != null)
                {
                    dbEntity.LoanDate = loan.LoanDate;
                    dbEntity.ReturnDate = loan.ReturnDate;
                    
                    loanRepository.Update(dbEntity);
                }
                // return GetClientByID(clientId);
                return entity.ToModel();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                // close connection
            }
        }
    }
}
