using BookPubDB.Data;
using BookPubDB.Model.Enums;

namespace BookPubDB.Repositories
{
    /// <summary>
    /// <c>IRepository</c> 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        abstract Task<T?> CreateAsync(PublisherContext context, object model);
        abstract Task<T?> DeleteAsync(PublisherContext context, int? id);
        abstract Task<List<T>> GetAllAsync(PublisherContext context);
        abstract Task<T?> GetByIdAsync(PublisherContext context, int id);
        abstract Task<bool> Exists(PublisherContext context, int id);
        abstract Task<T?> UpdateAsync(PublisherContext context, int id, object itemDto);
    }
}