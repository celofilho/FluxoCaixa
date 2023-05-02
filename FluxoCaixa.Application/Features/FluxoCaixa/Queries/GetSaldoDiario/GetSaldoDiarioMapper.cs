using AutoMapper;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetSaldoDiario
{
    public class GetSaldoDiarioMapper : Profile
    {
        public GetSaldoDiarioMapper()
        {
            CreateMap<Domain.Entities.FluxoCaixa, GetSaldoDiarioResponse>();
            CreateMap<GetSaldoDiarioResponse, Domain.Entities.FluxoCaixa>();
        }
    }
}
