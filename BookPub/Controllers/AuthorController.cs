using BookPub.Filters.ActionFilters;
using BookPub.Filters.BaseFilters;
using BookPub.Filters.ExceptionFilters;
using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <include file='Documentation/Controllers/AuthorsController.xml' path='doc/authors/member[@name="T:BookPub.Controllers.AuthorsController"]' />
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ActionController<Author>
    {
        /// <include file='Documentation/Controllers/AuthorsController.xml' path='doc/authors/member[@name="C:BookPub.Controllers.AuthorsController"]/summary' />
        public AuthorsController(PublisherContext context, IRepository<Author> repo) : base(context, repo) { }

        /// <include file='Documentation/Controllers/AuthorsController.xml' path='doc/authors/methods/member[@name="M:BookPub.Controllers.AuthorsController.Create"]' />
        [ValidateCreate_Filter(RepoKey.Author)]
        public override IActionResult Create([FromBody] object item)
        {
            return base.Create(item);
        }

        /// <include file='Documentation/Controllers/AuthorsController.xml' path='doc/authors/methods/member[@name="M:BookPub.Controllers.AuthorsController.Delete"]' />
        [ValidateId_Filter(RepoKey.Author)]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        /// <include file='Documentation/Controllers/AuthorsController.xml' path='doc/authors/methods/member[@name="M:BookPub.Controllers.AuthorsController.Get"]' />
        [ValidateId_Filter(RepoKey.Author)]
        public override IActionResult Get(int id)
        {
            return base.Get(id);
        }

        /// <include file='Documentation/Controllers/AuthorsController.xml' path='doc/authors/methods/member[@name="M:BookPub.Controllers.AuthorsController.Update"]' />
        [ValidateId_Filter(RepoKey.Author)]
        [ValidateUpdate_Filter(RepoKey.Author)]
        [Update_ExceptionFilter(RepoKey.Author)]
        public override IActionResult Update(int id, [FromBody] object item)
        {
            return base.Update(id, item);
        }
    }
}
