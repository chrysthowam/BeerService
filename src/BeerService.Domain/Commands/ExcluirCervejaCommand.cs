using BeerService.Domain.CommandValidators;
using BeerService.Domain.Core.Commands;
using BeerService.Domain.Entities;

namespace BeerService.Domain.Commands
{
    public class ExcluirCervejaCommand : Command
    {
        public Cerveja Cerveja { get; private set; }

        private ExcluirCervejaCommand() { }

        public static ExcluirCervejaCommand Factory(Cerveja cerveja)
        {
            return new ExcluirCervejaCommand()
            {
                Cerveja = cerveja
            };
        }

        public override bool IsValid()
        {
            ValidationResult = new ExcluirCervejaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
