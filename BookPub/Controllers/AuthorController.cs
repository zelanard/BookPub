using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookPub.Controllers
{
    /// <summary>
    /// The <c>AuthorsController</c> in herits ControllerBase  contro sthe HTTP Methods of the api/author path.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ActionController<Author>
    {
        public AuthorsController(PublisherContext context, IRepository<Author> authorRepo) : base(context, authorRepo) { }
    }
}
