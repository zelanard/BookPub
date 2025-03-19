using BookPubDB.Data;
using BookPubDB.Model.Enums;

namespace BookPubDB.Repositories
{
    /// <include file = 'Documentation/Repositories/IRepository.xml' path='doc/irepository/member[@name="T:BookPubDB.Repositories.IRepository`1"]' />
    public interface IRepository<T> : IFilterRepository
    {
        /// <include file = 'Documentation/Repositories/IRepository.xml' path='doc/irepository/member[@name="M:BookPubDB.Repositories.IRepository`1.CreateAsync(BookPubDB.Data.PublisherContext,System.Object)"]' />
        abstract Task<T?> CreateAsync(PublisherContext context, object model);

        /// <include file = 'Documentation/Repositories/IRepository.xml' path='doc/irepository/member[@name="M:BookPubDB.Repositories.IRepository`1.DeleteAsync(BookPubDB.Data.PublisherContext,System.Int32?)"]' />
        abstract Task<T?> DeleteAsync(PublisherContext context, int? id);

        /// <include file = 'Documentation/Repositories/IRepository.xml' path='doc/irepository/member[@name="M:BookPubDB.Repositories.IRepository`1.GetAllAsync(BookPubDB.Data.PublisherContext)"]' />
        abstract Task<List<T>> GetAllAsync(PublisherContext context);

        /// <include file = 'Documentation/Repositories/IRepository.xml' path='doc/irepository/member[@name="M:BookPubDB.Repositories.IRepository`1.GetByIdAsync(BookPubDB.Data.PublisherContext,System.Int32)"]' />
        abstract Task<T?> GetByIdAsync(PublisherContext context, int id);

        /// <include file = 'Documentation/Repositories/IRepository.xml' path='doc/irepository/member[@name="M:BookPubDB.Repositories.IRepository`1.UpdateAsync(BookPubDB.Data.PublisherContext,System.Int32,System.Object)"]' />
        abstract Task<T?> UpdateAsync(PublisherContext context, int id, object itemDto);
    }
}