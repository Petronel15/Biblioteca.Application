using Biblioteca.Core.Data;
using Biblioteca.Core.DomainModels;
using Biblioteca.Infrastructure.Data;
using Biblioteca.Services.Automapper;
using Biblioteca.Services.Models;
using Biblioteca.Services.Services.BookService;
using Biblioteca.Services.Services.CustomerService;
using Biblioteca.Services.Services.LoanService;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Linq;

namespace Biblioteca.Test.Services
{
    public class Tests
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
        public void GetCustomersTest()
        {
            var service = new CustomerService(new EFCoreRepository<Client>(dbContext));
            var customers = service.GetClients().ToList();

            Assert.That(customers.Count, Is.GreaterThan(0));
        }

        [Test]
        public void InsertClientTest()
        {
            // arrange
            var service = new CustomerService(new EFCoreRepository<Client>(dbContext));
            ClientModel newClient = new ClientModel()
            {
                FirstName = "Ionica",
                LastName = "Abc",
                Phone = "0789456123",
                Adress = "str. Lunga, nr. 4"
            };

            // act
            ClientModel client = service.InsertClient(newClient);

            // assert
            //Assert.That(Is.Equals(client,newClient));
            //Assert.AreEqual(newClient, client);
            Assert.That(client.Id, Is.Not.EqualTo(Guid.Empty));
            //Assert.That(newClient.FirstName, Is.EqualTo(client.FirstName));
        }

        [Test]
        public void UpdateClientTest()
        {
            // arrange
            var service = new CustomerService(new EFCoreRepository<Client>(dbContext));
            ClientModel newClient = new ClientModel()
            {
                FirstName = "Ionica",
                LastName = "Abc",
                Phone = "0789456123",
                Adress = "str. Lunga, nr. 4"
            };
            newClient = service.InsertClient(newClient);
            System.Console.WriteLine(newClient.Id + " " + newClient.FirstName + " " + newClient.Phone);
            newClient.Phone = "0722222222";

            // act
            newClient = service.UpdateClient(newClient.Id, newClient);

            // assert
            //Assert.That(Is.Equals("0722222222", newClient.Phone));
            Assert.AreEqual(newClient.Phone, "0722222222");
        }

        [Test]
        public void GetBooksTest()
        {
            var service = new BookService(new EFCoreRepository<Book>(dbContext));
            var books = service.GetBooks().ToList();

            Assert.That(books.Count, Is.GreaterThan(0));
        }

        [Test]
        public void GetLoansTest()
        {
            var service = new LoanService(new EFCoreRepository<Loan>(dbContext));
            var loans = service.GetLoans().ToList();

            Assert.That(loans.Count, Is.GreaterThan(0));
        }

        [Test]
        public void InsertBookTest()
        {
            // arrange
            var service = new BookService(new EFCoreRepository<Book>(dbContext));
            BookModel newBook = new BookModel()
            {
                Author="Kent Beck",
                Title = "TDD by example",
                Publisher = "Epublio",
                Year = 2015
            };

            // act
            BookModel book = service.InsertBook(newBook);

            // assert
            Assert.That(book.Id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void InsertLoanTest()
        {
            // arrange
            var service = new LoanService(new EFCoreRepository<Loan>(dbContext));
            LoanModel newLoan = new LoanModel()
            {
                Id = Guid.Parse("11B5EED6-AAAA-5555-B7AB-38F21D3243F0"),
                LoanDate = DateTime.Parse("5/1/2009"),
                ReturnDate = DateTime.Parse("10/2/2010"),
                ClientId= Guid.Parse("11B5EED6-3B49-4691-B7AB-38F21D3243F0"),
                BookId= Guid.Parse("C2A0C985-2F77-4F43-B489-C236474315F2")
            };

            // act
            LoanModel loan = service.InsertLoan(newLoan);

            // assert
            Assert.That(loan.Id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void DeleteClientTest()
        {
            // arrange
            var service = new BookService(new EFCoreRepository<Book>(dbContext));
            BookModel newBook = new BookModel()
            {
                Author = "Kent Beck",
                Title = "TDD by example",
                Publisher = "Epublio",
                Year = 2015
            };

            // act
            BookModel book = service.InsertBook(newBook);

            // assert
            Assert.That(book.Id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}