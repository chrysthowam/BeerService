using BeerService.Domain.CommandValidators;
using BeerService.Domain.Core.Commands;
using BeerService.Domain.Entities;

namespace BeerService.Domain.Commands
{
    public class EditarCervejaCommand : Command
    {
        public Cerveja Cerveja { get; private set; }
        public Cerveja CervejaEditada { get; private set; }

        private EditarCervejaCommand() { }

        public static EditarCervejaCommand Factory(Cerveja cerveja, Cerveja editada)
        {
            return new EditarCervejaCommand()
            {
                Cerveja = cerveja,
                CervejaEditada = editada
            };
        }

        public override bool IsValid()
        {
            ValidationResult = new EditarCervejaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
