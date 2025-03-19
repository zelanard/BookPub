using BookPubDB.Data;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/member[@name="T:BookPub.Controllers.ActionController"]' />
    public abstract class ActionController<TType> : ControllerBase, IActionController<TType> where TType : class
    {
        /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/member[@name="P:BookPub.Controllers.ActionController.Context"]' />
        protected PublisherContext Context { get; private set; }

        /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/member[@name="P:BookPub.Controllers.ActionController.Repository"]' />
        protected IRepository<TType> Repository { get; private set; }

        /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/member[@name="P:BookPub.Controllers.ActionController.ResponseHandler"]' />
        protected HttpResponseGenerator<TType> ResponseHandler { get; private set; }

        /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/member[@name="C:BookPub.Controllers.ActionController"]' />
        public ActionController(PublisherContext context, IRepository<TType> repo)
        {
            Context = context;
            Repository = repo;
            ResponseHandler = new HttpResponseGenerator<TType>();
        }

        /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/methods/member[@name="M:BookPub.Controllers.ActionController.Create"]' />
        [HttpPost]
        public virtual IActionResult Create([FromBody] object item)
        {
            
            TType? result = this.Repository.CreateAsync(this.Context, item).Result;
            return ResponseHandler.Created(result);
        }

        /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/methods/member[@name="M:BookPub.Controllers.ActionController.Delete"]' />
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            TType? result = this.Repository.DeleteAsync(this.Context, id).Result;
            return ResponseHandler.Deleted(result);
        }

        /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/methods/member[@name="M:BookPub.Controllers.ActionController.Get"]' />
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            TType? result = this.Repository.GetByIdAsync(this.Context, id).Result;
            return ResponseHandler.Ok(result);
        }

        /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/methods/member[@name="M:BookPub.Controllers.ActionController.GetAll"]' />
        [HttpGet]
        public virtual IActionResult GetAll()
        {
            List<TType> result = this.Repository.GetAllAsync(this.Context).Result;
            return ResponseHandler.Ok(result);
        }

        /// <include file='Documentation/Controllers/ActionController.xml' path='doc/actions/methods/member[@name="M:BookPub.Controllers.ActionController.Update"]' />
        [HttpPut("{id}")]
        public virtual IActionResult Update(int id, [FromBody] object item)
        {
            TType? result = this.Repository.UpdateAsync(this.Context, id, item).Result;
            return ResponseHandler.Update(result);
        }
    }
}