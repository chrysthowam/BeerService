using BeerService.Domain.Commands;
using FluentValidation;

namespace BeerService.Domain.CommandValidators
{
    public class ExcluirCervejaCommandValidator : AbstractValidator<ExcluirCervejaCommand>
    {
        public ExcluirCervejaCommandValidator()
        {
            ValidateCerveja();
        }

        private void ValidateCerveja()
        {
            RuleFor(x => x.Cerveja)
                .NotEmpty()
                .WithMessage("A cerveja informada para exclusão não foi encontrada!");
        }
    }
}