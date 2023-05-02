namespace FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetAllFluxoCaixa
{
    public class GetAllFluxoCaixaResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Data { get; set; }
    }
}
