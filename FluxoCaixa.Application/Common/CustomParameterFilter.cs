using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace FluxoCaixa.Application.Common
{
    public class CustomParameterFilter : IParameterFilter
    {
        public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
        {
            IEnumerable<SwaggerParameterExampleAttribute>? paramaterAtributes= null;

            if (context.PropertyInfo != null) 
            {          
                paramaterAtributes = context.PropertyInfo.GetCustomAttributes<SwaggerParameterExampleAttribute>();
            }
            else if (context.ParameterInfo != null)
            {
                paramaterAtributes = context.ParameterInfo.GetCustomAttributes<SwaggerParameterExampleAttribute>();
            }
            if (paramaterAtributes != null && paramaterAtributes.Any())
            {
                AddExample(parameter, paramaterAtributes);
            }
        }

        private void AddExample(OpenApiParameter parameter,
            IEnumerable<SwaggerParameterExampleAttribute> parameterAttributes)
        {
            foreach (var item in parameterAttributes)
            {
                var example = new OpenApiExample
                {
                    Value = new Microsoft.OpenApi.Any.OpenApiString(item.Value)
                };
                parameter.Examples.Add(item.Name, example);
            }
        }
    }
}
