using BeerService.Data.Contexts;
using BeerService.Domain.Core.Entities;
using BeerService.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerService.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected MainContext _context { get; set; }
        protected DbSet<TEntity> Set => _context.Set<TEntity>();

        public Repository(MainContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            Set.Add(entity);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Set.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            Set.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            Set.Remove(entity);
        }

        public IQueryable<TEntity> GetListAll()
        {
            return Set.AsQueryable();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}