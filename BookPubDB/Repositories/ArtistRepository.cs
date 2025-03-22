using BookPubDB.Data;
using BookPubDB.DTOs;
using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace BookPubDB.Repositories
{
    /// <include file='Documentation/Repositories/ArtistRepository.xml' path='doc/artistrepository/member[@name="T:BookPubDB.Repositories.ArtistRepository"]' />
    public class ArtistRepository : Repository<Artist>
    {
        /// <include file='Documentation/Repositories/ArtistRepository.xml' path='doc/artistrepository/member[@name="M:BookPubDB.Repositories.ArtistRepository.CreateAsync"]' />
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

        /// <include file='Documentation/Repositories/ArtistRepository.xml' path='doc/artistrepository/member[@name="M:BookPubDB.Repositories.ArtistRepository.GetByIdAsync"]' />
        public async override Task<Artist?> GetByIdAsync(PublisherContext context, int id)
        {
            Artist? artist = await context.Artists
                .Include(c => c.Covers)
                .FirstOrDefaultAsync(x => x.Id == id);

            return artist;
        }

        /// <include file='Documentation/Repositories/ArtistRepository.xml' path='doc/artistrepository/member[@name="M:BookPubDB.Repositories.ArtistRepository.UpdateAsync"]' />
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