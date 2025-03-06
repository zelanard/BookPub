using BookPubDB.Data;
using BookPubDB.DTOs;
using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace BookPubDB.Repositories
{
    /// <summary>
    /// <c>BookRepository</c> provides book spesific tasks.
    /// </summary>
    /// <remarks>
    /// All methods are documented in <see cref="Repository{T}"/>
    /// </remarks>
    public class BookRepository : Repository<Book>
    {
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
        public async override Task<Book?> DeleteAsync(PublisherContext context, int? id)
        {
            Book? book = context.Books.Find(id);

            if (book == null)
                return null;

            context.Books.Remove(book);
            int changes = await context.SaveChangesAsync();

            return GetSuccessState(book, changes);
        }
        public async override Task<bool> Exists(int? id)
        {
            PublisherContext context = new();
            return context.Books.Any(x => x.Id == id);
        }
        public async override Task<List<Book>> GetAllAsync(PublisherContext context)
        {
            return context.Books.ToList<Book>();
        }
        public async override Task<Book?> GetByIdAsync(PublisherContext context, int id)
        {
            Book? book = await context.Books
                .Include(c => c.Author)
                .Include(b => b.Cover)
                .ThenInclude(d => d.Artists)
                .FirstOrDefaultAsync(x => x.Id == id);

            return book;
        }
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
