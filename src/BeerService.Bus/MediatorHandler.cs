using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Commands;
using BeerService.Domain.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace BeerService.Bus
{
    public sealed class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendCommand<T>(T command) where T : Command
        {
            await _mediator.Send(command);
        }

        public async Task<T> SendCommand<T>(IRequest<T> command)
        {
            return await _mediator.Send(command);
        }

        public async Task RaiseEvent<T>(T @event) where T : Event
        {
            await _mediator.Publish(@event);
        }
    }
}