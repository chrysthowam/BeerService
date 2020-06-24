using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Commands;
using BeerService.Domain.Core.Notifications;
using BeerService.Domain.Interfaces.UnitOfWork;
using MediatR;
using System.Threading.Tasks;

namespace BeerService.Domain.CommandHandlers
{
    public class CommandHandler
    {
        protected readonly IUnitOfWork _unitOfwork;
        protected readonly IMediatorHandler _bus;
        protected readonly NotificationHandler _notifications;

        public CommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus, 
            INotificationHandler<Notification> notifications)
        {
            _unitOfwork = unitOfWork;
            _notifications = (NotificationHandler)notifications;
            _bus = bus;
        }

        protected async Task NotifyValidationErrors(Command command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                await _bus.RaiseEvent(new Notification(command.MessageType, error.ErrorMessage));
            }
        }

        public async Task<bool> Commit()
        {
            if (_notifications.HasNotifications())
                return false;

            if (await _unitOfwork.SaveChangesAsync())
                return true;

            await _unitOfwork.DisposeAsync();

            await _bus.RaiseEvent(new Notification("Commit", "Não foi possível salvar as alterações!"));

            return false;
        }
    }
}