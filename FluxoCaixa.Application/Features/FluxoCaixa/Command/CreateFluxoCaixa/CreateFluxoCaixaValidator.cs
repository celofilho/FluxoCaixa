using FluentValidation;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.CreateFluxoCaixa
{
    public class CreateFluxoCaixaValidator : AbstractValidator<CreateFluxoCaixaRequest>
    {
        public CreateFluxoCaixaValidator()
        {
            RuleFor(x => x.Descricao).NotEmpty();
        }
    }
}
