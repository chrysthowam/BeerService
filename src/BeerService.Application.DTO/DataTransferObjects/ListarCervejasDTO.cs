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

        }

        public class Retorno
        {
            public List<CervejaModel> Cervejas { get; set; }
        }
    }
}