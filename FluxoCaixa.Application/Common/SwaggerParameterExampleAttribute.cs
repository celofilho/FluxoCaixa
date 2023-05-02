namespace FluxoCaixa.Application.Common
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = true)]
    public class SwaggerParameterExampleAttribute : Attribute
    {
        public SwaggerParameterExampleAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public SwaggerParameterExampleAttribute(string value)
        {
            Value = value;
        }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
