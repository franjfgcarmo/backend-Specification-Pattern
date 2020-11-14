
using SpecPattern.Domain;
using SpecPattern.Infrastructure.Data;
using SpecPattern.Infrastructure.Repositories;
using System;
using System.Collections.Generic;

namespace SpecPattern.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<string, dynamic> _repositories;
        private DbSpecPattern context;

        public UnitOfWork(DbSpecPattern context)
        {
            this.context = context;
        }
      
        public IAsyncRepository<T> Repository<T>()
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, dynamic>();
            var type = typeof(T).Name;
            if (_repositories.ContainsKey(type))
                return (IAsyncRepository<T>)_repositories[type];
            var repositoryType = typeof(EFRepository<>);
            _repositories.Add(type, Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(T)), this)
            );
            return _repositories[type];
        }
     
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
