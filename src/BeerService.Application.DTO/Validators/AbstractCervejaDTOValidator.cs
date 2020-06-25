using BeerService.Application.DTO.Models;
using FluentValidation;

namespace BeerService.Application.DTO.Validators
{
    public abstract class AbstractCervejaDTOValidator<T> : AbstractValidator<T> where T : CervejaModel
    {
        protected void ValidateNome()
        {
            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("O campo \"Nome\" é obrigatório!");
        }

        protected void ValidateDescricao()
        {
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("O campo \"Descricao\" é obrigatório!");
        }

        protected void ValidateHarmonizacao()
        {
            RuleFor(x => x.Harmonizacao)
                .NotEmpty()
                .WithMessage("O campo \"Harmonizacao\" é obrigatório!");
        }

        protected void ValidateCor()
        {
            RuleFor(x => x.Cor)
                .NotEmpty()
                .WithMessage("O campo \"Cor\" é obrigatório!");
        }

        protected void ValidateCategoria()
        {
            RuleFor(x => x.Categoria)
                .NotEmpty()
                .WithMessage("O campo \"Categoria\" é obrigatório!");
        }

        protected void ValidateIngredientes()
        {
            RuleFor(x => x.Ingredientes)
                .NotEmpty()
                .WithMessage("O campo \"Ingredientes\" é obrigatório!");
        }

        protected void ValidateImagem()
        {
            RuleFor(x => x.Imagem)
                .NotEmpty()
                .WithMessage("O campo \"Imagem\" é obrigatório!");
        }
    }
}