using BookPub.Filters.ActionFilters;
using BookPub.Filters.ExceptionFilters;
using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <summary>
    /// <c>CoverController</c> handles <see cref="Cover"/> spesific http requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CoverController : ActionController<Cover>
    {
        public CoverController(PublisherContext context, IRepository<Cover> repo) : base(context, repo) { }

        [ValidateCreate_Filter("Cover")]
        public override IActionResult Create([FromBody] object item)
        {
            return base.Create(item);
        }

        [ValidateId_Filter("Cover")]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [ValidateId_Filter("Cover")]
        public override Task<IActionResult> Get(int id)
        {
            return base.Get(id);
        }

        [ValidateId_Filter("Cover")]
        [ValidateUpdate_Filter("Cover")]
        [Update_ExceptionFilter("Cover")]
        public override IActionResult Update(int id, [FromBody] object item)
        {
            return base.Update(id, item);
        }
    }
}
