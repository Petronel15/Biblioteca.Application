using AutoMapper;
using Biblioteca.Core.DomainModels;
using Biblioteca.Services.Models;

namespace Biblioteca.Services.Automapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ClientModel, Client>()
                .ForMember(x=>x.Loan, d=>d.Ignore());
            CreateMap<Client, ClientModel>();
            CreateMap<BookModel, Book>()
                .ForMember(x => x.Loan, d => d.Ignore());
            CreateMap<Book, BookModel>();
            CreateMap<LoanModel, Loan>()
                .ForMember(x => x.Client, d => d.Ignore())
                .ForMember(x=>x.Book, d=>d.Ignore());
            CreateMap<Loan, LoanModel>()
                .ForMember(x => x.BookName, d => d.MapFrom(c => c.Book.Title))
                .ForMember(x => x.ClientName, d => d.MapFrom(c => c.Client.FirstName+" "+c.Client.LastName));

        }
    }
}
