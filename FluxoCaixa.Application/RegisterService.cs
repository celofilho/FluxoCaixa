using FluentValidation;
using FluxoCaixa.Application.Common;
using FluxoCaixa.Application.Context;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FluxoCaixa.Application
{
    public static class RegisterService
    {
        public static void ConfigureApplication(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddMediatR(_ => _.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

            services.AddTransient<ExceptionHandlingMiddleware>();

            services.AddSwaggerGen(x=> x.ParameterFilter<CustomParameterFilter>());


        }
    }
}
