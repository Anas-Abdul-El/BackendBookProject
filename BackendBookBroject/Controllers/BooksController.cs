using BackendBookBroject.Data;
using BackendBookBroject.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendBookBroject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            if (books == null || books.Count == 0)
            {
                return NoContent();
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] Book book)
        {
            _context.Books.Add(book);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> updateUser([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null");
            }

            var existingUser = await _context.Books.FindAsync(book.BookId);
            if (existingUser == null)
            {
                return NotFound("Book Not Found");
            }
            //_context.Books.Update(book);
            existingUser.Title = book.Title;
            existingUser.Author = book.Author;
            existingUser.Quantity = book.Quantity;
            existingUser.Isbn = book.Isbn;
            existingUser.IsBorrowed = book.IsBorrowed;
            try
            {
                await _context.SaveChangesAsync();
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                
                return NotFound("Book Not Found");
            }
            _context.Books.Remove(existingBook);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(existingBook);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
