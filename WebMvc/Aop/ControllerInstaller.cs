using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebMvc.Interceptors;

namespace WebMvc.Aop
{
    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(AllTypes.FromThisAssembly()
                             .BasedOn()
                             .If(Component.IsInSameNamespaceAs())
                             .If(t => t.Name.EndsWith("Controller"))
                             .Configure((c => c.LifeStyle.Transient.Interceptors<ControllerLogInterceptor>())));
        }
    }
}