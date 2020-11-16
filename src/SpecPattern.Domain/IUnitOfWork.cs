using System;

namespace SpecPattern.Domain
{
    public interface IUnitOfWork:IDisposable
    {
        void SaveChanges();
        IAsyncRepository<T> Repository<T>();
    }
}
