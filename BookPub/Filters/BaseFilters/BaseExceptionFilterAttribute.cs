using Microsoft.AspNetCore.Mvc.Filters;

namespace BookPub.Filters.BaseFilters
{
    /// <include file='Documentation/Filters/BaseFilters/BaseExceptionFilterAttribute.xml' path='doc/baseexceptionfiltereattribute/member[@name="T:BookPub.Filters.BaseFilters.BaseExceptionFilterAttribute"]' />
    public class BaseExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <include file='Documentation/Filters/BaseFilters/BaseExceptionFilterAttribute.xml' path='doc/baseexceptionfiltereattribute/member[@name="F:BookPub.Filters.BaseFilters.BaseExceptionFilterAttribute.RepositoryHandler"]' />
        public FilterRepositoryHandler RepositoryHandler;

        /// <include file='Documentation/Filters/BaseFilters/BaseExceptionFilterAttribute.xml' path='doc/baseexceptionfiltereattribute/member[@name="C:BookPub.Filters.BaseFilters.BaseExceptionFilterAttribute"]' />
        public BaseExceptionFilterAttribute(RepoKey repoKey)
        {
            RepositoryHandler = new FilterRepositoryHandler(repoKey);
        }
    }
}