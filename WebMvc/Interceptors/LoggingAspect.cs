using System;
using Castle.DynamicProxy;

namespace WebMvc.Interceptors
{
    public class LoggingAspect : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("SomeInterceptor: Before method");
            try
            {
                invocation.Proceed();
            }
            finally
            {
                Console.WriteLine("SomeInterceptor: After method");
            }
        }
    }
}
