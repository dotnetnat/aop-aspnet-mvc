using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WebMvc.Interfaces;
using WebMvc.Services;

namespace WebMvc.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                 Component
                 .For<IUserService>()
                 .ImplementedBy<UserService>()
                 .LifestyleTransient());
        }
    }
}