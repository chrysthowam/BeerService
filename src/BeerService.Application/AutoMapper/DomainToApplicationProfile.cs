using AutoMapper;
using BeerService.Application.DTO.Models;
using BeerService.Domain.Entities;

namespace BeerService.Application.AutoMapper
{
    public class DomainToApplicationProfile : Profile
    {
        public DomainToApplicationProfile()
        {
            CreateMap<Cerveja, CervejaModel>();
        }
    }
}
