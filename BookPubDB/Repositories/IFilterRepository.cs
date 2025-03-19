namespace BookPubDB.Repositories
{
    ///<include file = 'Documentation/Repositories/IFilterRepository.xml' path='doc/ifilterrepository/member[@name="T:BookPubDB.Repositories.IFilterRepository"]' />
    public interface IFilterRepository
    {
        ///<include file = 'Documentation/Repositories/IFilterRepository.xml' path='doc/ifilterrepository/member[@name="M:BookPubDB.Repositories.IFilterRepository.Exists(System.Int32?)"]' />
        abstract Task<bool> Exists(int? id);
    }
}