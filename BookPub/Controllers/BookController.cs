using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ActionController<Book>
    {
        public BookController(PublisherContext context, IRepository<Book> bookRepo) : base(context, bookRepo) { }
    }
}