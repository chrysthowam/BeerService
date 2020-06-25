using BeerService.Domain.Commands;
using FluentValidation;

namespace BeerService.Domain.CommandValidators
{
    public class EditarCervejaCommandValidator : AbstractValidator<EditarCervejaCommand>
    {
        public EditarCervejaCommandValidator()
        {
            ValidateCerveja();
            ValidateEditada();
        }

        private void ValidateCerveja()
        {
            RuleFor(x => x.Cerveja)
                .NotEmpty()
                .WithMessage("A cerveja informada para edição não foi encontrada!");
        }

        private void ValidateEditada()
        {
            RuleFor(x => x.CervejaEditada)
                .NotEmpty()
                .WithMessage("Não foram localizados dados para edição!");
        }
    }
}