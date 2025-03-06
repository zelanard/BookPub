using BookPub.Filters.ActionFilters;
using BookPub.Filters.ExceptionFilters;
using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookPub.Controllers
{
    /// <summary>
    /// <c>AuthorController</c> handles <see cref="Author"/> spesific http requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ActionController<Author>
    {
        public AuthorsController(PublisherContext context, IRepository<Author> repo) : base(context, repo) { }

        [ValidateCreate_Filter("Author")]
        public override IActionResult Create([FromBody] object item)
        {
            return base.Create(item);
        }

        [ValidateId_Filter("Author")]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [ValidateId_Filter("Author")]
        public override Task<IActionResult> Get(int id)
        {
            return base.Get(id);
        }

        [ValidateId_Filter("Author")]
        [ValidateUpdate_Filter("Author")]
        [Update_ExceptionFilter("Author")]
        public override IActionResult Update(int id, [FromBody] object item)
        {
            return base.Update(id, item);
        }

    }
}
