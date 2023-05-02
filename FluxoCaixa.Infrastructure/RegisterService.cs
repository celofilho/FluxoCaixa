using FluxoCaixa.Application.Context;
using FluxoCaixa.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoCaixa.Infrastructure
{
    public static class RegisterService
    {
        public static void ConfigureInfraStructure(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<FluxoCaixaDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("FluxoCaixaDbConnection"));
            });
            services.AddScoped<IFluxoCaixaDbContext>(option => {
                return option.GetService<FluxoCaixaDbContext>();
            });

            services.AddScoped<IFluxoCaixaDbContext>(option => {
                return option.GetService<FluxoCaixaDbContext>();
            });

        }
    }
}
