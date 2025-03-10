﻿using BookPub.Filters.ActionFilters;
using BookPub.Filters.ExceptionFilters;
using BookPubDB.Data;
using BookPubDB.Model;
using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookPub.Controllers
{
    /// <summary>
    /// <c>BookController</c> handles <see cref="Book"/> spesific http requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ActionController<Book>
    {
        public BookController(PublisherContext context, IRepository<Book> bookRepo) : base(context, bookRepo) { }

        [ValidateCreate_Filter("Book")]
        public override IActionResult Create([FromBody] object item)
        {
            return base.Create(item);
        }

        [ValidateId_Filter("Book")]
        public override IActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        [ValidateId_Filter("Book")]
        public override Task<IActionResult> Get(int id)
        {
            return base.Get(id);
        }

        [ValidateId_Filter("Book")]
        [ValidateUpdate_Filter("Book")]
        [Update_ExceptionFilter("Book")]
        public override IActionResult Update(int id, [FromBody] object item)
        {
            return base.Update(id, item);
        }

    }
}