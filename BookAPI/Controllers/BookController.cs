using BookAPI.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetBooks()
        {
            return BookService.GetBooks();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = BookService.GetBook(id);
            if (book is null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            if (book is null)
            {
                return BadRequest("Kitap bilgisi eksik.");
            }
            BookService.AddBook(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Book b)
        {
            var book = BookService.GetBook(id);

            if (book is null)
                return NotFound();


            b.Id = book.Id;
            BookService.UpdateBook(b);
            return Ok();

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = BookService.GetBook(id);
            if (book is null)
                return NotFound();

            BookService.DeleteBook(id);

            return Ok();

        }

    }
}
