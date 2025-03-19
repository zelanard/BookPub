using BookPubDB.Data;
using BookPubDB.DTOs;
using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace BookPubDB.Repositories
{

    /// <include file = 'Documentation/Repositories/BookRepository.xml' path='doc/bookrepository/member[@name="T:BookPubDB.Repositories.BookRepository"]' />
    public class BookRepository : Repository<Book>
    {
        /// <include file = 'Documentation/Repositories/BookRepository.xml' path='doc/bookrepository/member[@name="M:BookPubDB.Repositories.BookRepository.CreateAsync"]' />
        public async override Task<Book?> CreateAsync(PublisherContext context, object data)
        {
            var bookDto = JsonConvert.DeserializeObject<BookDto>(data.ToString());

            Book book = new();
            book.MapDto(bookDto);

            Log.Information("Creating Book: {Book}", data);
            await context.Books.AddAsync(book);
            int changes = await context.SaveChangesAsync();

            return GetSuccessState(book, changes);
        }

        /// <include file = 'Documentation/Repositories/BookRepository.xml' path='doc/bookrepository/member[@name="M:BookPubDB.Repositories.BookRepository.DeleteAsync"]' />
        public async override Task<Book?> DeleteAsync(PublisherContext context, int? id)
        {
            Book? book = context.Books.Find(id);

            if (book == null)
                return null;

            context.Books.Remove(book);
            int changes = await context.SaveChangesAsync();

            return GetSuccessState(book, changes);
        }

        /// <include file = 'Documentation/Repositories/BookRepository.xml' path='doc/bookrepository/member[@name="M:BookPubDB.Repositories.BookRepository.Exists(System.Int32?)"]' />
        public async override Task<bool> Exists(int? id)
        {
            PublisherContext context = new();
            return context.Books.Any(x => x.Id == id);
        }

        /// <include file = 'Documentation/Repositories/BookRepository.xml' path='doc/bookrepository/member[@name="M:BookPubDB.Repositories.BookRepository.GetAllAsync"]' />
        public async override Task<List<Book>> GetAllAsync(PublisherContext context)
        {
            return context.Books.ToList<Book>();
        }

        /// <include file = 'Documentation/Repositories/BookRepository.xml' path='doc/bookrepository/member[@name="M:BookPubDB.Repositories.BookRepository.GetByIdAsync"]' />
        public async override Task<Book?> GetByIdAsync(PublisherContext context, int id)
        {
            Book? book = await context.Books
                .Include(c => c.Author)
                .Include(b => b.Cover)
                .ThenInclude(d => d.Artists)
                .FirstOrDefaultAsync(x => x.Id == id);

            return book;
        }

        /// <include file = 'Documentation/Repositories/BookRepository.xml' path='doc/bookrepository/member[@name="M:BookPubDB.Repositories.BookRepository.UpdateAsync"]' />
        public async override Task<Book?> UpdateAsync(PublisherContext context, int id, object itemDto)
        {
            try
            {
                var dto = JsonConvert.DeserializeObject<BookDto>(itemDto.ToString());

                var itemToUpdate = context.Books
                    .Include(c => c.Author)
                    .FirstOrDefaultAsync(x => x.Id == id).Result;

                itemToUpdate.MapDto(dto);
                int changes = await context.SaveChangesAsync();
                return GetSuccessState(itemToUpdate, changes);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Update failed: {Error}", ex.Message);
                return null;
            }
        }
    }
}
