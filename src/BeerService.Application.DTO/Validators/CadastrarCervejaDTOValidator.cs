using BeerService.Application.DTO.DataTransferObjects;

namespace BeerService.Application.DTO.Validators
{
    public class CadastrarCervejaDTOValidator : AbstractCervejaDTOValidator<CadastrarCervejaDTO.Envio>
    {
        public CadastrarCervejaDTOValidator()
        {
            ValidateNome();
            ValidateCategoria();
            ValidateCor();
            ValidateDescricao();
            ValidateHarmonizacao();
            ValidateIngredientes();
        }
    }
}