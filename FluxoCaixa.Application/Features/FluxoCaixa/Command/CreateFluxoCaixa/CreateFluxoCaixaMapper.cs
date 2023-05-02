using AutoMapper;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.CreateFluxoCaixa
{
    public class CreateFluxoCaixaMapper : Profile
    {
        public CreateFluxoCaixaMapper()
        {
            CreateMap<CreateFluxoCaixaRequest,Domain.Entities.FluxoCaixa>();
        }
    }
}
