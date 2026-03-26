using BookTrack.Application.DTOs;
using BookTrack.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookTarck_API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _service;

        public BooksController(BookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            return Ok(await _service.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post(BookDto dto) 
        {
            await _service.Create(dto.Titulo, dto.Autor, dto.TotalPages);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _service.GetById(id);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateBookDto dto)
        {
            await _service.Update(id, dto.Titulo, dto.Autor, dto.TotalPages);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}
