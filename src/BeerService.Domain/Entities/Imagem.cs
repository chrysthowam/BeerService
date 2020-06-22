using BeerService.Domain.Core.Entities;

namespace BeerService.Domain.Entities
{
    public class Imagem : Entity
    {
        public string Descricao { get; set; }
        public string Caminho { get; set; }
    }
}