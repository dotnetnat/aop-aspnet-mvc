using System;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace WebMvc.Interceptors
{
    public class LoggingAspect : IInterceptor
    {
        public ILogger Logger { get; set; }

        public LoggingAspect()
        {
            Logger = NullLogger.Instance;
        }
        public void Intercept(IInvocation invocation)
        {
            try
            {
                this.Logger.InfoFormat(
                    "{0} | Entering method [{1}] with paramters: {2}",
                    invocation.TargetType.Name,
                    invocation.Method.Name,
                    //this.GetInvocationDetails(invocation)
                    "");

                invocation.Proceed();
            }
            catch (Exception e)
            {
                this.Logger.ErrorFormat(
                    "{0} | ...Logging an exception has occurred: {1}", invocation.TargetType.Name, e);
                throw;
            }
            finally
            {
                this.Logger.InfoFormat(
                    "{0} | Leaving method [{1}] with return value {2}",
                    invocation.TargetType.Name,
                    invocation.Method.Name,
                    invocation.ReturnValue);
            }
        }
    }
}
