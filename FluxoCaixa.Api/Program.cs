using FluxoCaixa.Application;
using FluxoCaixa.Application.Common;
using FluxoCaixa.Infrastructure;
using FluxoCaixa.Infrastructure.Context;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//DI
builder.Services.ConfigureInfraStructure(builder.Configuration);
builder.Services.ConfigureApplication(builder.Configuration);
builder.Services.AddTransient<ExceptionHandlingMiddleware>();

// Add services to the container.
//builder.Services.AddDbContext<FluxoCaixaDbContext>();
builder.Services.AddTransient<IStartupFilter, DataContextAutomaticMigrationStartupFilter<FluxoCaixaDbContext>>();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "FluxoCaixa API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

});


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors();

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();
