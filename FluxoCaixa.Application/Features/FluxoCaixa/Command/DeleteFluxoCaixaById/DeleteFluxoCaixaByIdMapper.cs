using AutoMapper;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.DeleteFluxoCaixaById
{
    public class DeleteFluxoCaixaByIdMapper : Profile
    {
        public DeleteFluxoCaixaByIdMapper()
        {
            CreateMap<DeleteFluxoCaixaByIdRequest, Domain.Entities.FluxoCaixa>();
        }
    }
}
