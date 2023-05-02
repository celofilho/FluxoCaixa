using MediatR;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.DeleteFluxoCaixaById
{
    public class DeleteFluxoCaixaByIdRequest : IRequest<System.Guid>
    {
        public Guid Id { get; set; }
    }
}
