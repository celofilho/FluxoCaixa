using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetSaldoDiario
{
    public class GetSaldoDiarioResponse
    {

        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
        public decimal Saldo { get; set; }
        public DateTime Data { get; set; }
    }
}
