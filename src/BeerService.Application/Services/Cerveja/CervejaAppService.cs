using AutoMapper;
using BeerService.Application.DTO.DataTransferObjects;
using BeerService.Application.DTO.Models;
using BeerService.Application.Interfaces;
using BeerService.Domain.Commands;
using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Notifications;
using BeerService.Domain.Entities;
using BeerService.Domain.Filter;
using BeerService.Domain.Interfaces.UnitOfWork;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerService.Application.Services
{
    public class CervejaAppService : GenericAppService, ICervejaAppService
    {
        private readonly IMapper _mapper;

        public CervejaAppService(IUnitOfWork unitOfWork, IMediatorHandler bus, 
            INotificationHandler<Notification> notifications, IMapper mapper) 
            : base(unitOfWork, bus, notifications)
        {
            _mapper = mapper;
        }

        public async Task CadastrarCerveja(CadastrarCervejaDTO.Envio dto)
        {
            var cerveja = UnitOfWork.CervejaRepository.GetByNome(dto.Nome) ??
                _mapper.Map<Cerveja>(dto);

            var command = CadastrarCervejaCommand.Factory(cerveja);
            await Bus.SendCommand(command);
        }

        public async Task EditarCerveja(EditarCervejaDTO.Envio dto)
        {
            var cerveja = UnitOfWork.CervejaRepository.GetById(dto.Id);
            var editada = _mapper.Map<Cerveja>(dto);

            var command = EditarCervejaCommand.Factory(cerveja, editada);
            await Bus.SendCommand(command);
        }

        public async Task ExcluirCerveja(ExcluirCervejaDTO.Envio dto)
        {
            var cerveja = UnitOfWork.CervejaRepository.GetById(dto.Id);

            var command = ExcluirCervejaCommand.Factory(cerveja);
            await Bus.SendCommand(command);
        }

        public ConsultarCervejaDTO.Retorno ConsultarCerveja(ConsultarCervejaDTO.Envio dto)
        {
            var cerveja = _mapper.Map<CervejaModel>(UnitOfWork.CervejaRepository.GetById(dto.Id));

            if (cerveja == null)
                Bus.RaiseEvent(new Notification("Search", "Nenhum registro localizado para os filtros informados!"));

            return new ConsultarCervejaDTO.Retorno() { Cerveja = cerveja };
        }

        public ListarCervejasDTO.Retorno ListarCervejas(ListarCervejasDTO.Envio dto)
        {
            var query = UnitOfWork.CervejaRepository.GetListAll();
            var filter = new CervejaFilter(query);
            var cervejas = filter
                .FiltrarNome(dto.Nome)
                .FiltrarIngredientes(dto.Ingredientes)
                .FiltrarCor(dto.Cor)
                .FiltrarTemperatura(dto.Temperatura)
                .FiltrarTeorAlcoolico(dto.TeorAlcoolico)
                .Listar();

            var retorno = _mapper.Map<List<CervejaModel>>(cervejas);

            if (retorno == null)
                Bus.RaiseEvent(new Notification("Search", "Nenhum registro localizado para os filtros informados!"));

            return new ListarCervejasDTO.Retorno() { Cervejas = retorno };
        }
    }
}