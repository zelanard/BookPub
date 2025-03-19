using Microsoft.AspNetCore.Mvc.Filters;

namespace BookPub.Filters.BaseFilters
{
    /// <include file='Documentation/Filters/BaseFilters/BaseFilterAttribute.xml' path='doc/basefiltereattribute/member[@name="T:BookPub.Filters.BaseFilters.BaseFilterAttribute"]'/>
    public class BaseFilterAttribute : ActionFilterAttribute
    {
        /// <include file='Documentation/Filters/BaseFilters/BaseFilterAttribute.xml' path='doc/basefiltereattribute/member[@name="F:BookPub.Filters.BaseFilters.BaseFilterAttribute.RepositoryHandler"]'/>
        public FilterRepositoryHandler RepositoryHandler;

        /// <include file='Documentation/Filters/BaseFilters/BaseFilterAttribute.xml' path='doc/basefiltereattribute/member[@name="M:BookPub.Filters.BaseFilters.BaseFilterAttribute.#ctor(BookPub.Filters.BaseFilters.BaseExceptionFilterAttribute.RepoKey)"]/*'/>
        public BaseFilterAttribute(RepoKey repoKey)
        {
            RepositoryHandler = new FilterRepositoryHandler(repoKey);
        }
    }
}