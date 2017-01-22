using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace WebMvc.Interceptors
{
    public class ControllerLogInterceptor : IInterceptor
    {
        private readonly ILogger logger;

        public ControllerLogInterceptor(ILogger logger)
        {
            this.logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            switch (invocation.Method.Name)
            {
                case "OnActionExecuting":
                    OnActionExecuting(invocation);
                    break;
                case "OnActionExecuted":
                    OnActionExecuted(invocation);
                    break;
            }
            invocation.Proceed();
        }

        private void OnActionExecuted(IInvocation invocation)
        {
            var actionExecutedContext = invocation.Arguments[0] as ActionExecutedContext;
            logger.Debug("Executed action: " + invocation.TargetType.Name + "." +
                            actionExecutedContext.ActionDescriptor.ActionName);
        }

        private void OnActionExecuting(IInvocation invocation)
        {
            var actionExecutingContext = invocation.Arguments[0] as ActionExecutingContext;
            logger.Debug("Executing action: " + invocation.TargetType.Name + "." +
                            actionExecutingContext.ActionDescriptor.ActionName);
        }
    }
}