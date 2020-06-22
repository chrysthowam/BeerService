using BeerService.Domain.Commands;
using FluentValidation;

namespace BeerService.Domain.CommandValidators
{
    public class EditarCervejaCommandValidator : AbstractValidator<EditarCervejaCommand>
    {
        public EditarCervejaCommandValidator()
        {
            ValidateCerveja();
        }

        private void ValidateCerveja()
        {
            RuleFor(x => x.Cerveja)
                .NotEmpty()
                .WithMessage("A cerveja informada para edição não foi encontrada!");
        }
    }
}