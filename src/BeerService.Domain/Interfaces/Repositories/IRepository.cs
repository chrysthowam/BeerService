using BeerService.Domain.Core.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerService.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task AddAsync(TEntity entity);
        IQueryable<TEntity> GetListAll();
    }
}