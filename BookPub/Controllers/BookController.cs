using BookPub.Filters.ActionFilters;
using BookPub.Filters.BaseFilters;
using BookPub.Filters.ExceptionFilters;
using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <include file='Documentation/Controllers/BookController.xml' path='doc/books/member[@name="T:BookPub.Controllers.BookController"]' />
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ActionController<Book>
    {
        /// <include file='Documentation/Controllers/BookController.xml' path='doc/books/member[@name="C:BookPub.Controllers.BookController"]' />
        public BookController(PublisherContext context, IRepository<Book> bookRepo) : base(context, bookRepo) { }

        /// <include file='Documentation/Controllers/BookController.xml' path='doc/books/methods/member[@name="M:BookPub.Controllers.BookController.Create"]' />
        [ValidateCreate_Filter(RepoKey.Book)]
        public override IActionResult Create([FromBody] object item)
        {
            return base.Create(item);
        }

        /// <include file='Documentation/Controllers/BookController.xml' path='doc/books/methods/member[@name="M:BookPub.Controllers.BookController.Delete"]' />
        [ValidateId_Filter(RepoKey.Book)]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        /// <include file='Documentation/Controllers/BookController.xml' path='doc/books/methods/member[@name="M:BookPub.Controllers.BookController.Get"]' />
        [ValidateId_Filter(RepoKey.Book)]
        public override IActionResult Get(int id)
        {
            return base.Get(id);
        }

        /// <include file='Documentation/Controllers/BookController.xml' path='doc/books/methods/member[@name="M:BookPub.Controllers.BookController.Update"]' />
        [ValidateId_Filter(RepoKey.Book)]
        [ValidateUpdate_Filter(RepoKey.Book)]
        [Update_ExceptionFilter(RepoKey.Book)]
        public override IActionResult Update(int id, [FromBody] object item)
        {
            return base.Update(id, item);
        }

    }
}