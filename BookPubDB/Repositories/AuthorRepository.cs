using BookPubDB.Data;
using BookPubDB.DTOs;
using BookPubDB.Model;
using BookPubDB.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace BookPubDB.Repositories
{
    /// <summary>
    /// <c>AuthorRepository</c> provides author spesific tasks.
    /// </summary>
    /// <remarks>
    /// All methods are documented in the <see cref="Repository{T}"/>
    /// </remarks>
    public class AuthorRepository : Repository<Author>
    {
        public async override Task<Author?> CreateAsync(PublisherContext context, object data)
        {
            var authorDto = JsonConvert.DeserializeObject<AuthorDto>(data.ToString());

            Author author = new();
            author.MapDto(authorDto);

            Log.Information("Creating Author: {FirstName} {LastName}", author.FirstName, author.LastName);
            await context.Authors.AddAsync(author);
            int changes = await context.SaveChangesAsync();

            return GetSuccessState(author, changes);
        }

        public async override Task<Author?> DeleteAsync(PublisherContext context, int? id)
        {
            Author? author = context.Authors.Find(id);

            if (author == null)
                return null;

            context.Authors.Remove(author);
            int changes = await context.SaveChangesAsync();

            return GetSuccessState(author, changes);
        }

        public async override Task<bool> Exists(PublisherContext context, int id)
        {
            return context.Authors.Any(x => x.Id == id);
        }

        public async override Task<List<Author>> GetAllAsync(PublisherContext context)
        {
            return context.Authors.ToList<Author>(); //returns the list of authors
        }

        public async override Task<Author?> GetByIdAsync(PublisherContext context, int id)
        {
            Author? item = await context.Authors
                .Include(c => c.Books)
                .FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async override Task<Author?> UpdateAsync(PublisherContext context, int id, object itemDto)
        {
            try
            {
                var dto = JsonConvert.DeserializeObject<AuthorDto>(itemDto.ToString());

                var itemToUpdate = context.Authors
                    .Include(c => c.Books)
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