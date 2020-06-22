using System;

namespace BeerService.Domain.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public void AdicionarId()
        {
            Id = Guid.NewGuid();
        }
    }
}