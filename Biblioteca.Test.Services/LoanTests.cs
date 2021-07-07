using Biblioteca.Core.Data;
using Biblioteca.Core.DomainModels;
using Biblioteca.Infrastructure.Data;
using Biblioteca.Services.Automapper;
using Biblioteca.Services.Models;
using Biblioteca.Services.Services.LoanService;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Test.Services
{
    class LoanTests
    {
        IDbContext dbContext;

        [OneTimeSetUp]
        public void Setup()
        {
            // Set up dbContext
            var options = new DbContextOptionsBuilder<AppDbContext>();
            options.UseSqlServer("Server=DESKTOP-M45IA8L\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
            dbContext = new AppDbContext(options.Options);

            // Set up automapper
            AutoMapperConfiguration.Init();
            AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();
        }

        [Test]
        public void GetLoansTest()
        {
            var service = new LoanService(new EFCoreRepository<Loan>(dbContext));
            var loans = service.GetLoans().ToList();

            Assert.That(loans.Count, Is.GreaterThan(0));
        }

        [Test]
        public void InsertLoanTest()
        {
            // arrange
            var service = new LoanService(new EFCoreRepository<Loan>(dbContext));
            LoanModel newLoan = new LoanModel()
            {
               //Id = Guid.Parse("11B5EED6-AAAA-5555-B7AB-38F21D3243F0"),
                LoanDate = DateTime.Parse("5/1/2009"),
                ReturnDate = DateTime.Parse("10/2/2010"),
                ClientId = Guid.Parse("11B5EED6-3B49-4691-B7AB-38F21D3243F0"),
                BookId = Guid.Parse("C2A0C985-2F77-4F43-B489-C236474315F2")
            };

            // act
            LoanModel loan = service.InsertLoan(newLoan);

            // assert
            Assert.That(loan.Id, Is.Not.EqualTo(Guid.Empty));
            service.DeleteLoan(loan.Id);
        }

        [Test]
        public void UpdateLoanTest()
        {
            // arrange
            var service = new LoanService(new EFCoreRepository<Loan>(dbContext));
            LoanModel newLoan = new LoanModel()
            {
                LoanDate = DateTime.Parse("5/1/2009"),
                ReturnDate = DateTime.Parse("10/2/2010"),
                ClientId = Guid.Parse("11B5EED6-3B49-4691-B7AB-38F21D3243F0"),
                BookId = Guid.Parse("C2A0C985-2F77-4F43-B489-C236474315F2")
            };
            newLoan = service.InsertLoan(newLoan);
            newLoan.LoanDate = DateTime.Parse("6/6/2009");

            // act
            newLoan = service.UpdateLoan(newLoan.Id, newLoan);

            // assert
            //Assert.That(Is.Equals("0722222222", newClient.Phone));
            Assert.AreEqual(newLoan.LoanDate, DateTime.Parse("6/6/2009"));
            service.DeleteLoan(newLoan.Id);
        }
    }
}
