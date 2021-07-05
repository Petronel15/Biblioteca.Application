using Biblioteca.Core.DomainModels;
using Biblioteca.Infrastructure.Data;
using Biblioteca.Services.Automapper;
using Biblioteca.Services.Services.CustomerService;

using Microsoft.EntityFrameworkCore;
using System;
using Biblioteca.Services.Models;
using Biblioteca.Services.Services.BookService;
using System.Linq;
using Biblioteca.Services.Services.LoanService;

namespace Biblioteca.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up dbContext
            var options = new DbContextOptionsBuilder<AppDbContext>(); 
            options.UseSqlServer("Server=DESKTOP-M45IA8L\\SQLEXPRESS;Database=Library;Trusted_Connection=True;");
            var dbContext = new AppDbContext(options.Options);

            // Set up automapper
            AutoMapperConfiguration.Init();
            AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();

            var clientService = new CustomerService(new EFCoreRepository<Client>(dbContext));
            var bookService = new BookService(new EFCoreRepository<Book>(dbContext));
            var loanService = new LoanService(new EFCoreRepository<Loan>(dbContext));
            //var customers = service.GetClients();
            //foreach (var Client in customers)
            //{
            //    System.Console.WriteLine(Client.FirstName + " " + Client.LastName + " Phone:" + Client.Phone);
            //}

            //var customer = service.GetClientByID(new Guid("6E2F4296-E71D-4EBC-ABC8-64B70B3B4D30"));
            //System.Console.WriteLine(customer.FirstName + " " + customer.LastName + " Phone:" + customer.Phone);

            //var books = bookService.GetBooks();
            //foreach (var book in books)
            //{
            //    System.Console.WriteLine(book.Title+", " + book.Author+", release year:"+ book.Year);
            //}

            //var book = bookService.GetBookByID(new Guid("403A84C5-61B9-453C-8C4D-2981E8F31216"));
            //System.Console.WriteLine(book.Title + ", " + book.Author + ", release year:" + book.Year);

            ClientModel newClient = new ClientModel()
            {
                FirstName = "Ionica",
                LastName = "Abc",
                Phone = "0789456123",
                Adress = "str. Lunga, nr. 4"
            };
            newClient = clientService.InsertClient(newClient);
            System.Console.WriteLine(newClient.Id + " " + newClient.FirstName + " " + newClient.Phone);
            newClient.Phone = "0722222222";
            newClient = clientService.UpdateClient(newClient.Id, newClient);
            System.Console.WriteLine(newClient.Id + " " + newClient.FirstName + " " + newClient.Phone);
            //var newClient = clientService.GetClients().FirstOrDefault();
            //System.Console.WriteLine(newClient.Id + " " + newClient.FirstName + " " + newClient.Phone);
            //newClient.Phone = "0741852963";
            //newClient = clientService.UpdateClient(newClient.Id.Value, newClient);
            //System.Console.WriteLine(newClient.Id + " " + newClient.FirstName + " " + newClient.Phone);

            //var clints = clientService.GetClients().ToList();
            //var loans = loanService.GetLoans().ToList();
            //var clientLoan = from client in clints
            //                 join loan in loans on client.Id equals loan.ClientId
            //                 select new { ClientName = client.FirstName, LoanDate = loan.LoanDate };
            //foreach (var result in clientLoan)
            //{
            //    System.Console.WriteLine("Client name: " + result.ClientName + ", Loan date: " + result.LoanDate);
            //}

            //clientService.DeleteClient(newClient.Id);
        }
    }
}
