using AutoMapper;
using BeerService.Application.DTO.Models;
using BeerService.Domain.Entities;

namespace BeerService.Application.AutoMapper
{
    public class ApplicationToDomainProfile : Profile
    {
        public ApplicationToDomainProfile()
        {
            CreateMap<CervejaModel, Cerveja>();
        }
    }
}
