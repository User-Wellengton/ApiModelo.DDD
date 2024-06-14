using ApiModelo.Application;
using ApiModelo.Application.AutoMapper;
using ApiModelo.Application.Interfaces;
using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Services;
using ApiModelo.Infrastructure.Data;
using ApiModelo.Infrastructure.Data.Repositorys;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Registros de serviços
builder.Services.AddScoped<IApplicationServiceProduto, ApplicationsServiceProduto>();
builder.Services.AddScoped<IServiceProduto, ServiceProduto>();
builder.Services.AddScoped<IRepositoryProduto, RepositoryProduto>();


builder.Services.AddScoped<IApplicationServiceCliente, ApplicationsServiceCliente>();
builder.Services.AddScoped<IServiceCliente, ServiceCliente>();
builder.Services.AddScoped<IRepositoryCliente, RepositoryCliente>();

builder.Services.AddScoped<IApplicationServiceTarefa, ApplicationsServiceTarefa>();
builder.Services.AddScoped<IServiceTarefa, ServiceTarefa>();
builder.Services.AddScoped<IRepositoryTarefa, RepositoryTarefa>();


// Registro de IDatabaseSettings
builder.Services.AddSingleton<IDatabaseSettings, DatabaseSettings>();

// Configuração das opções do DatabaseSettings e injeção de IDatabaseSettings em MongoContext
builder.Services.AddSingleton<MongoContext>();

// Configuração das opções do DatabaseSettings e injeção de IDatabaseSettings em AutoIncrement
builder.Services.AddSingleton<AutoIncrement>();

builder.Services.AddAutoMapper(typeof(ClienteMapper), typeof(ProdutoMapper),typeof(TarefaMapper));

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

// Configuração do CORS
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Modelo v1"));
}


app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();