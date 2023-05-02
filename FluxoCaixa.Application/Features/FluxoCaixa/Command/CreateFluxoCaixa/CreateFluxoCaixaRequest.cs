using MediatR;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.CreateFluxoCaixa
{
    public class CreateFluxoCaixaRequest : IRequest<Guid>
    {
        public string Descricao { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
    }
}
