using Autofac;
using ScLookup.Models.Context;

namespace ScLookup.Models
{
    public class ModelsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<StarcraftContext>()
                .As<IContext>()
                .InstancePerLifetimeScope();
        }
    }
}
