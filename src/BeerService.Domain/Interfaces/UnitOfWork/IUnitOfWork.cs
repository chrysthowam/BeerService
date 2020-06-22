using BeerService.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace BeerService.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        ICervejaRepository CervejaRepository { get; }
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
    }
}