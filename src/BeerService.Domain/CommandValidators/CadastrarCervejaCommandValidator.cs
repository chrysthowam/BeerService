using BeerService.Domain.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeerService.Domain.CommandValidators
{
    public class CadastrarCervejaCommandValidator : AbstractValidator<CadastrarCervejaCommand>
    {
        public CadastrarCervejaCommandValidator()
        {
            ValidateCerveja();
        }

        private void ValidateCerveja()
        {
            RuleFor(x => x.Cerveja)
                .NotEmpty()
                .WithMessage("É necessário inserir uma cerveja para gravação!");

            When(x => x.Cerveja != null, () =>
            {
                RuleFor(x => x.Cerveja.Id)
                    .Empty()
                    .WithMessage($"A cerveja informada já está cadastrada!");
            });
        }
    }
}