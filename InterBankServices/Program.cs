using AutoMapper;
using InterBankServices.Application.Interfaces.Commands;
using InterBankServices.Infrastructure.Command;
using InterBankServices.Mapping;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "API ASPNET Core 6", Version = "v1" });

});

#region AutoMapping
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ApplicationMapping());
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
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

app.UseAuthorization();

app.MapControllers();

app.Run();
