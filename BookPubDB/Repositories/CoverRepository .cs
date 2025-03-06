using BookPubDB.Data;
using BookPubDB.DTOs;
using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;

namespace BookPubDB.Repositories
{
    /// <summary>
    /// <c>CoverRepository</c> provides cover spesific tasks.
    /// </summary>
    /// <remarks>
    /// All methods are documented in the <see cref="Repository{T}"/>
    /// </remarks>
    public class CoverRepository : Repository<Cover>
    {
        public async override Task<Cover?> CreateAsync(PublisherContext context, object data)
        {
            CoverDto? coverDto = JsonConvert.DeserializeObject<CoverDto>(data.ToString());

            Cover cover = new();
            cover.MapDto(coverDto);

            Log.Information("Creating Cover: {Data} ", data);
            await context.Covers.AddAsync(cover);
            int changes = await context.SaveChangesAsync();

            AddArtistsToCover(context, coverDto.Artists);

            return GetSuccessState(cover, changes);
        }

        public async override Task<Cover?> DeleteAsync(PublisherContext context, int? id)
        {
            Cover? cover = context.Covers.Find(id);

            if (cover == null)
                return null;

            context.Covers.Remove(cover);
            int changes = await context.SaveChangesAsync();

            return GetSuccessState(cover, changes);
        }

        public async override Task<bool> Exists(int? id)
        {
            PublisherContext context = new();
            return context.Covers.Any(x => x.Id == id);
        }

        public async override Task<List<Cover>> GetAllAsync(PublisherContext context)
        {
            return context.Covers.ToList<Cover>(); //returns the list of Covers
        }

        public async override Task<Cover?> GetByIdAsync(PublisherContext context, int id)
        {
            Cover? item = await context.Covers
                .Include(c => c.Artists)
                .FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async override Task<Cover?> UpdateAsync(PublisherContext context, int id, object itemDto)
        {
            try
            {
                var dto = JsonConvert.DeserializeObject<CoverDto>(itemDto.ToString());

                var itemToUpdate = context.Covers
                    .Include(c => c.Artists)
                    .FirstOrDefaultAsync(x => x.Id == id).Result;

                itemToUpdate.MapDto(dto);
                int changes = await context.SaveChangesAsync();

                return GetSuccessState(itemToUpdate, changes);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}