namespace BookPubDB.Repositories
{
    public interface IFilterRepository
    {
        abstract Task<bool> Exists(int? id);
    }
}
