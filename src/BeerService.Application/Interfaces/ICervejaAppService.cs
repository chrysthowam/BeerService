using BeerService.Application.DTO.DataTransferObjects;
using System.Threading.Tasks;

namespace BeerService.Application.Interfaces
{
    public interface ICervejaAppService
    {
        Task CadastrarCerveja(CadastrarCervejaDTO.Envio dto);
        Task ExcluirCerveja(ExcluirCervejaDTO.Envio dto);
        Task EditarCerveja(EditarCervejaDTO.Envio dto);
        ConsultarCervejaDTO.Retorno ConsultarCerveja(ConsultarCervejaDTO.Envio dto);
        ListarCervejasDTO.Retorno ListarCervejas(ListarCervejasDTO.Envio dto);
    }
}