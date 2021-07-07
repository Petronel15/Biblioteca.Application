using Biblioteca.Core.Data;
using Biblioteca.Core.DomainModels;
using Biblioteca.Infrastructure.Data;
using Biblioteca.Services.Automapper;
using Biblioteca.Services.Models;
using Biblioteca.Services.Services.BookService;
using Biblioteca.Services.Services.LoanService;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Test.Services
{
    class BookTests
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
        public void GetBooksTest()
        {
            var service = new BookService(new EFCoreRepository<Book>(dbContext));
            var books = service.GetBooks().ToList();

            Assert.That(books.Count, Is.GreaterThan(0));
        }

        [Test]
        public void InsertBookTest()
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
            service.DeleteBook(book.Id);
        }

        [Test]
        public void UpdateBookTest()
        {
            // arrange
            var service = new BookService(new EFCoreRepository<Book>(dbContext));
            BookModel newBook = new BookModel()
            {
                Title = "C# volumul 1",
                Author = "Roberto Mancini",
                Publisher = "Publish",
                Year = 1998
            };
            newBook = service.InsertBook(newBook);
            newBook.Title = "C# volumul 2";

            // act
            newBook = service.UpdateBook(newBook.Id, newBook);

            // assert
            //Assert.That(Is.Equals("0722222222", newClient.Phone));
            Assert.AreEqual(newBook.Title, "C# volumul 2");
            service.DeleteBook(newBook.Id);
        }
    }
}
