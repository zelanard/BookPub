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
    /// <include file = 'Documentation/Repositories/CoverRepository.xml' path='doc/coverrepository/member[@name="T:BookPubDB.Repositories.CoverRepository"]' />
    public class CoverRepository : Repository<Cover>
    {
        /// <include file = 'Documentation/Repositories/CoverRepository.xml' path='doc/coverrepository/member[@name="M:BookPubDB.Repositories.CoverRepository.CreateAsync"]' />
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

        /// <include file = 'Documentation/Repositories/CoverRepository.xml' path='doc/coverrepository/member[@name="M:BookPubDB.Repositories.CoverRepository.GetByIdAsync"]' />
        public async override Task<Cover?> GetByIdAsync(PublisherContext context, int id)
        {
            Cover? item = await context.Covers
                .Include(c => c.Artists)
                .Include(c => c.Book)
                .FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        /// <include file = 'Documentation/Repositories/CoverRepository.xml' path='doc/coverrepository/member[@name="M:BookPubDB.Repositories.CoverRepository.UpdateAsync"]' />
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

        /// <include file = 'Documentation/Repositories/CoverRepository.xml' path='doc/coverrepository/member[@name="M:BookPubDB.Repositories.CoverRepository.AddTo"]' />
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