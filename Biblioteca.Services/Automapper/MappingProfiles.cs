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
                .ForMember(x => x.Client, d => d.Ignore());
            CreateMap<Loan, LoanModel>();

        }
    }
}
