using BookPub.Filters.ActionFilters;
using BookPub.Filters.ExceptionFilters;
using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <summary>
    /// <c>ArtistController</c> handles <see cref="Artist"/> spesific http requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ActionController<Artist>
    {
        public ArtistController(PublisherContext context, IRepository<Artist> repo) : base(context, repo) { }

        [ValidateCreate_Filter("Artist")]
        public override IActionResult Create([FromBody] object item)
        {
            return base.Create(item);
        }

        [ValidateId_Filter("Artist")]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [ValidateId_Filter("Artist")]
        public override Task<IActionResult> Get(int id)
        {
            return base.Get(id);
        }

        [ValidateId_Filter("Artist")]
        [ValidateUpdate_Filter("Artist")]
        [Update_ExceptionFilter("Artist")]
        public override IActionResult Update(int id, [FromBody] object item)
        {
            return base.Update(id, item);
        }
    }
}
