using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeerService.WebApi.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly NotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected MainController(INotificationHandler<Notification> notifications,
                                IMediatorHandler mediator)
        {
            _notifications = (NotificationHandler)notifications;
            _mediator = mediator;
        }

        protected IEnumerable<Notification> Notifications => _notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected new IActionResult Response(object result = null, bool returnObject = false)
        {
            if (IsValidOperation())
            {
                if (returnObject)
                    return Ok(result);

                return Ok(new
                {
                    success = true,
                    result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = new
                { 
                    Business = _notifications.GetNotifications().Select(n => n.Value)
                }
            });
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new Notification(code, message));
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotifyError(result.ToString(), error.Description);
            }
        }
    }
}