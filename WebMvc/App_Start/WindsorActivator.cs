
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(WebMvc.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof(WebMvc.WindsorActivator), "Shutdown")]

namespace WebMvc
{
    public static class WindsorActivator
    {
        static ContainerBootstrapper _bootstrapper;

        public static void PreStart()
        {
            _bootstrapper = ContainerBootstrapper.Bootstrap();
        }

        public static void Shutdown()
        {
            if (!ReferenceEquals(null,_bootstrapper))
                _bootstrapper.Dispose();
        }
    }
}