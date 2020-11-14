namespace SpecPattern.Domain
{
    public interface IUnitOfWork
    {
        void SaveChanges();
        IAsyncRepository<T> Repository<T>();
    }
}
