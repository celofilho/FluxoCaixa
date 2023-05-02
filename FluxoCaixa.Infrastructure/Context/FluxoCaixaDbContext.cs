using FluxoCaixa.Application.Context;
using FluxoCaixa.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FluxoCaixa.Infrastructure.Context
{
    #pragma warning disable CS1591
    public class FluxoCaixaDbContext : DbContext, IFluxoCaixaDbContext
    {
        public FluxoCaixaDbContext(DbContextOptions<FluxoCaixaDbContext> options) : base(options)
        {
            
        }



        public DbSet<Domain.Entities.FluxoCaixa> FluxoCaixa { get; set; }

        public async Task<int> SaveToDbAsync()
        {
            return await SaveChangesAsync();
        }
    }
    #pragma warning restore CS1591
}
