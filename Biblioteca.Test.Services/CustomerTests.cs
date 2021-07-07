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
    public class ClientTests
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
        public void GetClientsTest()
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
            Assert.That(client.Id, Is.Not.EqualTo(Guid.Empty));
            service.DeleteClient(client.Id);
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
            Assert.AreEqual(newClient.Phone, "0722222222");
            service.DeleteClient(newClient.Id);
        }
    }
}