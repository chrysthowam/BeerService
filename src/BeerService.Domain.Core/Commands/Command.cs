using FluentValidation.Results;
using MediatR;

namespace BeerService.Domain.Core.Commands
{
    public abstract class Command : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();

        protected Command()
        {
            MessageType = GetType().Name;
        }
    }
}
