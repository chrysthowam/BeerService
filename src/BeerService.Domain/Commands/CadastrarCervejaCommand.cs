using BeerService.Domain.CommandValidators;
using BeerService.Domain.Core.Commands;
using BeerService.Domain.Entities;
using MediatR;

namespace BeerService.Domain.Commands
{
    public class CadastrarCervejaCommand : Command
    {
        public Cerveja Cerveja { get; private set; }

        private CadastrarCervejaCommand() { }

        public static CadastrarCervejaCommand Factory(Cerveja cerveja)
        {
            return new CadastrarCervejaCommand()
            {
                Cerveja = cerveja
            };
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarCervejaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}