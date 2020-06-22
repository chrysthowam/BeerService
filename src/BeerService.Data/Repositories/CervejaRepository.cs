using BeerService.Data.Contexts;
using BeerService.Domain.Entities;
using BeerService.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace BeerService.Data.Repositories
{
    public class CervejaRepository : Repository<Cerveja>, ICervejaRepository
    {
        public CervejaRepository(MainContext context) : base(context) { }

        public Cerveja GetById(Guid id)
            => Set.FirstOrDefault(x => x.Id == id);

        public Cerveja GetByNome(string nome)
            => Set.FirstOrDefault(x => x.Nome == nome);
    }
}