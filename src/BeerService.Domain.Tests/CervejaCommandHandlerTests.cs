using BeerService.Domain.CommandHandlers;
using BeerService.Domain.Commands;
using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Notifications;
using BeerService.Domain.Entities;
using BeerService.Domain.Interfaces.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;

namespace BeerService.Domain.Tests
{
    [TestClass]
    public class CervejaCommandHandlerTests
    {
        [TestMethod]
        public async Task CadastrarCervejaHandle_ObjetoNulo_RaiseEvent()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var eventHandler = Substitute.For<NotificationHandler>();
            var mediator = Substitute.For<IMediatorHandler>();
            var handler = new CervejaCommandHandler(unitOfWork, mediator,eventHandler);
            var command = CadastrarCervejaCommand.Factory(null);

            await handler.Handle(command, CancellationToken.None);

            await mediator.ReceivedWithAnyArgs(1).RaiseEvent((Notification)null);
        }

        [TestMethod]
        public async Task CadastrarCervejaHandle_ObjetoNulo_SaveChangesAsync()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var eventHandler = Substitute.For<NotificationHandler>();
            var mediator = Substitute.For<IMediatorHandler>();
            var handler = new CervejaCommandHandler(unitOfWork, mediator, eventHandler);
            var cerveja = new Cerveja("Cerveja Teste", "Descrição", "Harmonização",
                "Coloração", "Categoria", "Ingredientes", 5, 0, 4, "Imagem.png");
            var command = CadastrarCervejaCommand.Factory(cerveja);

            await handler.Handle(command, CancellationToken.None);

            await unitOfWork.ReceivedWithAnyArgs(1).SaveChangesAsync();
        }

        [TestMethod]
        public async Task EditarCervejaHandle_CervejaNaoInformada_RaiseEvent()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var eventHandler = Substitute.For<NotificationHandler>();
            var mediator = Substitute.For<IMediatorHandler>();
            var handler = new CervejaCommandHandler(unitOfWork, mediator, eventHandler);
            var cerveja = new Cerveja("Cerveja Teste", "Descrição", "Harmonização",
                "Coloração", "Categoria", "Ingredientes", 5, 0, 4, "Imagem.png");
            var command = EditarCervejaCommand.Factory(cerveja, null);

            await handler.Handle(command, CancellationToken.None);

            await mediator.ReceivedWithAnyArgs(1).RaiseEvent((Notification)null);
        }

        [TestMethod]
        public async Task EditarCervejaHandle_ObjetoNulo_SaveChangesAsync()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var eventHandler = Substitute.For<NotificationHandler>();
            var mediator = Substitute.For<IMediatorHandler>();
            var handler = new CervejaCommandHandler(unitOfWork, mediator, eventHandler);
            var cerveja = new Cerveja("Cerveja Teste", "Descrição", "Harmonização",
                "Coloração", "Categoria", "Ingredientes", 5, 0, 4, "Imagem.png");
            var editada = new Cerveja("Cerveja Editada", "Descrição", "Harmonização",
                "Coloração", "Categoria", "Ingredientes", 5, 0, 4, "Imagem.png");
            var command = EditarCervejaCommand.Factory(cerveja, editada);

            await handler.Handle(command, CancellationToken.None);

            await unitOfWork.ReceivedWithAnyArgs(1).SaveChangesAsync();
        }

        [TestMethod]
        public async Task ExcluirCervejaHandle_CervejaNaoInformada_RaiseEvent()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var eventHandler = Substitute.For<NotificationHandler>();
            var mediator = Substitute.For<IMediatorHandler>();
            var handler = new CervejaCommandHandler(unitOfWork, mediator, eventHandler);
            var cerveja = new Cerveja("Cerveja Teste", "Descrição", "Harmonização",
                "Coloração", "Categoria", "Ingredientes", 5, 0, 4, "Imagem.png");
            var command = ExcluirCervejaCommand.Factory(cerveja);

            await handler.Handle(command, CancellationToken.None);

            await mediator.ReceivedWithAnyArgs(1).RaiseEvent((Notification)null);
        }

        [TestMethod]
        public async Task ExcluirCervejaHandle_ObjetoNulo_SaveChangesAsync()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var eventHandler = Substitute.For<NotificationHandler>();
            var mediator = Substitute.For<IMediatorHandler>();
            var handler = new CervejaCommandHandler(unitOfWork, mediator, eventHandler);
            var cerveja = new Cerveja("Cerveja Teste", "Descrição", "Harmonização",
                "Coloração", "Categoria", "Ingredientes", 5, 0, 4, "Imagem.png");
            var command = ExcluirCervejaCommand.Factory(cerveja);

            await handler.Handle(command, CancellationToken.None);

            await unitOfWork.ReceivedWithAnyArgs(1).SaveChangesAsync();
        }
    }
}
