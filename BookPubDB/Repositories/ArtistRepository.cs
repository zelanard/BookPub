using BookPubDB.Data;
using BookPubDB.DTOs;
using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace BookPubDB.Repositories
{
    /// <summary>
    /// <c>ArtistRepository</c> provides artist spesific tasks.
    /// </summary>
    /// <remarks>
    /// All methods are documented in <see cref="Repository{T}"/>
    /// </remarks>
    public class ArtistRepository : Repository<Artist>
    {
        public async override Task<Artist?> CreateAsync(PublisherContext context, object data)
        {
            var artistDto = JsonConvert.DeserializeObject<ArtistDto>(data.ToString());

            Artist artist = new();
            artist.MapDto(artistDto);

            Log.Information("Creating Artist: {Artist}", data);
            await context.Artists.AddAsync(artist);
            int changes = await context.SaveChangesAsync();

            return GetSuccessState(artist, changes);
        }
        public async override Task<Artist?> DeleteAsync(PublisherContext context, int? id)
        {
            Artist? artist = context.Artists.Find(id);

            if (artist == null)
                return null;

            context.Artists.Remove(artist);
            int changes = await context.SaveChangesAsync();

            return GetSuccessState(artist, changes);
        }
        public async override Task<bool> Exists(int? id)
        {
            PublisherContext context = new();
            return context.Artists.Any(x => x.Id == id);
        }
        public async override Task<List<Artist>> GetAllAsync(PublisherContext context)
        {
            return context.Artists.ToList<Artist>();
        }
        public async override Task<Artist?> GetByIdAsync(PublisherContext context, int id)
        {
            Artist? artist = await context.Artists
                .Include(c => c.Covers)
                .FirstOrDefaultAsync(x => x.Id == id);

            return artist;
        }
        public async override Task<Artist?> UpdateAsync(PublisherContext context, int id, object itemDto)
        {
            try
            {
                var dto = JsonConvert.DeserializeObject<ArtistDto>(itemDto.ToString());

                var itemToUpdate = context.Artists
                    .Include(c => c.Covers)
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
