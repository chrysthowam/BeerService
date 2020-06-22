using BeerService.Domain.Core.Commands;
using BeerService.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace BeerService.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task<T> SendCommand<T>(IRequest<T> command);
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
