using AutoMapper;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.UpdateFluxoCaixa
{
    public class UpdateFluxoCaixaMapper : Profile
    {
        public UpdateFluxoCaixaMapper()
        {
            CreateMap<UpdateFluxoCaixaRequest,Domain.Entities.FluxoCaixa>();
        }
    }
}
