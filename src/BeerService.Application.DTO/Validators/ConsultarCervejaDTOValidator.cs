using BeerService.Application.DTO.DataTransferObjects;
using FluentValidation;

namespace BeerService.Application.DTO.Validators
{
    public class ConsultarCervejaDTOValidator : AbstractValidator<ConsultarCervejaDTO.Envio>
    {
        public ConsultarCervejaDTOValidator()
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O campo \"Id\" é obrigatório!");
        }
    }
}