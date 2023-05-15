using AutoMapper;
using FluxoCaixa.Application.Context;
using MediatR;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.CreateFluxoCaixa
{
    public class CreateFluxoCaixaCommandHandler : IRequestHandler<CreateFluxoCaixaRequest, Guid>
    {
        private readonly IFluxoCaixaDbContext _fluxoCaixaDbContext;
        private readonly IMapper _mapper;

        public CreateFluxoCaixaCommandHandler(IFluxoCaixaDbContext fluxoCaixaDbContext, IMapper mapper)
        {
            _fluxoCaixaDbContext = fluxoCaixaDbContext;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateFluxoCaixaRequest request, CancellationToken cancellationToken)
        {
            var newFluxoCaixa = _mapper.Map<Domain.Entities.FluxoCaixa>(request);

            newFluxoCaixa.Data = DateTime.Now;

            decimal saldo = _fluxoCaixaDbContext.FluxoCaixa
                              .Where(o => o.Data < newFluxoCaixa.Data)
                              .Sum(o => o.Credito - o.Debito);

            if (saldo == 0)
                newFluxoCaixa.Saldo = request.Credito;
            else
                newFluxoCaixa.Saldo = saldo + request.Credito - request.Debito;

            _fluxoCaixaDbContext.FluxoCaixa.Add(newFluxoCaixa);
            await _fluxoCaixaDbContext.SaveToDbAsync();
            return newFluxoCaixa.Id;
        }
    }
}
