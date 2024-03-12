using ApiModelo.Application;
using ApiModelo.Application.AutoMapper;
using ApiModelo.Application.Interfaces;
using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Services;
using ApiModelo.Infrastructure.Data;
using ApiModelo.Infrastructure.Data.Repositorys;
using Autofac;
using AutoMapper;

namespace ApiModelo.Infrastructure.InjectionDependency
{
    public class InjectionDependency : Module
    {
        //protected override void Load(ContainerBuilder builder)
        //{
        //    builder.Services.AddScoped<IApplicationServiceProduto, ApplicationsServiceProduto>();
        //    builder.Services.AddScoped<IServiceProduto, ServiceProduto>();
        //    builder.Services.AddScoped<IRepositoryProduto, RepositoryProduto>();

        //    builder.Services.AddScoped<IApplicationServiceCliente, ApplicationsServiceCliente>();
        //    builder.Services.AddScoped<IServiceCliente, ServiceCliente>();
        //    builder.Services.AddScoped<IRepositoryCliente, RepositoryCliente>();

        //    builder.Services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
        //    builder.Services.AddSingleton<MongoContext>();

        //    builder.Services.AddAutoMapper(typeof(ClienteMapper), typeof(ProdutoMapper));
        //}
    }
}

