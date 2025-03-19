using BookPubDB.Repositories;

namespace BookPub.Filters.BaseFilters
{
    /// <include file='Documentation/Filters/BaseFilters/FilterRepositoryHandler.xml' path='doc/filterrepositoryhandler/member[@name="T:BookPub.Filters.BaseFilters.FilterRepositoryHandler"]' />
    public class FilterRepositoryHandler
    {
        /// <include file='Documentation/Filters/BaseFilters/FilterRepositoryHandler.xml' path='doc/filterrepositoryhandler/member[@name="F:BookPub.Filters.BaseFilters.FilterRepositoryHandler.Repo"]' />
        private static readonly Dictionary<RepoKey, IFilterRepository> Repo = new(){
            {RepoKey.Artist, new ArtistRepository() },
            {RepoKey.Author, new AuthorRepository() },
            {RepoKey.Book, new BookRepository() },
            {RepoKey.Cover, new CoverRepository() }
        };

        /// <include file='Documentation/Filters/BaseFilters/FilterRepositoryHandler.xml' path='doc/filterrepositoryhandler/member[@name="C:BookPub.Filters.BaseFilters.FilterRepositoryHandler"]' />
        public FilterRepositoryHandler(RepoKey repoKey)
        {
            RKey = repoKey;
        }

        /// <include file='Documentation/Filters/BaseFilters/FilterRepositoryHandler.xml' path='doc/filterrepositoryhandler/member[@name="P:BookPub.Filters.BaseFilters.FilterRepositoryHandler.RKey"]' />
        public RepoKey RKey { get; }

        /// <include file='Documentation/Filters/BaseFilters/FilterRepositoryHandler.xml' path='doc/filterrepositoryhandler/methods/member[@name="M:BookPub.Filters.BaseFilters.FilterRepositoryHandler.Repository"]' />
        public IFilterRepository Repository()
        {
            return Repo[RKey];
        }
    }
}
