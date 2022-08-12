using Microsoft.AspNetCore.Mvc;
using RepsitoryPatternWithUOW.Core.Interfaces;
using RepsitoryPatternWithUOW.Core.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepsitoryPatternWithUOW.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }

        [HttpGet("GetAllBooksAsync")]
        public async Task<IActionResult> GetAllBooksAsync()
        {
            return Ok(await _unitOfWork.Books.GetAll());
        }
        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "sara", new[] {"Author"} ));
        }
        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title == "sara", new[] { "Author" }));
        }
        [HttpGet("GetAllContains")]
        public IActionResult GetAllContains()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("a"), new[] { "Author" }));
        }

        [HttpPost]
        public IActionResult AddBooks([FromBody]Book books)
        {
            _unitOfWork.Books.AddEntity(books);
            return Ok(books);
        }

        [HttpPut("bookId")]
        public IActionResult UpdateBooks([FromBody] Book book)
        {
            _unitOfWork.Books.UpdateEntity(book);
            _unitOfWork.Complete();
            return Ok(book);
        }

        [HttpDelete("bookId")]
        public IActionResult DeleteBooks(int bookId)
        {
           var thisbook = _unitOfWork.Books.Find(b => b.Id == bookId);
            _unitOfWork.Books.DeleteEntity(thisbook);
            _unitOfWork.Complete();
            return Ok(thisbook);
        }

    }
}
