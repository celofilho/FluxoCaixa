using AutoMapper;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Queries.GetAllFluxoCaixa
{
    public class GetAllFluxoCaixaMapper : Profile
    {
        public GetAllFluxoCaixaMapper()
        {
            CreateMap<Domain.Entities.FluxoCaixa, GetAllFluxoCaixaResponse>();
        }
    }
}
