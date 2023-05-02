using AutoMapper;
using FluxoCaixa.Application.Context;
using MediatR;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetSaldoDiario
{
    public class GetSaldoDiarioQueryHandler : IRequestHandler<GetSaldoDiarioRequest, List<GetSaldoDiarioResponse>>
    {
        private readonly IFluxoCaixaDbContext _fluxoCaixaDbContext;
        private readonly IMapper _mapper;

        public GetSaldoDiarioQueryHandler(IFluxoCaixaDbContext fluxoCaixaDbContext, IMapper mapper)
        {
            _fluxoCaixaDbContext = fluxoCaixaDbContext;
            _mapper = mapper;
        }

        public async Task<List<GetSaldoDiarioResponse>> Handle(GetSaldoDiarioRequest request, CancellationToken cancellationToken)
        {
            var date = string.Format("{0:yyyy-dd-MM}", request.Data);

            var select = _fluxoCaixaDbContext.FluxoCaixa
                .Where(x => x.Data.Date == DateTime.Parse(date));

            return _mapper.Map<List<GetSaldoDiarioResponse>>(select);

        }
    }
}
