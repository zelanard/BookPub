using BookPubDB.Data;
using BookPubDB.DTOs;
using BookPubDB.Model;
using BookPubDB.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;

namespace BookPubDB.Repositories
{
    /// <include file = 'Documentation/Repositories/AuthorRepository.xml' path='doc/authorrepository/member[@name="T:BookPubDB.Repositories.AuthorRepository"]' />
    public class AuthorRepository : Repository<Author>
    {
        /// <include file = 'Documentation/Repositories/AuthorRepository.xml' path='doc/authorrepository/member[@name="M:BookPubDB.Repositories.AuthorRepository.CreateAsync"]' />
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

        /// <include file = 'Documentation/Repositories/AuthorRepository.xml' path='doc/authorrepository/member[@name="M:BookPubDB.Repositories.AuthorRepository.GetByIdAsync"]' />
        public async override Task<Author?> GetByIdAsync(PublisherContext context, int id)
        {
            Author? item = await context.Authors
                .Include(c => c.Books)
                .FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        /// <include file = 'Documentation/Repositories/AuthorRepository.xml' path='doc/authorrepository/member[@name="M:BookPubDB.Repositories.AuthorRepository.UpdateAsync"]' />
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