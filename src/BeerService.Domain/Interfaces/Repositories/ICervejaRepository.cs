using BeerService.Domain.Entities;
using System;

namespace BeerService.Domain.Interfaces.Repositories
{
    public interface ICervejaRepository : IRepository<Cerveja>
    {
        Cerveja GetByNome(string nome);
        Cerveja GetById(Guid id);
    }
}