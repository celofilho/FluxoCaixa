using AutoMapper;
using FluxoCaixa.Application.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.UpdateFluxoCaixa
{
    public class UpdateFluxoCaixaCommandHandler : IRequestHandler<UpdateFluxoCaixaRequest, System.Guid>
    {
        private readonly IFluxoCaixaDbContext _fluxoCaixaDbContext;
        private readonly IMapper _mapper;

        public UpdateFluxoCaixaCommandHandler(IFluxoCaixaDbContext fluxoCaixaDbContext, IMapper mapper)
        {
            _fluxoCaixaDbContext = fluxoCaixaDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(UpdateFluxoCaixaRequest request, CancellationToken cancellationToken)
        {
            var mapFluxoCaixa = _mapper.Map<Domain.Entities.FluxoCaixa>(request);

            var FluxoCaixa = _fluxoCaixaDbContext.FluxoCaixa.Where(a => a.Id == mapFluxoCaixa.Id).FirstOrDefault();

            if (FluxoCaixa == null) { return default; }
            else
            {
                FluxoCaixa.Descricao = mapFluxoCaixa.Descricao;
                FluxoCaixa.Saldo = mapFluxoCaixa.Saldo;
                FluxoCaixa.Data = mapFluxoCaixa.Data;
                FluxoCaixa.Credito = mapFluxoCaixa.Credito;
                FluxoCaixa.Debito = mapFluxoCaixa.Debito;

                await _fluxoCaixaDbContext.SaveToDbAsync();
                return FluxoCaixa.Id;
            }
        }
    }
}
