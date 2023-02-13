using Microsoft.AspNetCore.Mvc;
using Test_WebAPI_NETCore6.DatabaseContext;
using Test_WebAPI_NETCore6.DataModel;

namespace Test_WebAPI_NETCore6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly MyDatabaseContext _dbcontext;

        public AuthorController(MyDatabaseContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpGet]
        // [Route("GetBookList")]
        public async Task<IActionResult> GetAuthorList()
        {
            var authors = _dbcontext.Authors.ToList();
            List<AuthorNumberBook> books = new List<AuthorNumberBook>();
            var book = _dbcontext.Books.ToList();
            foreach (var author in authors)
            {
                var dem = 0;
                foreach (var bookBook in book)
                {
                    if(bookBook.AuthorId == author.Id)
                    {
                        dem++;
                    }
                }
                AuthorNumberBook a = new AuthorNumberBook(author.LastName + author.FirstName, dem);
                books.Add(a);

            }
            return Ok(books);
        }
        //[HttpPost]
        //// [Route("PostBook")]
        //public async Task<IActionResult> PostAuthor(Author obj)
        //{
        //    _dbcontext.Authors.Add(obj);
        //    _dbcontext.SaveChanges();

        //    return Ok(obj);
        //}
    }
}
