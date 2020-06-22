using BeerService.Data.Contexts;
using BeerService.Domain.Interfaces.Repositories;
using BeerService.Domain.Interfaces.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BeerService.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        public UnitOfWork(MainContext context, ICervejaRepository cervejaRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            CervejaRepository = cervejaRepository ?? throw new ArgumentNullException(nameof(cervejaRepository));
        }

        public ICervejaRepository CervejaRepository { get; }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}