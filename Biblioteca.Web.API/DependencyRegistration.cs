using Biblioteca.Core.Data;
using Biblioteca.Infrastructure.Data;
using Biblioteca.Services.Models;
using Biblioteca.Services.ModelsValidator;
using Biblioteca.Services.Services.BookService;
using Biblioteca.Services.Services.CustomerService;
using Biblioteca.Services.Services.LoanService;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Web
{
    public class DependencyRegistration
    {
        /// <summary>
        /// Register services
        /// </summary>
        /// <param name="builder"></param>
        public void Register(IServiceCollection builder)
        {
            //Per request lifetime
            
            //Singleton services

            //Transient services
            builder.AddTransient(typeof(IRepository<>), typeof(EFCoreRepository<>));
            builder.AddTransient<ICustomersService, CustomerService>();
            builder.AddTransient<IBookService, BookService>();
            builder.AddTransient<ILoanService, LoanService>();
            builder.AddTransient<IValidator<ClientModel>, ClientValidator>();
            builder.AddTransient<IValidator<BookModel>, BookValidator>();
            builder.AddTransient<IValidator<LoanModel>, LoanValidator>();
        }
    }
}
