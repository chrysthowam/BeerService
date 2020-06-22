using BeerService.Application.DTO.DataTransferObjects;
using FluentValidation;

namespace BeerService.Application.DTO.Validators
{
    public class ExcluirCervejaDTOValidator : AbstractValidator<ExcluirCervejaDTO.Envio>
    {
        public ExcluirCervejaDTOValidator()
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
