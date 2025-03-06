using BookPubDB.Repositories;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookPub.Filters.ActionFilters.BaseFilters
{
    /// <summary>
    /// <c>BaseFilterAttribute</c> provides the <see cref="ArtistRepository"/> and the <see cref="NAME"/> constant.
    /// </summary>
    /// <remarks>
    /// Attributes in C# cannot be generic because their types must be fully defined at compile-time, 
    /// whereas generic types allow for type parameters that are specified later.
    /// Note that I did not know this until I built this project and found out by testing first and reading up on it afterwards. ;)
    /// </remarks>
    public class BaseExceptionFilterAttribute : ExceptionFilterAttribute
    {
        protected string Name { get; }

        public BaseExceptionFilterAttribute(string name)
        {
            Name = name;
        }

        public Dictionary<string, IFilterRepository> Repo = new(){
            {"Artist", new ArtistRepository() },
            {"Author", new AuthorRepository() },
            {"Book", new BookRepository() },
            {"Cover", new CoverRepository() }
        };
    }
}