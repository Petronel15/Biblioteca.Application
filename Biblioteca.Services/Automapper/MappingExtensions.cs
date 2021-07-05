using AutoMapper;
using Biblioteca.Core.DomainModels;
using Biblioteca.Services.Models;

namespace Biblioteca.Services.Automapper
{
    public static class MappingExtensions
    {
        private static readonly IMapper mapper = AutoMapperConfiguration.Mapper;

        public static ClientModel ToModel(this Client entity)
        {
            return mapper.Map<ClientModel>(entity);
        }
        
        public static Client ToEntity(this ClientModel model)
        {
            return mapper.Map<Client>(model);
        }

        public static BookModel ToModel(this Book entity)
        {
            return mapper.Map<BookModel>(entity);
        }

        public static Book ToEntity(this BookModel model)
        {
            return mapper.Map<Book>(model);
        }

        public static LoanModel ToModel(this Loan entity)
        {
            return mapper.Map<LoanModel>(entity);
        }

        public static Loan ToEntity(this LoanModel model)
        {
            return mapper.Map<Loan>(model);
        }
    }
}
