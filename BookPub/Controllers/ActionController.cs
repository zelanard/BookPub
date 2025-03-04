using BookPubDB.Data;
using BookPubDB.Model.Enums;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Controllers;
using Utils;

namespace BookPub.Controllers
{
    /// <summary>
    /// <c>ActionController <typeparamref name="TType"/></c> models a default controller which handles default behaviour.
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public abstract class ActionController<TType> : ControllerBase, IActionController<TType> where TType : class
    {
        protected PublisherContext Context;
        protected IRepository<TType> Repository;

        public ActionController(PublisherContext context, IRepository<TType> repo)
        {
            Context = context;
            Repository = repo;
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

            if (result != null)
            {
                return GetIActionResult(result, ActionResultStatus.Created);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.BadRequest);
            }

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

            if (result != null)
            {
                return GetIActionResult(result, ActionResultStatus.Deleted);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.BadRequest);
            }
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

            if (result != null)
            {
                return GetIActionResult(result, ActionResultStatus.Ok);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.BadRequest);
            }
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

            if (result.Count > 0)
            {
                return GetIActionResult(result, ActionResultStatus.Ok);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.BadRequest);
            }
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

            if (result != null)
            {
                return GetIActionResult(result, ActionResultStatus.Updated);
            }
            else
            {
                return GetIActionResult(result, ActionResultStatus.BadRequest);
            }
        }

        /// <summary>
        /// Generates an <see cref="IActionResult"/>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ars"></param>
        /// <returns>An IActionResult</returns>
        protected IActionResult GetIActionResult(object? type, ActionResultStatus ars)
        {
            switch (ars)
            {
                case ActionResultStatus.Created:
                    return Created("", type);

                case ActionResultStatus.Deleted:
                    return StatusCode((int)ActionResultStatus.Deleted, new { message = "Deleted", type });
                
                case ActionResultStatus.Updated:
                    return StatusCode((int)ActionResultStatus.Updated, new { message = "Updated", type });
                
                case ActionResultStatus.Ok:
                    return Ok(type);
                
                default:
                    return NotFound($"Invalid Operation");
            }
        }
    }
}