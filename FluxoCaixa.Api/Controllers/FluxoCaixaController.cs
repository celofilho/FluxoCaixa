using FluxoCaixa.Application.Features.FluxoCaixa.Command.CreateFluxoCaixa;
using FluxoCaixa.Application.Features.FluxoCaixa.Command.DeleteFluxoCaixaById;
using FluxoCaixa.Application.Features.FluxoCaixa.Command.UpdateFluxoCaixa;
using FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetAllFluxoCaixa;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FluxoCaixaController : ControllerBase
    {
        private readonly IMediator _mediator;
        public FluxoCaixaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Cria os lançamentos
        /// </summary>
        /// <param name="payload"></param>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /FluxoCaixa
        ///     {        
        ///       "descricao": "Pedido no Crédito Número 101",
        ///       "credito": "1000",
        ///       "debito": "0"        
        ///     }
        /// </remarks>
        /// <returns></returns>
        /// <response code="201">O lançamento foi criado com sucesso</response>
        /// <response code="422">Error de Validação na Entidade</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<IActionResult> PostAsync(CreateFluxoCaixaRequest payload)
        {
            var newCreateItemId = await _mediator.Send(payload);
            return Created($"FluxoCaixa/{newCreateItemId}",newCreateItemId);
        }

        /// <summary>
        /// Lista todos os lançamentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var response = await _mediator.Send(new GetAllFluxoCaixaRequest());
            return Ok(response);
        }

        /// <summary>
        /// Atualiza os Lançamentos
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateFluxoCaixaRequest payload)
        {
            var Id = await _mediator.Send(payload);
            return Ok(Id);
        }

        /// <summary>
        /// Deleta por Id do Lançamento
        /// </summary>
        /// <param name="payload"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteByIdAsync(DeleteFluxoCaixaByIdRequest payload)
        {
            var Id = await _mediator.Send(payload);
            return Ok(Id);
        }
    }
}
