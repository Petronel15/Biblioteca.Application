using Biblioteca.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Services.Services.BookService
{
    public interface IBookService
    {
        IEnumerable<BookModel> GetBooks();
        BookModel GetBookByID(Guid bookId);
        BookModel InsertBook(BookModel book);

        BookModel UpdateBook(Guid bookId, BookModel book);

        void DeleteBook(Guid bookId);
    }
}
