using BookPub.Filters.ActionFilters;
using BookPubDB.Data;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Controllers;

namespace BookPub.Controllers
{
    /// <summary>
    /// <c>ActionController</c> models a default controller which handles default behaviour on http requests.
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public abstract class ActionController<TType> : ControllerBase, IActionController<TType> where TType : class
    {
        protected PublisherContext Context;
        protected IRepository<TType> Repository;
        protected HttpResponseGenerator<TType> ResponseHandler;
        public ActionController(PublisherContext context, IRepository<TType> repo)
        {
            Context = context;
            Repository = repo;
            ResponseHandler = new HttpResponseGenerator<TType>();
        }

        /// <summary>
        /// Creates item in database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns>
        /// By default: Not Found with the message: <see cref="TType"/> Not Implemented.
        /// </returns>
        [HttpPost]
        public virtual IActionResult Create([FromBody] object item)
        {
            TType? result = this.Repository.CreateAsync(this.Context, item).Result;
            return ResponseHandler.Created(result);
        }

        /// <summary>
        /// Delete value from Database where value.id = id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// By default: Not Found with the message: <see cref="TType"/>:<see cref="id"/> Not Implemented.
        /// </returns>
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            TType? result = this.Repository.DeleteAsync(this.Context, id).Result;
            return ResponseHandler.Deleted(result);
        }

        /// <summary>
        /// Get item by id from database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Ok if item was found.<br/>
        /// NotFound if item was not found
        /// </returns>
        [HttpGet("{id}")]
        async public virtual Task<IActionResult> Get(int id)
        {
            TType? result = this.Repository.GetByIdAsync(this.Context, id).Result;
            return ResponseHandler.Ok(result);
        }

        /// <summary>
        /// Get all items from database.
        /// </summary>
        /// <returns>
        /// By default: Not Found with the message: <see cref="TType"/> Not Implemented.
        /// </returns>
        [HttpGet]
        public virtual IActionResult GetAll()
        {
            List<TType> result = this.Repository.GetAllAsync(this.Context).Result;
            return ResponseHandler.Ok(result);
        }

        /// <summary>
        /// Update item in database,
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns>
        /// By default: Not Found with the message: <see cref="TType"/>:<see cref="id"/> Not Implemented.
        /// </returns>
        [HttpPut("{id}")]
        public virtual IActionResult Update(int id, [FromBody] object item)
        {
            TType? result = this.Repository.UpdateAsync(this.Context, id, item).Result;
            return ResponseHandler.Update(result);
        }
    }
}