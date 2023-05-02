using Microsoft.EntityFrameworkCore;

namespace FluxoCaixa.Application.Context
{
    public interface IFluxoCaixaDbContext
    {
        DbSet<FluxoCaixa.Domain.Entities.FluxoCaixa> FluxoCaixa { get; }
        Task<int> SaveToDbAsync();
    }
}
