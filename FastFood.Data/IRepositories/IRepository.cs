namespace FastFood.Data.IRepositories
{
    public interface IRepository<TResult>
    {
        Task<TResult> CreateAsync(TResult value);
        Task<TResult> UpdateAsync(TResult value);
        Task<bool> DeleteAsync(Predicate<TResult> predicate);
        Task<TResult> GetAsync(Predicate<TResult> predicate);
        Task<List<TResult>> GetAllAsync();
    }
}
