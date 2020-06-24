using BeerService.Domain.Commands;
using BeerService.Domain.Core.Bus;
using BeerService.Domain.Core.Notifications;
using BeerService.Domain.Interfaces.UnitOfWork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BeerService.Domain.CommandHandlers
{
    public class CervejaCommandHandler : CommandHandler,
        IRequestHandler<CadastrarCervejaCommand, bool>,
        IRequestHandler<EditarCervejaCommand, bool>,
        IRequestHandler<ExcluirCervejaCommand, bool>
    {
        public CervejaCommandHandler(IUnitOfWork unitOfWork, IMediatorHandler bus,
            INotificationHandler<Notification> notifications)
            : base(unitOfWork, bus, notifications) { }

        public async Task<bool> Handle(CadastrarCervejaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                await NotifyValidationErrors(command);
                return false;
            }

            var cerveja = command.Cerveja;
            cerveja.AdicionarId();

            await _unitOfwork.CervejaRepository.AddAsync(cerveja);
            await Commit();

            return true;
        }

        public async Task<bool> Handle(EditarCervejaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                await NotifyValidationErrors(command);
                return false;
            }

            var cerveja = command.Cerveja;
            var editada = command.CervejaEditada;

            cerveja.Editar(editada.Nome, editada.Descricao, editada.Harmonizacao,
                editada.Cor, editada.Categoria, editada.Ingredientes,
                editada.TeorAlcoolico, editada.TemperaturaInicial, editada.TemperaturaFinal);

            await Task.Run(() => _unitOfwork.CervejaRepository.Update(cerveja));

            await Commit();

            return true;
        }

        public async Task<bool> Handle(ExcluirCervejaCommand command, CancellationToken cancellationToken)
        {
            if (!command.IsValid())
            {
                await NotifyValidationErrors(command);
                return false;
            }

            var cerveja = command.Cerveja;

            await Task.Run(() => _unitOfwork.CervejaRepository.Delete(cerveja));

            await Commit();

            return true;
        }
    }
}