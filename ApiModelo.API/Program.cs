using ApiModelo.Application.AutoMapper;
using ApiModelo.Application.Interfaces;
using ApiModelo.Application;
using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Services;
using ApiModelo.Infrastructure.Data.Repositorys;
using ApiModelo.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Registros de serviços
builder.Services.AddScoped<IApplicationServiceProduto, ApplicationsServiceProduto>();
builder.Services.AddScoped<IServiceProduto, ServiceProduto>();
builder.Services.AddScoped<IRepositoryProduto, RepositoryProduto>();

builder.Services.AddScoped<IApplicationServiceCliente, ApplicationsServiceCliente>();
builder.Services.AddScoped<IServiceCliente, ServiceCliente>();
builder.Services.AddScoped<IRepositoryCliente, RepositoryCliente>();

builder.Services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
builder.Services.AddSingleton<MongoContext>();

builder.Services.AddAutoMapper(typeof(ClienteMapper), typeof(ProdutoMapper));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Modelo", Version = "v1" });
});

// Configuração das opções do DatabaseSettings e injeção de IDatabaseSettings
var config = builder.Configuration.GetSection("DatabaseSettings");
builder.Services.Configure<DatabaseSettings>(config);
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Modelo v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();