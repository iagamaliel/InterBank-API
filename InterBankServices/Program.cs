using Microsoft.EntityFrameworkCore;
using AutoMapper;
using InterBankServices.Application.UseCases;
using InterBankServices.Application.UseCases.Interfaces;
using InterBankServices.Controllers;
using InterBankServices.Mapping;
using InterBankServices.WebApi.Configurations;
using InterBankServices.WebApi.Extensions;
using log4net.Config;
using MediatR;
using Microsoft.OpenApi.Models;
using System.Reflection;
using InterBankServices.Infrastructure.DataBase;

[assembly: XmlConfigurator(ConfigFile = "log4net.config")]

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

//WebAPI Config
builder.Services.AddControllers();


// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();


builder.Services.AddSingleton(new DbConnection(builder.Configuration.GetConnectionString("SQLConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "API ASPNET Core 6", Version = "v1" });

});

//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy("EnableCors",
//          builder =>
//          {
//              builder.AllowAnyOrigin()
//                     .AllowAnyHeader()
//                     .AllowAnyMethod()
//                     .SetIsOriginAllowedToAllowWildcardSubdomains();
//          });
//});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                     .AllowAnyHeader()
                     .AllowAnyMethod()
                     .SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});



#region AutoMapping
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#endregion
// Configuración de versionamiento de API
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
});
var app = builder.Build();


app.Logger.LogInformation("Seeding Database...");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
