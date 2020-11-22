
using SpecPattern.Domain;
using SpecPattern.Infrastructure.Data;
using SpecPattern.Infrastructure.Extensions;
using SpecPattern.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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

        #region [Disposable]
        ~UnitOfWork()
        {
            Dispose(false);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
                this.context.Dispose();
        }

        public void Dispose()
        {
            Dispose(false);
        }
        #endregion

        public IAsyncRepository<T> Repository<T>()
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, dynamic>();
            var type = typeof(T).Name;
            var currentType = typeof(EFRepository<>);
            if (_repositories.ContainsKey(type))
                return (IAsyncRepository<T>)_repositories[type];

            var reposityImplement = Assembly.GetAssembly(typeof(EFRepository<>)).GetTypes()
               .Where(TheType => TheType.IsClass
               && !TheType.ContainsGenericParameters
               && TheType.IsSubclassOfRawGeneric(typeof(EFRepository<>), type))
               .FirstOrDefault();

            if (reposityImplement is null)
            {
                var repositoryType = typeof(EFRepository<>);
                _repositories.Add(type, Activator.CreateInstance(
                repositoryType.MakeGenericType(typeof(T)), context)
                );
            }
            else
            {
                _repositories.Add(type, Activator.CreateInstance(reposityImplement, context));
            }

            return _repositories[type];
        }
     
        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
