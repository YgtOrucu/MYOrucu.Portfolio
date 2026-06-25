namespace MuhsinYigitOrucu.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TInsertAsync(T t);
        Task TDeleteAsync(T t);
        Task TUpdateAsync(T t);
        Task<List<T>> TGetListAsync();
        Task<T> TGetByIdAsync(int id);
    }
}
