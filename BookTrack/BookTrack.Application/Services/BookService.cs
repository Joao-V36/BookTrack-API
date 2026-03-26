using BookTrack.Domain.Entities;
using BookTrack.Domain.Interfaces;

namespace BookTrack.Application.Services
{
    public class BookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository) 
        {
            _repository = repository;
        }

        public async Task<List<Book>> GetAll() 
        {
            return await _repository.GetAllAsync();
        }

        public async Task Create(string titulo, string autor, int pages) 
        {
            var book = new Book(titulo, autor, pages);
            await _repository.AddAsync(book);
        }

        public async Task<Book> GetById(int id) 
        {
          
            return await _repository.GetByIdAsync(id);
        }

        public async Task Update(int id, string titulo, string autor, int pages)
        {
            var book = await _repository.GetByIdAsync(id);
            if(book == null) { throw new Exception("Livro não encontrado"); }

            book.Update(titulo, autor, pages);
            await _repository.UpdateAsync(book);
        }

        public async Task Delete(int id) 
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null) { throw new Exception("Livro não encontrado"); }

            await _repository.DeleteAsync(book);
        }
    }
}
