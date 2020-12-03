using System;
using System.Collections;
using System.Threading.Tasks;
using API.Interfaces;
using API.Models;

namespace API.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly StoreContext _context;
        public UnitOfWork(StoreContext context)
        {
            this._context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositiryInstance = Activator.CreateInstance(repositoryType.MakeGenericType
                (typeof(TEntity)), _context);

                _repositories.Add(type, repositiryInstance);
            }

            return (IGenericRepository<TEntity>) _repositories[type];
        }
    }
}