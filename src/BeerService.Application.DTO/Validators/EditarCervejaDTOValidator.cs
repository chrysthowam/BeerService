using BeerService.Application.DTO.DataTransferObjects;
using FluentValidation;

namespace BeerService.Application.DTO.Validators
{
    public class EditarCervejaDTOValidator : AbstractCervejaDTOValidator<EditarCervejaDTO.Envio>
    {
        public EditarCervejaDTOValidator()
        {
            ValidateId();
            ValidateNome();
            ValidateCategoria();
            ValidateCor();
            ValidateDescricao();
            ValidateHarmonizacao();
            ValidateIngredientes();
        }

        private void ValidateId()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O campo \"Id\" é obrigatório!");
        }
    }
}