using FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetSaldoDiario;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaldoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SaldoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna o Saldo(extrato) consolidado do dia
        /// </summary>
        /// <param name="payload"></param>
        /// <remarks></remarks>
        /// <response code="200">Retorna os lancamentos cadastrados</response>
        /// <response code="422">Error de Validação na Entidade</response>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpGet]
        public async Task<IActionResult> GetSaldoDiarioAsync([FromQuery] GetSaldoDiarioRequest payload)
        {
            var response = await _mediator.Send(payload);
            return Ok(response);
        }

        
    }
}
