using BookPub.Filters.ActionFilters;
using BookPub.Filters.BaseFilters;
using BookPub.Filters.ExceptionFilters;
using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <include file='Documentation/Controllers/CoverController.xml' path='doc/covers/member[@name="T:BookPub.Controllers.CoverController"]' />
    [Route("api/[controller]")]
    [ApiController]
    public class CoverController : ActionController<Cover>
    {
        /// <include file='Documentation/Controllers/CoverController.xml' path='doc/covers/member[@name="C:BookPub.Controllers.CoverController"]/summary' />
        public CoverController(PublisherContext context, IRepository<Cover> repo) : base(context, repo) { }

        /// <include file='Documentation/Controllers/CoverController.xml' path='doc/covers/methods/member[@name="M:BookPub.Controllers.CoverController.Create"]' />
        [ValidateCreate_Filter(RepoKey.Cover)]
        public override IActionResult Create([FromBody] object item)
        {
            return base.Create(item);
        }

        /// <include file='Documentation/Controllers/CoverController.xml' path='doc/covers/methods/member[@name="M:BookPub.Controllers.CoverController.Delete"]' />
        [ValidateId_Filter(RepoKey.Cover)]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        /// <include file='Documentation/Controllers/CoverController.xml' path='doc/covers/methods/member[@name="M:BookPub.Controllers.CoverController.Get"]' />
        [ValidateId_Filter(RepoKey.Cover)]
        public override IActionResult Get(int id)
        {
            return base.Get(id);
        }

        /// <include file='Documentation/Controllers/CoverController.xml' path='doc/covers/methods/member[@name="M:BookPub.Controllers.CoverController.Update"]' />
        [ValidateId_Filter(RepoKey.Cover)]
        [ValidateUpdate_Filter(RepoKey.Cover)]
        [Update_ExceptionFilter(RepoKey.Cover)]
        public override IActionResult Update(int id, [FromBody] object item)
        {
            return base.Update(id, item);
        }
    }
}
