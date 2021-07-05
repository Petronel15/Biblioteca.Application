using Biblioteca.Services.Models;
using Biblioteca.Services.Services.BookService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Web.API.Controllers
{
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }

        [Route("api/Books")]
        [HttpGet]
        public IEnumerable<BookModel> GetBooks()
        {
            return bookService.GetBooks();
        }

        [Route("api/Books/{bookId}")]
        [HttpGet]
        public BookModel GetCustomerById([FromRoute] Guid bookId)
        {
            return bookService.GetBookByID(bookId);
        }

        [Route("api/Books")]
        [HttpPost]
        public BookModel InsertBooks([FromBody] BookModel book)
        {
            return bookService.InsertBook(book);
        }

        [Route("api/Books/{bookId}")]
        [HttpPut]
        public BookModel UpdateBook([FromBody] BookModel book, [FromRoute] Guid bookId)
        {
            return bookService.UpdateBook(bookId, book);
        }

        [Route("api/Books/{bookId}")]
        [HttpDelete]
        public void DeleteBook([FromRoute] Guid bookId)
        {
            bookService.DeleteBook(bookId);
        }
    }
}
