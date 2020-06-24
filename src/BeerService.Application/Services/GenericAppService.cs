using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Notifications;
using BeerService.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace BeerService.Application.Services
{
    public class GenericAppService
    {
        internal IUnitOfWork UnitOfWork { get; set; }
        internal IMediatorHandler Bus { get; set; }
        internal NotificationHandler Notifications { get; set; }

        public GenericAppService(IUnitOfWork iuow, IMediatorHandler bus, INotificationHandler<Notification> notifications)
        {
            Notifications = (NotificationHandler)notifications;
            UnitOfWork = iuow;
            Bus = bus;
        }
    }
}