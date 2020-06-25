using BeerService.Application.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerService.Application.DTO.DataTransferObjects
{
    public class ListarCervejasDTO
    {
        public class Envio
        {
            public string Nome { get; set; }
            public string Ingredientes { get; set; }
            public decimal? TeorAlcoolico { get; set; }
            public decimal? Temperatura { get; set; }
            public string Cor { get; set; }
        }

        public class Retorno
        {
            public List<CervejaModel> Cervejas { get; set; }
        }
    }
}