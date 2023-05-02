using AutoMapper;
using FluxoCaixa.Application.Context;
using MediatR;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.DeleteFluxoCaixaById
{

    public class DeleteFluxoCaixaByIdCommandHandler : IRequestHandler<DeleteFluxoCaixaByIdRequest, System.Guid>
    {
        private readonly IFluxoCaixaDbContext _fluxoCaixaDbContext;
        private readonly IMapper _mapper;

        public DeleteFluxoCaixaByIdCommandHandler(IFluxoCaixaDbContext fluxoCaixaDbContext, IMapper mapper)
        {
            _fluxoCaixaDbContext = fluxoCaixaDbContext;
            _mapper = mapper;
        }

        public async Task<System.Guid> Handle(DeleteFluxoCaixaByIdRequest request, CancellationToken cancellationToken)
        {
            var mapFluxoCaixa = _mapper.Map<Domain.Entities.FluxoCaixa>(request);

            var FluxoCaixa = _fluxoCaixaDbContext.FluxoCaixa.Where(a => a.Id == mapFluxoCaixa.Id).FirstOrDefault();

            if (FluxoCaixa == null) return default;
            else
            {
                _fluxoCaixaDbContext.FluxoCaixa.Remove(FluxoCaixa);
                await _fluxoCaixaDbContext.SaveToDbAsync();
                return FluxoCaixa.Id;
            }
        }
    }
}
