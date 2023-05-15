using MediatR;

namespace FluxoCaixa.Application.Features.FluxoCaixa.Command.DeleteFluxoCaixaById
{
    public class DeleteFluxoCaixaByIdRequest : IRequest<System.Guid>
    {
        public DeleteFluxoCaixaByIdRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
