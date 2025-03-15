using BookPubDB.Data;
using BookPubDB.DTOs;
using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            await AddTo(context, data);

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
                .Include(c => c.Book)
                .FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async override Task<Cover?> UpdateAsync(PublisherContext context, int id, object data)
        {
            try
            {
                var dto = JsonConvert.DeserializeObject<CoverDto>(data.ToString());

                var itemToUpdate = context.Covers
                    .Include(c => c.Artists)
                    .FirstOrDefaultAsync(x => x.Id == id).Result;

                itemToUpdate.MapDto(dto);
                int changes = await context.SaveChangesAsync();

                await AddTo(context, data);

                return GetSuccessState(itemToUpdate, changes);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async override Task AddTo(PublisherContext context, object cover)
        {
            List<int> artistIds = [];

            if (cover is JObject json)
            {
                artistIds = json["artistIds"]?.ToObject<List<int>>() ?? [];
            }

            Cover? coverAdded = context.Covers
                .Include(c => c.Artists)
                .FirstOrDefault();

            var foundArtists = context.Artists.Where(x => artistIds.Contains(x.Id));
            coverAdded?.Artists.Clear();
            coverAdded?.Artists.AddRange(foundArtists);
            await context.SaveChangesAsync();
        }
    }
}