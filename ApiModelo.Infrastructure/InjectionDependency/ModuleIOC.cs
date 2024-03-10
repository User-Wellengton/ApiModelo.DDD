using Autofac;

namespace ApiModelo.Infrastructure.InjectionDependency
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            InjectionDependency.Load(builder);
        }
    }
}
