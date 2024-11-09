using IdentityWebApi.Model.Context;
using IdentityWebApi.Model.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IdentityWebApi.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;
        }

        [HttpGet("AllBook")]
        public async Task<ActionResult<List<Book>>> GetAllBook()
        {
            var value = await _context.Books.ToListAsync();
            return Ok(value);
        }

        [HttpGet("detail/{id:int}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var value = await _context.Books.FindAsync(id);
            return Ok(value);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBook(Book book)
        {
            if (book is null)
                return NotFound();

            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var value = await _context.Books.FindAsync(id);
            if (value is null)
                return NotFound();

            _context.Books.Remove(value);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            var value = await _context.Books.FindAsync(id);
            if (value is null)
                return NotFound();

            // Güncelleme: Mevcut value nesnesinin özelliklerini güncelliyoruz
            value.Name = book.Name;
            value.Author = book.Author;
            value.PageCount = book.PageCount;

            // Değişiklikleri veritabanına kaydediyoruz
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
