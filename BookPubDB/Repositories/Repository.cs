using BookPubDB.Data;
using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

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
        public virtual Task AddTo(PublisherContext context, object item)
        {
            throw new NotImplementedException();
        }
    }
}
