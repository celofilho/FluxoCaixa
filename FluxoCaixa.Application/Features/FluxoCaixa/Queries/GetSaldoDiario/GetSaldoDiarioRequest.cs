using FluxoCaixa.Application.Common;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetSaldoDiario
{
    public class GetSaldoDiarioRequest : IRequest<List<GetSaldoDiarioResponse>>
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [SwaggerParameterExample("DateTime","01/05/2023")]
        public DateTime Data { get; set; }
    }
}
