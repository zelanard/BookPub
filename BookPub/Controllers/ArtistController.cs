using BookPub.Filters.ActionFilters;
using BookPub.Filters.BaseFilters;
using BookPub.Filters.ExceptionFilters;
using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <include file='Documentation/Controllers/ArtistController.xml' path='doc/artists/member[@name="T:BookPub.Controllers.ArtistController"]' />
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ActionController<Artist>
    {
        /// <include file='Documentation/Controllers/ArtistController.xml' path='doc/artists/member[@name="C:BookPub.Controllers.ArtistController"]' />
        public ArtistController(PublisherContext context, IRepository<Artist> repo) : base(context, repo) { }

        /// <include file='Documentation/Controllers/ArtistController.xml' path='doc/artists/methods/member[@name="M:BookPub.Controllers.ArtistController.Create"]' />
        [ValidateCreate_Filter(RepoKey.Artist)]
        public override IActionResult Create([FromBody] object item)
        {
            return base.Create(item);
        }

        /// <include file='Documentation/Controllers/ArtistController.xml' path='doc/artists/methods/member[@name="M:BookPub.Controllers.ArtistController.Delete"]' />
        [ValidateId_Filter(RepoKey.Artist)]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        /// <include file='Documentation/Controllers/ArtistController.xml' path='doc/artists/methods/member[@name="M:BookPub.Controllers.ArtistController.Get"]' />
        [ValidateId_Filter(RepoKey.Artist)]
        public override IActionResult Get(int id)
        {
            return base.Get(id);
        }

        /// <include file='Documentation/Controllers/ArtistController.xml' path='doc/artists/methods/member[@name="M:BookPub.Controllers.ArtistController.Update"]' />
        [ValidateId_Filter(RepoKey.Artist)]
        [ValidateUpdate_Filter(RepoKey.Artist)]
        [Update_ExceptionFilter(RepoKey.Artist)]
        public override IActionResult Update(int id, [FromBody] object item)
        {
            return base.Update(id, item);
        }
    }
}
