using Biblioteca.Core.Data;
using Biblioteca.Core.DomainModels;
using Biblioteca.Services.Automapper;
using Biblioteca.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Biblioteca.Services.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IEnumerable<BookModel> GetBooks()
        {
            var books = bookRepository.Table.ToList();

            return books.Select(c => c.ToModel()).ToList();
        }

        public BookModel GetBookByID(Guid bookId)
        {
            var book = bookRepository.Table.Where(x => x.Id == bookId).FirstOrDefault();
            return book.ToModel();
        }

        public BookModel InsertBook(BookModel book)
        {
            try
            {
                var entity = book.ToEntity();
                bookRepository.Insert(entity);
                return entity.ToModel();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public BookModel UpdateBook(Guid bookId, BookModel book)
        {
            try
            {
                var dbEntity = bookRepository.Table.FirstOrDefault(x => x.Id == bookId);
                if (dbEntity==null)
                {
                    throw new ArgumentException("Item cannot be found");
                }
                var entity = book.ToEntity();
                bookRepository.Update(entity);
                
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

        public void DeleteBook(Guid bookId)
        {
            try
            {
                var client = bookRepository.Table.FirstOrDefault(x => x.Id == bookId);
                if (client == null)
                {
                    throw new ArgumentException("Client ID is not found!");
                }
                bookRepository.Delete(client);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
