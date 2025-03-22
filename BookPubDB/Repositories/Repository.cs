using BookPubDB.Data;
using BookPubDB.Model;
using Microsoft.EntityFrameworkCore;

namespace BookPubDB.Repositories
{
    /// <include file = 'Documentation/Repositories/Repository.xml' path='doc/repository/member[@name="T:BookPubDB.Repositories.Repository`1"]' />
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        /// <include file = 'Documentation/Repositories/Repository.xml' path='doc/repository/member[@name="M:BookPubDB.Repositories.Repository`1.CreateAsync(BookPubDB.Data.PublisherContext,System.Object)"]' />
        public abstract Task<T?> CreateAsync(PublisherContext context, object model);

        /// <include file = 'Documentation/Repositories/Repository.xml' path='doc/repository/member[@name="M:BookPubDB.Repositories.Repository`1.DeleteAsync(BookPubDB.Data.PublisherContext,System.Int32?)"]' />
        public async virtual Task<T?> DeleteAsync(PublisherContext context, int? id)
        {
            var dbSet = context.Set<T>();
            T? item = dbSet.Find(id);

            if (item == null)
                return null;

            dbSet.Remove(item);
            int changes = await context.SaveChangesAsync();

            return GetSuccessState(item, changes);
        }

        /// <include file = 'Documentation/Repositories/Repository.xml' path='doc/repository/member[@name="M:BookPubDB.Repositories.Repository`1.Exists(System.Int32?)"]' />
        public async virtual Task<bool> Exists(int? id)
        {
            PublisherContext context = new();
            var dbSet = context.Set<T>();
            return await dbSet.AnyAsync(x => EF.Property<int>(x, "Id") == id);
        }

        /// <include file = 'Documentation/Repositories/Repository.xml' path='doc/repository/member[@name="M:BookPubDB.Repositories.Repository`1.GetAllAsync(BookPubDB.Data.PublisherContext)"]' />
        public async virtual Task<List<T>> GetAllAsync(PublisherContext context)
        {
            var dbSet = context.Set<T>();
            return dbSet.ToList<T>();
        }
        /// <include file = 'Documentation/Repositories/Repository.xml' path='doc/repository/member[@name="M:BookPubDB.Repositories.Repository`1.GetByIdAsync(BookPubDB.Data.PublisherContext,System.Int32)"]' />
        public abstract Task<T?> GetByIdAsync(PublisherContext context, int id);

        /// <include file = 'Documentation/Repositories/Repository.xml' path='doc/repository/member[@name="M:BookPubDB.Repositories.Repository`1.UpdateAsync(BookPubDB.Data.PublisherContext,System.Int32,System.Object)"]' />
        public abstract Task<T?> UpdateAsync(PublisherContext context, int id, object itemDto);

        /// <include file = 'Documentation/Repositories/Repository.xml' path='doc/repository/member[@name="M:BookPubDB.Repositories.Repository`1.GetSuccessState``2(BookPubDB.Model.T,System.Int32)"]' />
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

        /// <include file = 'Documentation/Repositories/Repository.xml' path='doc/repository/member[@name="M:BookPubDB.Repositories.Repository`1.AddTo(BookPubDB.Data.PublisherContext,System.Object)"]' />
        public virtual Task AddTo(PublisherContext context, object item)
        {
            throw new NotImplementedException();
        }
    }
}
