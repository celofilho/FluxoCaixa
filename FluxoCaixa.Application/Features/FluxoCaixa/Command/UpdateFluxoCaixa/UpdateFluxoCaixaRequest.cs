using MediatR;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.UpdateFluxoCaixa
{
    public class UpdateFluxoCaixaRequest : IRequest<System.Guid>
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Data { get; set; }
    }
}
