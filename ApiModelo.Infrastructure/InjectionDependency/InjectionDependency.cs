using ApiModelo.Application;
using ApiModelo.Application.AutoMapper;
using ApiModelo.Application.Interfaces;
using ApiModelo.Domain.Core.Interfaces.Repositorys;
using ApiModelo.Domain.Core.Interfaces.Services;
using ApiModelo.Domain.Services;
using ApiModelo.Infrastructure.Data.Repositorys;
using Autofac;
using AutoMapper;

namespace ApiModelo.Infrastructure.InjectionDependency
{
    public class InjectionDependency
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<ApplicationsServiceCliente>().As<IApplicationServiceCliente>();
            builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
            builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();

            builder.RegisterType<ApplicationsServiceProduto>().As<IApplicationServiceProduto>();            
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();            
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ClienteMapper());
                cfg.AddProfile(new ProdutoMapper());
              

            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }

        #endregion IOC
    }
}

