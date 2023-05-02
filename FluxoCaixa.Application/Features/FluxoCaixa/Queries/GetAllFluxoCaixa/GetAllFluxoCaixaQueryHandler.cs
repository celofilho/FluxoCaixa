using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluxoCaixa.Application.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetAllFluxoCaixa
{
    public class GetAllFluxoCaixaQueryHandler : IRequestHandler<GetAllFluxoCaixaRequest, List<GetAllFluxoCaixaResponse>>
    {
        private readonly IFluxoCaixaDbContext _fluxoCaixaDbContext;
        private readonly IMapper _mapper;

        public GetAllFluxoCaixaQueryHandler(IFluxoCaixaDbContext fluxoCaixaDbContext, IMapper mapper)
        {
            _fluxoCaixaDbContext = fluxoCaixaDbContext;
            _mapper = mapper;
        }

        public Task<List<GetAllFluxoCaixaResponse>> Handle(GetAllFluxoCaixaRequest request, CancellationToken cancellationToken)
        {
            return _fluxoCaixaDbContext.FluxoCaixa.ProjectTo<GetAllFluxoCaixaResponse>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
    }
}
