using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_WebAPI_NETCore6.DatabaseContext;
using Test_WebAPI_NETCore6.DataModel;

namespace Test_WebAPI_NETCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly MyDatabaseContext _dbcontext;

        public BookController(MyDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpGet]
       // [Route("GetBookList")]
        public async Task<IActionResult> GetBookList()
        {
            return Ok(_dbcontext.Books.ToList());
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _dbcontext.Books.FindAsync(id);


            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
       // [Route("PostBook")]
        public async Task<IActionResult> PostBook(Book obj)
        {
            Book book = new Book();
            book.Id = obj.Id;
            book.Title = obj.Title;
            book.Description = obj.Description;
            book.PublishDay = obj.PublishDay;
            book.Price = obj.Price;
            book.AuthorBook = obj.AuthorBook;

            _dbcontext.Books.Add(book);
            _dbcontext.SaveChanges();

            return Ok(book);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            _dbcontext.Entry(book).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _dbcontext.Books!.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _dbcontext.Books.Remove(book);
            await _dbcontext.SaveChangesAsync();

            return NoContent();
        }
        private bool BookExists(int id)
        {
            return _dbcontext.Books!.Any(e => e.Id == id);
        }

    }
}
