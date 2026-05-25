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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
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

        [HttpPut]
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
            _context.Books.Update(book);
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

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] Book book)
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
            _context.Books.Remove(book);
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
    }
}
