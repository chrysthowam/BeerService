using System;
using System.Collections.Generic;
using System.Text;

namespace BeerService.Application.DTO.Models
{
    public class CervejaModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Harmonizacao { get; set; }
        public string Cor { get; set; }
        public string Categoria { get; set; }
        public decimal TeorAlcoolico { get; set; }
        public string Ingredientes { get; set; }
        public decimal TemperaturaInicial { get; set; }
        public decimal TemperaturaFinal { get; set; }
    }
}
