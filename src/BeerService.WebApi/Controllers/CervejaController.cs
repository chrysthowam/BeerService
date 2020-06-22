using BeerService.Application.DTO.DataTransferObjects;
using BeerService.Application.Interfaces;
using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BeerService.WebApi.Controllers
{
    public class CervejaController : MainController
    {
        private readonly ICervejaAppService _cervejaAppService;

        public CervejaController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator, ICervejaAppService cervejaAppService) : base(notifications, mediator)
        {
            _cervejaAppService = cervejaAppService;
        }

        [HttpPost]
        [Route("incluir")]
        public async Task<IActionResult> Incluir([FromBody] CadastrarCervejaDTO.Envio dto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(dto);
            }

            await _cervejaAppService.CadastrarCerveja(dto);

            return Response();
        }

        [HttpPost]
        [Route("editar")]
        public async Task<IActionResult> Editar([FromBody] EditarCervejaDTO.Envio dto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(dto);
            }

            await _cervejaAppService.EditarCerveja(dto);

            return Response();
        }

        [HttpPost]
        [Route("excluir")]
        public async Task<IActionResult> Excluir([FromBody] ExcluirCervejaDTO.Envio dto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(dto);
            }

            await _cervejaAppService.ExcluirCerveja(dto);

            return Response();
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Consultar([FromRoute] ConsultarCervejaDTO.Envio dto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(dto);
            }

            var result = _cervejaAppService.ConsultarCerveja(dto);

            return Response(result);
        }


        [HttpGet]
        [Route("listar")]
        public IActionResult Listar([FromQuery] ListarCervejasDTO.Envio dto)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(dto);
            }

            var result = _cervejaAppService.ListarCervejas(dto);

            return Response(result);
        }
    }
}