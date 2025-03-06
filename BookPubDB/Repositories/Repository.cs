using BookPubDB.Data;
using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using System.Formats.Tar;

namespace BookPubDB.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        public abstract Task<T?> CreateAsync(PublisherContext context, object model);
        public abstract Task<T?> DeleteAsync(PublisherContext context, int? id);
        public abstract Task<bool> Exists(int? id);
        public abstract Task<List<T>> GetAllAsync(PublisherContext context);
        public abstract Task<T?> GetByIdAsync(PublisherContext context, int id);
        public abstract Task<T?> UpdateAsync(PublisherContext context, int id, object itemDto);

        protected static T? GetSuccessState(T? model, int changes)
        {
            if (changes > 0 && model != null)
            {
                return model;
            }
            else
            {
                return default;
            }
        }

        protected async void AddArtistsToCover(PublisherContext context, List<int> artists)
        {
            Cover? coverAdded = context.Covers
                .Include(c => c.Artists)
                .FirstOrDefault();

            var foundArtists = context.Artists.Where(x => artists.Contains(x.Id));
            coverAdded?.Artists.AddRange(foundArtists);
            await context.SaveChangesAsync();
        }
    }
}
