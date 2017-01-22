using System.Web.Mvc;
using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebMvc.Interceptors;
using WebMvc.Interfaces;
using WebMvc.Services;

namespace WebMvc.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //container.Register(Component.For<LoggingAspect>());

            container.Register(
                 Component
                 .For<IUserService>()
                 .ImplementedBy<UserService>()
                 .Interceptors(InterceptorReference.ForType<LoggingAspect>()).Anywhere
                 .LifestyleTransient());

        }
    }
}