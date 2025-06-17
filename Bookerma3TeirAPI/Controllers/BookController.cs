using Bookerma.BLL.Interfaces;
using Bookerma.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookerma3TeirAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IGenaricRepository<Book> _bookRepository;

        public BookController(IGenaricRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // / Get all books.
        [HttpGet(Name = ("GetBooks"))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetBooks()
        {
            var books = await _bookRepository.GetAll();
            if (books == null)
            {
                return NotFound("No books found.");
            }

            return Ok(books);
        }

        /// Get a book by its ID.
        [HttpGet("{id}", Name = ("GetBook"))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetBook(int id)
        {
            var book = await _bookRepository.GetById(id);
            if (book == null)
                return NotFound("No book found.");

            return Ok(book);
        }

        // Add a new book.
        [HttpPost(Name = ("AddBook"))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddBook([FromBody] Book book)
        {
            if (book == null || string.IsNullOrEmpty(book.Name))
            {
                return BadRequest("Invalid book data.");
            }
            await _bookRepository.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // Update an existing book (NO async)
        [HttpPut("{id}", Name = "UpdateBook")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateBook(int id, [FromBody] Book book)
        {
            if (id == 0 || id != book.Id || book == null || string.IsNullOrEmpty(book.Name))
            {
                return BadRequest("Invalid book data.");
            }

            var existingBook = _bookRepository.GetById(id).Result;  
            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Name = book.Name;
            _bookRepository.Update(existingBook);
            return NoContent();

        }


        // Delete a book (NO async)
        [HttpDelete("{id}", Name = "DeleteBook")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteBook(int id)
        {
            var book = _bookRepository.GetById(id).Result;
            if (book == null)
            {
                return NotFound("No book found.");
            }
            _bookRepository.Delete(book); // sync method
            return NoContent();
        }
    }
}
