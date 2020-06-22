using BeerService.Application.DTO.Models;
using System;

namespace BeerService.Application.DTO.DataTransferObjects
{
    public class ConsultarCervejaDTO
    {
        public class Envio
        {
            public Guid Id { get; set; }
        }

        public class Retorno
        {
            public CervejaModel Cerveja{ get; set; }
        }
    }
}